 using System;
 using System.Collections.Generic;
 using System.Linq;
 using System.Text;
 using System.Threading.Tasks;
 using TIS100.Chips;

 namespace TIS100.Operations {
     public class Jgz : IOperation {
        public int Ip { get; set; }

         public Jgz(int ip) {
             this.Ip = ip;
         }

         public IOperationResult Execute(AssemblyChip chip) {
             if (chip.Acc.Read().ToInteger() > 0) {
                 chip.Ip = Ip;
                 return OperationResult.Jump;
             }

             return OperationResult.Advance;
         }
     }
 }
