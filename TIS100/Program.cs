using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TIS100.Operations;

namespace TIS100 {
    public class Program {
        static void Main(string[] args) {
            var stream = new InputStream(new List<int>() {
                1, 2, 3
            });

            var operations = new List<IOperation>() {
                new Mov(new Up(), new Acc()),
                new Sub(new Up())
            };

            var chip = new AssemblyChip(stream, null, null, null, operations);
            chip.Execute();
            chip.Execute();
            Console.WriteLine(chip.Acc);

            Console.WriteLine("Done");
            Console.ReadKey(true);
        }
    }
}
