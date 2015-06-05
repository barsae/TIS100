using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TIS100.Operations {
    public class Mov : IOperation {
        public RWRef Source { get; private set; }
        public RWRef Destination { get; private set; }

        public Mov(RWRef source, RWRef destination) {
            this.Source = source;
            this.Destination = destination;
        }

        public IOperationResult Execute(AssemblyChip chip) {
            var source = Source.Reference(chip);
            var destination = Destination.Reference(chip);

            if (source.Readable() && destination.Writeable()) {
                destination.Write(source.Read());
                return OperationResult.Advance;
            }
            return OperationResult.Block;
        }
    }
}
