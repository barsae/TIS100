 using System;
 using System.Collections.Generic;
 using System.Linq;
 using System.Text;
 using System.Threading.Tasks;
 using TIS100.Chips;

 namespace TIS100.Operations {
     public class Swp : IOperation {
         public Swp() {
         }

         public IOperationResult Execute(AssemblyChip chip) {
             var swap = chip.Acc.Read();
             chip.Acc.Write(chip.Bak.Read());
             chip.Bak.Write(swap);
             return OperationResult.Advance;
         }

         public override string ToString() {
             return "SWP";
         }
     }
 }
