using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TIS100.RWs {
    public class ConsoleRW : RW {
        public void Write(Number value) {
            Console.WriteLine(value);
        }

        public bool IsDoneWriting() {
            return true;
        }

        public bool IsReadyToRead() {
            return true;
        }

        public Number Read() {
            Console.WriteLine("> ");
            var line = Console.ReadLine();
            int value = 0;

            while (!Int32.TryParse(line, out value)) {
                Console.WriteLine("{0} is not a number", line);
                Console.WriteLine("> ");
                line = Console.ReadLine();
            }

            return new Number(value);
        }
    }
}
