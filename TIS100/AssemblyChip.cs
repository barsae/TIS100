using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TIS100.Operations;

namespace TIS100 {
    public class AssemblyChip : BaseChip {
        public List<IOperation> Operations { get; private set; }
        public int Ip { get; set; }
        public Number Acc { get; set; }
        public Number Bak { get; set; }

        private bool jumpedThisTick;

        public AssemblyChip(RW up, RW right, RW down, RW left, IEnumerable<IOperation> operations)
                : base(up, right, down, left) {
            this.Operations = operations.ToList();
            this.Acc = new Number(0);
            this.Bak = new Number(0);
        }

        public override void Execute() {
            NormalizeIp();

            jumpedThisTick = false;
            if (Operations[Ip].Execute(this) && !jumpedThisTick) {
                Ip++;
            }

            NormalizeIp();
        }

        public bool Jump(RWRef to, bool relative = false) {
            var source = to.Reference(this);

            if (source.Readable()) {
                jumpedThisTick = true;

                if (relative) {
                    Ip = source.Read().Value;
                } else {
                    Ip = source.Read().Value;
                }
                return true;
            }
            return false;
        }

        private void NormalizeIp() {
            if (Ip < 0) {
                Ip = 0;
            }
            if (Ip >= Operations.Count) {
                Ip = 0;
            }
        }
    }
}
