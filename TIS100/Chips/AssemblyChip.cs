using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TIS100.Operations;
using TIS100.RWs;

namespace TIS100.Chips {
    public class AssemblyChip : BaseChip {
        public List<IOperation> Operations { get; set; }
        public int Ip { get; set; }
        public Register Acc { get; set; }
        public Register Bak { get; set; }

        public AssemblyChip() {
            this.Operations = new List<IOperation>();
            this.Acc = new Register();
            this.Bak = new Register();
            this.Status = ChipStatus.Executing;
            Connections["ACC"] = this.Acc;
        }

        public override void Execute() {
            if (Operations.Count > 0) {
                var result = Operations[Ip].Execute(this);
                //Console.WriteLine("{0}: {1} {2}", Name, Operations[Ip], result);
                result.Apply(this);
            } else {
                this.Status = ChipStatus.Blocked;
            }
        }

        public override RW CustomRW() {
            return null;
        }
    }
}
