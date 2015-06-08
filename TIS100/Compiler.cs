using Antlr4.Runtime;
using Antlr4.Runtime.Tree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TIS100.Operations;
using TIS100.TisLang;

namespace TIS100 {
    public class LabelGatherer {
        public Dictionary<string, int> Labels { get; set; }

        public LabelGatherer() {
            Labels = new Dictionary<string, int>();
        }

        public void Gather(TisLangParser.ProgramContext program) {
            int ip = 0;
            
            foreach (var expression in program.expression()) {
                var label = expression.label();
                var instruction = expression.instruction();
                var eol = expression.EOL();

                if (label != null) {
                    Labels[label.SYMBOL().GetText()] = ip;
                } else if (instruction != null) {
                    ip++;
                } else if (eol != null) {
                } else {
                    throw new Exception("Unknown expression type");
                }
            }
        }
    }

    public class OperationGatherer {
        public List<IOperation> Operations { get; set; }

        public OperationGatherer() {
            Operations = new List<IOperation>();
        }

        public void Gather(TisLangParser.ProgramContext program, Dictionary<string, int> labels) {
            foreach (var expression in program.expression()) {
                var label = expression.label();
                var instruction = expression.instruction();
                var eol = expression.EOL();

                if (label != null) {
                } else if (instruction != null) {
                    var symbols = instruction.SYMBOL();
                    var name = symbols[0].GetText();
                    var instructionType = GetInstructionType(name);
                    var constructorArgumentCount = GetConstructorArgumentCount(instructionType);

                    if (symbols.Count != constructorArgumentCount + 1) {
                        throw new Exception(string.Format("Instruction {0} takes exactly {1} arguments", name, constructorArgumentCount));
                    }

                    var arguments = symbols.Skip(1)
                                           .Select(sym => GetArgument(sym.GetText(), labels))
                                           .ToArray();
                    var op = (IOperation)Activator.CreateInstance(instructionType, arguments);
                    Operations.Add(op);
                } else if (eol != null) {
                } else {
                    throw new Exception("Unknown expression type");
                }
            }
        }

        private Type GetInstructionType(string name) {
            return Assembly.GetExecutingAssembly()
                           .GetType("TIS100.Operations." + name, true, true);
        }

        private int GetConstructorArgumentCount(Type instructionType) {
            return instructionType.GetConstructors()
                                  .First()
                                  .GetParameters()
                                  .Count();
        }

        private RWRef GetArgument(string symbol, Dictionary<string, int> labels) {
            symbol = symbol.ToUpper();

            if (symbol == "UP") {
                return new Up();
            } else if (symbol == "RIGHT") {
                return new Right();
            } else if (symbol == "DOWN") {
                return new Down();
            } else if (symbol == "LEFT") {
                return new Left();
            } else if (symbol == "ACC") {
                return new Acc();
            } else if (labels.ContainsKey(symbol)) {
                return new NumberRef(new Number(labels[symbol]));
            }

            throw new Exception(string.Format("Unknown reference: {0}", symbol));
        }
    }

    public static class Compiler {
        public static List<IOperation> Compile(string assembly) {
            var stream = new AntlrInputStream(assembly);
            var lexer = new TisLangLexer(stream);
            var tokens = new CommonTokenStream(lexer);
            var parser = new TisLangParser(tokens);
            var program = parser.program();
            
            if (parser.NumberOfSyntaxErrors > 0) {
                throw new Exception("Failed to parse program");
            }

            var labels = new LabelGatherer();
            labels.Gather(program);

            var operations = new OperationGatherer();
            operations.Gather(program, labels.Labels);

            return operations.Operations;
        }
    }
}
