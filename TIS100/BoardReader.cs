using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TIS100.Chips;

namespace TIS100 {
    public static class BoardReader {
        public static void Load(string filename, Board board) {
            foreach (var line in File.ReadLines(filename)) {
                // Trim and split the line
                var split = line.Trim()
                                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                // Ignore blank lines
                if (split.Length == 0) {
                    continue;
                }

                // Get name, x, y, and type
                if (split.Length != 4) {
                    throw new Exception("Expected [name] [x] [y] [type] instead of: " + line);
                }

                var name = split[0];

                int x, y;
                if (!Int32.TryParse(split[1], out x) || !Int32.TryParse(split[2], out y)) {
                    throw new Exception("Expected integers for [x] and [y] instead of: " + split[1] + " " + split[2]);
                }

                var chip = Instantiate(split[3]);

                // Install the chip
                var point = new Point(x, y);
                board.Name(name, point);
                board.Install(chip, point);
            }
        }

        private static BaseChip Instantiate(string name) {
            if (name == "AssemblyChip") {
                return new AssemblyChip();
            } else if (name == "ConsoleChip") {
                return new ConsoleChip();
            }
            throw new Exception("Unknown chip type: " + name);
        }
    }
}
