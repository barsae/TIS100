using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TIS100.Operations {
    public class Neg : IOperation {
        public Neg() {
        }

        public bool Execute(AssemblyChip chip) {
            chip.Acc = -chip.Acc;
            return true;
        }
    }
}
