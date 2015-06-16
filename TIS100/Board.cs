using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TIS100.Chips;
using TIS100.RWs;

namespace TIS100 {
    public class Board {
        private Dictionary<Point, BaseChip> chips;
        private Dictionary<string, Point> namesToPoints;
        private Dictionary<Point, string> pointsToNames;

        public Board() {
            chips = new Dictionary<Point, BaseChip>();
            namesToPoints = new Dictionary<string, Point>();
            pointsToNames = new Dictionary<Point, string>();
        }

        public void Install(BaseChip chip, Point point) {
            chips[point] = chip;
            if (pointsToNames.ContainsKey(point)) {
                chip.Name = pointsToNames[point];
            }

            foreach (var dir in Direction.Enumerate()) {
                var other = GetChip(point.Add(dir));
                var rw1 = chip.CustomRW() ?? other.CustomRW() ?? new BufferRW();
                var rw2 = chip.CustomRW() ?? other.CustomRW() ?? new BufferRW();
                var channel = new Channel(rw1, rw2);
                chip.Connections[dir.Name] = channel.Terminal2;
                other.Connections[dir.Opposite] = channel.Terminal1;
            }
        }

        public BaseChip GetChip(Point point) {
            if (chips.ContainsKey(point)) {
                return chips[point];
            }
            return new NullChip();
        }

        public BaseChip GetChip(string name) {
            return chips[namesToPoints[name]];
        }

        public void Name(string name, Point point) {
            namesToPoints[name] = point;
            pointsToNames[point] = name;
        }

        public void ExecuteUntilBlocked() {
            int cyclesBlocked = 0;
            while (cyclesBlocked < 2) {
                foreach (var chip in chips.Values) {
                    chip.Execute();
                }

                if (chips.Values.Any(chip => chip.Status == ChipStatus.Executing)) {
                    cyclesBlocked = 0;
                } else {
                    cyclesBlocked++;
                }
            }
        }
    }
}
