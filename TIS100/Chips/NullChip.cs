using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TIS100.RWs;

namespace TIS100.Chips {
    public class NullChip : BaseChip {
        public NullChip() {
        }

        public override void Execute() {
        }

        public override RW NewRW() {
            return new NullRW();
        }
    }
}
