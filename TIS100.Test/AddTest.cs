using System;
using System.Collections.Generic;
using System.Linq;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using TIS100.Chips;
using TIS100.Operations;
using TIS100.RWs;

namespace TIS100.Test
{
    [TestClass]
    public class AddTest
    {
        ConnectionRef UP { get { return new ConnectionRef("UP");} }
        ConnectionRef DOWN { get { return new ConnectionRef("DOWN"); } }
        ConnectionRef ACC { get { return new ConnectionRef("ACC"); } }

        [TestMethod]
        public void Addition_Within_Limits_Works()
        {
            var inQueue = new List<int> { 1, -1, 1, 1, -999, 1, -999, 0, 999, -999, 999, -333 };
            var expectedOutQueue = new List<int> { 0, 2, -998, -999, 0, 666 };

            AssertAddOutputMatches(inQueue, expectedOutQueue);
        }

        [TestMethod]
        public void Upper_Limit_Is_999()
        {
            var inQueue = new List<int> { 999, 1 };
            var expectedOutQueue = new List<int> { 999 };

            AssertAddOutputMatches(inQueue, expectedOutQueue);
        }

        [TestMethod]
        public void Lower_Limit_Is_Minus999()
        {
            var inQueue = new List<int> { -999, -1 };
            var expectedOutQueue = new List<int> { -999 };
            AssertAddOutputMatches(inQueue, expectedOutQueue);
        }

        private void AssertAddOutputMatches(List<int> inQueue, List<int> expectedOutQueue)
        {
            var board = new Board();
            var chip = new AssemblyChip();
            var input = new InputRW(inQueue);
            var output = new OutputRW();

            chip.Operations = new List<IOperation>
            {
                new Mov(UP, ACC),
                new Add(UP),
                new Mov(ACC, DOWN)
            };

            board.Install(chip, new Point(0, 0));
            chip.Connections[UP.RefName] = input;
            chip.Connections[DOWN.RefName] = output;

            board.ExecuteUntilBlocked();
            var expectedOutput = expectedOutQueue
                .Select(a => a.ToString())
                .Aggregate((a, b) => a + ", " + b);
            Assert.AreEqual(expectedOutput, output.ToString());
        }
    }
}