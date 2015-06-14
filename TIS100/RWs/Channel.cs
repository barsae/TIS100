using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TIS100.RWs {
    public class Channel {
        public RW Terminal1 { get; private set; }
        public RW Terminal2 { get; private set; }

        public Channel(RW rw1, RW rw2) {
            Terminal1 = new ChannelTerminal(rw1, rw2);
            Terminal2 = new ChannelTerminal(rw2, rw1);
        }

        /// <summary>
        /// This class lets us read from one RW, but write to another
        /// </summary>
        private class ChannelTerminal : RW {
            private RW write;
            private RW read;

            public ChannelTerminal(RW write, RW read) {
                this.write = write;
                this.read = read;
            }

            public void Write(Number value) {
                write.Write(value);
            }

            public bool IsDoneWriting() {
                return write.IsDoneWriting();
            }

            public bool IsReadyToRead() {
                return read.IsReadyToRead();
            }

            public Number Read() {
                return read.Read();
            }
        }
    }
}
