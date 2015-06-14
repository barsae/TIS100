// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Text;
// using System.Threading.Tasks;
// using TIS100.Chips;

// namespace TIS100.Operations {
//     public class Neg : IOperation {
//         public Neg() {
//         }

//         public IOperationResult Execute(AssemblyChip chip) {
//             chip.Acc.Write(-chip.Acc.Read());
//             return OperationResult.Advance;
//         }
//     }
// }
