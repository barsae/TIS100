using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TIS100.RWs {
    public class NullRW : RW {
        public void Write(Number value) {
            throw new NotImplementedException();
        }

        public bool IsDoneWriting() {
            return false;
        }

        public bool IsReadyToRead() {
            return false;
        }

        public Number Read() {
            throw new NotImplementedException();
        }
    }
}
