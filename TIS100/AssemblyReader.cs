using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TIS100.Chips;

namespace TIS100 {
    public static class AssemblyReader {
        public static void Load(string filename, Board board) {
            var chipName = "";
            var assembly = new StringBuilder();

            foreach (var line in File.ReadLines(filename)) {
                var trimmed = line.Trim();

                if (trimmed.StartsWith("@")) {
                    SetProgram(board, chipName, assembly.ToString());
                    chipName = trimmed;
                    assembly.Clear();
                } else if (chipName != "") {
                    assembly.AppendLine(line);
                }
            }

            SetProgram(board, chipName, assembly.ToString());
        }

        private static void SetProgram(Board board, string chipName, string assembly) {
            if (chipName != "") {
                var chip = board.GetChip(chipName) as AssemblyChip;
                // TODO: Null anti pattern here
                if (chip != null) {
                    chip.Operations = Compiler.Compile(assembly.ToString());
                } else {
                    throw new Exception(string.Format("Unable to set program for: {0}", chipName));
                }
            }
        }
    }
}
