 using System;
 using System.Collections;
 using System.Collections.Generic;
 using System.Linq;
 using System.Text;
 using System.Threading.Tasks;
 using TIS100.Chips;
using TIS100.RWs;

 namespace TIS100 {
     public class ConsoleChip : BaseChip {
         public override void Execute() {
         }

         public override RW CustomRW() {
             return new ConsoleRW();
         }
     }
 }
