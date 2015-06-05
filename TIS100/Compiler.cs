using Antlr4.Runtime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TIS100.Operations;
using TIS100.TisLang;

namespace TIS100 {
    public class CompilerVisitor : TisLangBaseVisitor<object> {
        public List<IOperation> Operations { get; private set; }

        public CompilerVisitor() {
            Operations = new List<IOperation>();
        }

        public override object VisitInstruction(TisLangParser.InstructionContext context) {
            return base.VisitInstruction(context);
        }
    }

    public static class Compiler {
        public static List<IOperation> Compile(string assembly) {
            var stream = new AntlrInputStream(assembly);
            var lexer = new TisLangLexer(stream);
            var tokens = new CommonTokenStream(lexer);
            var parser = new TisLangParser(tokens);
            
            // Parse
            var tree = parser.program();

            if (parser.NumberOfSyntaxErrors > 0) {
                throw new Exception("Failed to parse program");
            }

            CompilerVisitor visitor = new CompilerVisitor();
            visitor.Visit(tree);

            return visitor.Operations;
        }
    }
}
