using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TIS100.Operations {
    public class Swp : IOperation {
        public Swp() {
        }

        public IOperationResult Execute(AssemblyChip chip) {
            var swap = chip.Acc;
            chip.Acc = chip.Bak;
            chip.Bak = swap;
            return OperationResult.Advance;
        }
    }
}
