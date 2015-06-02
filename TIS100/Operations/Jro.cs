using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TIS100.Operations {
    public class Jro : IOperation {
        public RWRef Source { get; set; }

        public Jro(RWRef source) {
            this.Source = source;
        }

        public bool Execute(AssemblyChip chip) {
            return chip.Jump(Source, true);
        }
    }
}
