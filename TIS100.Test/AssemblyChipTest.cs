using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using TIS100.Operations;

namespace TIS100.Test {
    [TestClass]
    public class AssemblyChipTest {
        public InputStream GetStream() {
            return new InputStream(new List<int>() {
                1, 2, 3
            });
        }

        [TestMethod]
        public void ReadInputSteam_Works() {
            var operations = new List<IOperation>() {
                new Mov(new Up(), new Acc())
            };
            var chip = new AssemblyChip(GetStream(), null, null, null, operations);

            chip.Execute();

            Assert.AreEqual(1, chip.Acc.Value);
        }

        [TestMethod]
        public void OperationWrapAround_Works() {
            var operations = new List<IOperation>() {
                new Mov(new Up(), new Acc())
            };
            var chip = new AssemblyChip(GetStream(), null, null, null, operations);

            chip.Execute();
            chip.Execute();

            Assert.AreEqual(2, chip.Acc.Value);
        }
    }
}
