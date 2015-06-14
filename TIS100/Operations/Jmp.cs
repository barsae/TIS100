using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TIS100.Chips;

namespace TIS100.Operations {
    public class Jmp : IOperation {
        public int Ip { get; set; }

        public Jmp(int ip) {
            this.Ip = ip;
        }

        public IOperationResult Execute(AssemblyChip chip) {
            chip.Ip = Ip;
            return OperationResult.Jump;
        }
    }
}
