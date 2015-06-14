using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TIS100.RWs {
    public class BufferRW : RW {
        private BufferStatus status;
        private Number bufferedValue;

        public BufferRW() {
            status = BufferStatus.AwaitingWrite;
        }

        public void Write(Number value) {
            if (status != BufferStatus.AwaitingWrite) {
                throw new InvalidOperationException("Buffer was not awaiting write.");
            }
            bufferedValue = value;
            status = BufferStatus.AwaitingRead;
        }

        public bool IsDoneWriting() {
            return status == BufferStatus.AwaitingWrite;
        }

        public bool IsReadyToRead() {
            return status == BufferStatus.AwaitingRead;
        }

        public Number Read() {
            if (status != BufferStatus.AwaitingRead) {
                throw new InvalidOperationException("Buffer was not awaiting read.");
            }
            status = BufferStatus.AwaitingWrite;
            return bufferedValue;
        }

        private enum BufferStatus {
            Unknown,
            AwaitingWrite,
            AwaitingRead
        }
    }
}
