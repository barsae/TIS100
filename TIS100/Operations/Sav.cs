 using System;
 using System.Collections.Generic;
 using System.Linq;
 using System.Text;
 using System.Threading.Tasks;
 using TIS100.Chips;

 namespace TIS100.Operations {
     public class Sav : IOperation {
         public Sav() {
         }

         public IOperationResult Execute(AssemblyChip chip) {
             chip.Bak.Write(chip.Acc.Read());
             return OperationResult.Advance;
         }

         public override string ToString() {
             return "SWP";
         }
     }
 }
