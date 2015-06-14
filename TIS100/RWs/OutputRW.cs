using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TIS100.RWs {
    public class OutputRW : RW {
        public Queue<Number> Values { get; private set; }

        public OutputRW() {
            this.Values = new Queue<Number>();
        }

        public void Write(Number value) {
            Values.Enqueue(value);
        }

        public bool IsDoneWriting() {
            return true;
        }

        public bool IsReadyToRead() {
            return false;
        }

        public Number Read() {
            throw new NotImplementedException();
        }

        public override string ToString() {
            return string.Join(", ", Values);
        }
    }
}
