using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TIS100.RWs {
    public class InputRW : RW {
        public Queue<Number> Values { get; private set; }

        public InputRW(IEnumerable<int> values) {
            this.Values = new Queue<Number>(Number.Convert(values));
        }

        public void Write(Number value) {
            throw new NotImplementedException();
        }

        public bool IsDoneWriting() {
            return false;
        }

        public bool IsReadyToRead() {
            return Values.Count > 0;
        }

        public Number Read() {
            return Values.Dequeue();
        }
    }
}
