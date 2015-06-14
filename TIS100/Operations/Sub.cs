// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Text;
// using System.Threading.Tasks;
// using TIS100.Chips;

// namespace TIS100.Operations {
//     public class Sub : IOperation {
//         public RWRef Source { get; private set; }

//         public Sub(RWRef source) {
//             this.Source = source;
//         }

//         public IOperationResult Execute(AssemblyChip chip) {
//             var source = Source.Reference(chip);

//             if (source.Readable()) {
//                 chip.Acc.Write(chip.Acc.Read() - source.Read());
//                 return OperationResult.Advance;
//             }
//             return OperationResult.Block;
//         }
//     }
// }
