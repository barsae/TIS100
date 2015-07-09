using System;
using System.Collections.Generic;

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
        public void Upper_Limit_Is_999()
        {
            var board = new Board();
            var chip = new AssemblyChip();
            var input = new InputRW(new List<int>{999,1});
            var output = new OutputRW();

            chip.Operations = new List<IOperation>
            {
                new Mov(UP,ACC),
                new Add(UP),
                new Mov(ACC, DOWN)
            };

            board.Install(chip, new Point(0,0));
            chip.Connections[UP.RefName] = input;
            chip.Connections[DOWN.RefName] = output;

            board.ExecuteUntilBlocked();

            Assert.AreEqual("999", output.ToString());
        }

        [TestMethod]
        public void Lower_Limit_Is_Minus999()
        {
            var board = new Board();
            var chip = new AssemblyChip();
            var input = new InputRW(new List<int> { -999, -1 });
            var output = new OutputRW();

            chip.Operations = new List<IOperation>
            {
                new Mov(UP,ACC),
                new Add(UP),
                new Mov(ACC, DOWN)
            };

            board.Install(chip, new Point(0, 0));
            chip.Connections[UP.RefName] = input;
            chip.Connections[DOWN.RefName] = output;

            board.ExecuteUntilBlocked();

            Assert.AreEqual("-999", output.ToString());
        }
    }
}