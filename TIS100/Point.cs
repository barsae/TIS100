using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TIS100 {
    public class Point : Tuple<int, int> {
        public int X {
            get { return Item1; }
        }

        public int Y {
            get { return Item2; }
        }

        public Point(int x, int y) : base(x, y) {
        }

        public Point Add(Direction dir) {
            return new Point(X + dir.DeltaX, Y + dir.DeltaY);
        }
    }
}
