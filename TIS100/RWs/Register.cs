using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TIS100.RWs {
    public class Register : RW {
        private Number value;

        public Register() {
            value = new Number(0);
        }

        public Register(Number value) {
            this.value = value;
        }

        public void Write(Number value) {
            this.value = value;
        }

        public bool IsDoneWriting() {
            return true;
        }

        public bool IsReadyToRead() {
            return true;
        }

        public Number Read() {
            return value;
        }
    }
}
