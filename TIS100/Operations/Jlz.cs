using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TIS100.Operations {
    public class Jlz : IOperation {
        public RWRef Source { get; set; }

        public Jlz(RWRef source) {
            this.Source = source;
        }

        public bool Execute(AssemblyChip chip) {
            if (chip.Acc.Value < 0) {
                return chip.Jump(Source, true);
            }

            return false;
        }
    }
}
