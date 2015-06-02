using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TIS100.Operations {
    public interface IOperation {
        /// <summary>
        /// Returns true if this executed, and false if the operation was blocked
        /// </summary>
        bool Execute(AssemblyChip chip);
    }
}
