﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TIS100.Chips;
using TIS100.RWs;
using System.Collections.Generic;
using TIS100.Operations;

namespace TIS100.Test {
    [TestClass]
    public class MovTest {
        [TestMethod]
        public void Mov_Basic_Works() {
            var board = new Board();
            var chip = new AssemblyChip();
            var input = new InputRW(new List<int>() { 1, 2, 3 });
            var output = new OutputRW();

            chip.Operations = new List<IOperation>() {
                new Mov(new ConnectionRef("UP"), new ConnectionRef("DOWN"))
            };

            board.Install(chip, new Point(0, 0));
            chip.Connections["UP"] = input;
            chip.Connections["DOWN"] = output;

            board.ExecuteUntilBlocked();

            Assert.AreEqual("1, 2, 3", output.ToString());
        }
    }
}
