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
            BoardReader.Load(@"Programs\Triplicator.board", board);
            AssemblyReader.Load(@"Programs\Triplicator.asm", board);
            board.ExecuteUntilBlocked();

            Console.WriteLine("Done");
            Console.ReadKey(true);
        }
    }
}
