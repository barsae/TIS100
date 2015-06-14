using Antlr4.Runtime;
using Antlr4.Runtime.Tree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TIS100.Operations;
using TIS100.RWs;
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
                    var name = label.SYMBOL().GetText().ToUpper();
                    Labels[name] = ip;
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
                    var name = instruction.SYMBOL().GetText();
                    var instructionType = GetInstructionType(name);
                    var constructorArgumentCount = GetConstructorArgumentCount(instructionType);

                    var rawArguments = instruction.argumentList().argument();
                    if (rawArguments.Count != constructorArgumentCount) {
                        throw new Exception(string.Format("Instruction '{0}' takes exactly {1} arguments", name, constructorArgumentCount));
                    }

                    var arguments = rawArguments.Select(arg => GetArgument(arg, labels))
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

        private object GetArgument(TisLangParser.ArgumentContext arg, Dictionary<string, int> labels) {
            var symbol = arg.SYMBOL();
            var integer = arg.INTEGER();

            if (symbol != null) {
                var name = symbol.GetText().ToUpper();
                if (IsConnection(name)) {
                    return new ConnectionRef(name);
                } else {
                    return labels[name];
                }
            } else if (integer != null) {
                return new ConstantRWRef(new ConstantRW(new Number(Int32.Parse(integer.GetText()))));
            }

            throw new NotImplementedException();
        }

        private bool IsConnection(string arg) {
            return arg == "UP" || arg == "RIGHT" || arg == "DOWN" || arg == "LEFT" || arg == "ACC";
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
