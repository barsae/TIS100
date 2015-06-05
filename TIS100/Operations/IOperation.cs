using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TIS100.Operations {
    public interface IOperation {
        IOperationResult Execute(AssemblyChip chip);
    }
}
