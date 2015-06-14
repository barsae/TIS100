using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TIS100.RWs {
    public class ConstantRW : RW {
        public Number Value { get; set; }

        public ConstantRW(Number value) {
            this.Value = value;
        }

        public void Write(Number value) {
            throw new NotImplementedException();
        }

        public bool IsDoneWriting() {
            return false;
        }

        public bool IsReadyToRead() {
            return true;
        }

        public Number Read() {
            return Value;
        }

        public override string ToString() {
            return Value.ToString();
        }
    }
}
