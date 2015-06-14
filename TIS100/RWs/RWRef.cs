using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TIS100.Chips;

namespace TIS100.RWs {
    public interface RWRef {
        RW Reference(BaseChip chip);
    }

    public class ConnectionRef : RWRef {
        public string RefName { get; set; }

        public ConnectionRef(string refName) {
            this.RefName = refName;
        }

        public RW Reference(BaseChip chip) {
            return chip.Connections[RefName];
        }

        public override string ToString() {
            return RefName;
        }
    }

    public class ConstantRWRef : RWRef {
        public RW RW { get; set; }

        public ConstantRWRef(RW rw) {
            this.RW = rw;
        }

        public RW Reference(BaseChip chip) {
            return RW;
        }

        public override string ToString() {
            return RW.ToString();
        }
    }
}
