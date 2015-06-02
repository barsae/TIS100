using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TIS100.Operations {
    public class Sub : IOperation {
        public RWRef Source { get; private set; }

        public Sub(RWRef source) {
            this.Source = source;
        }

        public bool Execute(AssemblyChip chip) {
            var source = Source.Reference(chip);

            if (source.Readable()) {
                chip.Acc = chip.Acc - source.Read();
                return true;
            }
            return false;
        }
    }
}
