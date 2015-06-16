 using System;
 using System.Collections.Generic;
 using System.Linq;
 using System.Text;
 using System.Threading.Tasks;
 using TIS100.Chips;
using TIS100.RWs;

 namespace TIS100.Operations {
     public class Add : IOperation {
         public RWRef Source { get; private set; }

         public Add(RWRef source) {
             this.Source = source;
         }

         public IOperationResult Execute(AssemblyChip chip) {
             var source = Source.Reference(chip);

             if (source.IsReadyToRead()) {
                 chip.Acc.Write(chip.Acc.Read() + source.Read());
                 return OperationResult.Advance;
             }
             return OperationResult.Block;
         }
     }
 }
