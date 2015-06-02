using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TIS100 {
    public abstract class BaseChip {
        public RW Up { get; set; }
        public RW Right { get; set; }
        public RW Down { get; set; }
        public RW Left { get; set; }

        public BaseChip(RW up, RW right, RW down, RW left) {
            this.Up = RWHelper.Guarantee(up);
            this.Right = RWHelper.Guarantee(right);
            this.Down = RWHelper.Guarantee(down);
            this.Left = RWHelper.Guarantee(left);
        }

        public abstract void Execute();
    }
}
