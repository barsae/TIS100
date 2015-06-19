using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TIS100.Operations;

namespace TIS100 {
    public class Program {
        static void Main(string[] args) {
            if (args.Length != 2) {
                Console.WriteLine("Usage: TIS100.exe <asm filename> <board filename>");
                return;
            }

            var board = new Board();
            BoardReader.Load(args[1], board);
            AssemblyReader.Load(args[0], board);
            board.ExecuteUntilBlocked();
        }
    }
}
