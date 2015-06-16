 using System;
 using System.Collections.Generic;
 using System.Linq;
 using System.Text;
 using System.Threading.Tasks;
 using TIS100.Chips;
using TIS100.RWs;

 namespace TIS100.Operations {
     public class Jro : IOperation {
         public RWRef Source { get; set; }

         public Jro(RWRef source) {
             this.Source = source;
         }

         public IOperationResult Execute(AssemblyChip chip) {
             var rw = Source.Reference(chip);

             if (rw.IsReadyToRead()) {
                 chip.Ip += rw.Read().ToInteger();
                 return OperationResult.Jump;
             }

             return OperationResult.Block;
         }
     }
 }
