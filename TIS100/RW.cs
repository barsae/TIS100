using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TIS100 {
    public interface RW {
        bool Readable();
        bool Writeable();
        Number Read();
        void Write(Number value);
    }

    public static class RWHelper {
        public static RW Guarantee(RW rw) {
            return rw ?? new NullRW();
        }
    }

    public class NullRW : RW {
        public bool Readable() {
            return false;
        }

        public bool Writeable() {
            return false;
        }

        public Number Read() {
            throw new NotImplementedException();
        }

        public void Write(Number value) {
            throw new NotImplementedException();
        }
    }
}
