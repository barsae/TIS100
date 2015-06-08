using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TIS100.Operations;

namespace TIS100 {
    public class Program {
        static void Main(string[] args) {
            var stream = new ConsoleStream();

            var operations = Compiler.Compile(@"
                MOV UP ACC
                ADD ACC
                MOV ACC DOWN
            ");

            var chip = new AssemblyChip(stream, null, stream, null, operations);
            for (int ii = 0; ii < 100; ii++) {
                chip.Execute();
            }

            Console.WriteLine("Done");
            Console.ReadKey(true);
        }
    }
}
