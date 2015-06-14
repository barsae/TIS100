using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TIS100.RWs {
    public interface RW {
        void Write(Number value);
        bool IsDoneWriting();
        bool IsReadyToRead();
        Number Read();
    }
}
