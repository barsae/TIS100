using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TIS100 {
    public interface RWRef {
        RW Reference(BaseChip chip);
    }

    public class Up : RWRef {
        public RW Reference(BaseChip chip) {
            return chip.Up;
        }
    }

    public class Right : RWRef {
        public RW Reference(BaseChip chip) {
            return chip.Right;
        }
    }

    public class Down : RWRef {
        public RW Reference(BaseChip chip) {
            return chip.Down;
        }
    }

    public class Left : RWRef {
        public RW Reference(BaseChip chip) {
            return chip.Left;
        }
    }

    public class Acc : RWRef {
        public RW Reference(BaseChip chip) {
            return ((AssemblyChip)chip).Acc;
        }
    }

    public class NumberRef : RWRef {
        private Number number;

        public NumberRef(Number number) {
            this.number = number;
        }

        public RW Reference(BaseChip chip) {
            return number;
        }
    }
}
