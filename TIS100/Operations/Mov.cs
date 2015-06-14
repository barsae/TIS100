using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TIS100.Chips;
using TIS100.RWs;

namespace TIS100.Operations {
    public class Mov : IOperation {
        public RWRef Source { get; private set; }
        public RWRef Destination { get; private set; }

        private MovState state;

        public Mov(RWRef source, RWRef destination) {
            this.Source = source;
            this.Destination = destination;
            this.state = MovState.Reading;
        }

        public IOperationResult Execute(AssemblyChip chip) {
            var source = Source.Reference(chip);
            var destination = Destination.Reference(chip);

            if (state == MovState.Reading && source.IsReadyToRead()) {
                destination.Write(source.Read());
                state = MovState.Writing;
            }

            if (state == MovState.Writing && destination.IsDoneWriting()) {
                state = MovState.Reading;
                return OperationResult.Advance;
            }

            return OperationResult.Block;
        }

        public override string ToString() {
            return string.Format("MOV {0} {1}", Source, Destination);
        }

        private enum MovState {
            Unknown,
            Reading,
            Writing
        }
    }
}
