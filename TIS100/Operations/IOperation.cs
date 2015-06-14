using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TIS100.Chips;

namespace TIS100.Operations {
    public interface IOperation {
        IOperationResult Execute(AssemblyChip chip);
    }
}
