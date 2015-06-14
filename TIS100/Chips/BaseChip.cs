using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TIS100.RWs;

namespace TIS100.Chips {
    public enum ChipStatus {
        Unknown,
        Executing,
        Blocked
    }

    public abstract class BaseChip {
        public string Name { get; set; }

        public DefaultDictionary<string, RW> Connections { get; private set; }
        public ChipStatus Status { get; set; }

        public BaseChip() {
            Connections = new DefaultDictionary<string, RW>(() => new NullRW());
        }

        public abstract void Execute();

        // This allows chips to control how they are written to
        public abstract RW NewRW();
    }
}
