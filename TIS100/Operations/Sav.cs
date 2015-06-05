using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TIS100.Operations {
    public class Sav : IOperation {
        public Sav() {
        }

        public IOperationResult Execute(AssemblyChip chip) {
            chip.Bak = chip.Acc.Copy();
            return OperationResult.Advance;
        }
    }
}
