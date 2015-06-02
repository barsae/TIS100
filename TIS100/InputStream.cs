using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TIS100 {
    public class InputStream : RW {
        public Queue<Number> Values { get; private set; }

        public InputStream(IEnumerable<int> values) {
            this.Values = new Queue<Number>(Number.Convert(values));
        }

        public bool Readable() {
            return Values.Count > 0;
        }

        public bool Writeable() {
            return false;
        }

        public Number Read() {
            return Values.Dequeue();
        }

        public void Write(Number value) {
            throw new NotImplementedException();
        }
    }
}
