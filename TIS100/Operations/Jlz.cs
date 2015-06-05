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

        public IOperationResult Execute(AssemblyChip chip) {
            var rw = Source.Reference(chip);
            if (rw.Readable() && chip.Acc.ToInteger() < 0) {
                chip.Ip = rw.Read().ToInteger();
                return OperationResult.Jump;
            }

            return OperationResult.Block;
        }
    }
}
