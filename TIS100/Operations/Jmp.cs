using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TIS100.Operations {
    public class Jmp : IOperation {
        public RWRef Source { get; set; }

        public Jmp(RWRef source) {
            this.Source = source;
        }

        public IOperationResult Execute(AssemblyChip chip) {
            var rw = Source.Reference(chip);
            if (rw.Readable()) {
                chip.Ip = rw.Read().ToInteger();
                return OperationResult.Jump;
            }
            return OperationResult.Block;
        }
    }
}
