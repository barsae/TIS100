using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TIS100 {
    public class ConsoleStream : RW {
        public bool Readable() {
            return true;
        }

        public bool Writeable() {
            return true;
        }

        public Number Read() {
            while (true) {
                Console.Write("> ");
                var line = Console.ReadLine();
                int value;

                if (Int32.TryParse(line, out value)) {
                    return new Number(value);
                }

                Console.WriteLine("'{0}' is not a number", line);
            }
        }

        public void Write(Number value) {
            Console.WriteLine(value.ToInteger());
        }
    }
}
