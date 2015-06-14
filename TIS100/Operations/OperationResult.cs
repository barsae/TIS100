using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TIS100.Chips;

namespace TIS100.Operations {
    public interface IOperationResult {
        void Apply(AssemblyChip chip);
    }

    public abstract class OperationResult : IOperationResult {
        public static IOperationResult Block = new BlockResult();
        public static IOperationResult Advance = new AdvanceResult();
        public static IOperationResult Jump = new JumpResult();

        public abstract void Apply(AssemblyChip chip);

        protected void NormalizeIp(AssemblyChip chip) {
            if (chip.Ip < 0 || chip.Ip >= chip.Operations.Count) {
                chip.Ip = 0;
            }
        }
    }

    public class BlockResult : OperationResult {
        public override void Apply(AssemblyChip chip) {
            chip.Status = ChipStatus.Blocked;
        }

        public override string ToString() {
            return "Blocked";
        }
    }

    public class AdvanceResult : OperationResult {
        public override void Apply(AssemblyChip chip) {
            chip.Status = ChipStatus.Executing;
            chip.Ip++;
            NormalizeIp(chip);
        }

        public override string ToString() {
            return "Advanced";
        }
    }

    public class JumpResult : OperationResult {
        public override void Apply(AssemblyChip chip) {
            chip.Status = ChipStatus.Executing;
            NormalizeIp(chip);
        }

        public override string ToString() {
            return "Jumped";
        }
    }
}
