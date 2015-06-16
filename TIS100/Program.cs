using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TIS100.Operations;

namespace TIS100 {
    public class Program {
        static void Main(string[] args) {
            var board = new Board();
            BoardReader.Load(@"Programs\Multiplier.board", board);
            AssemblyReader.Load(@"Programs\Multiplier.asm", board);
            board.ExecuteUntilBlocked();

            Console.WriteLine("Done");
            Console.ReadKey(true);
        }
    }
}
