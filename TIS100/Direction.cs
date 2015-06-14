using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TIS100 {
    public class Direction {
        public string Name { get; set; }
        public string Opposite { get; set; }
        public int DeltaX { get; set; }
        public int DeltaY { get; set; }

        public Direction(string name, string opposite, int deltaX, int deltaY) {
            this.Name = name;
            this.Opposite = opposite;
            this.DeltaX = deltaX;
            this.DeltaY = deltaY;
        }

        public static Direction Up    = new Direction("UP",    "DOWN",   0, -1);
        public static Direction Right = new Direction("RIGHT", "LEFT",   1,  0);
        public static Direction Down  = new Direction("DOWN",  "UP",     0,  1);
        public static Direction Left  = new Direction("LEFT",  "RIGHT", -1,  0);

        public static IEnumerable<Direction> Enumerate() {
            yield return Direction.Up;
            yield return Direction.Right;
            yield return Direction.Down;
            yield return Direction.Left;
        }
    }
}
