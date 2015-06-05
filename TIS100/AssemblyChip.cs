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

        public AssemblyChip(RW up, RW right, RW down, RW left, IEnumerable<IOperation> operations)
                : base(up, right, down, left) {
            this.Operations = operations.ToList();
            this.Acc = new Number(0);
            this.Bak = new Number(0);
        }

        public override void Execute() {
            var result = Operations[Ip].Execute(this);
            result.Apply(this);
        }
    }
}
