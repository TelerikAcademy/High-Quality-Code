namespace Computers.Tests.Cpu
{
    using Computers.Common.Components;
    using Computers.Tests.Mocks;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;

    [TestClass]
    public class SquareNumberTests
    {
        private Cpu cpu;

        [TestMethod]
        public void CpuShouldReturnSquareNumberIfValueIsInRange()
        {
            var value = 20;
            var expectedMessage = string.Format("Square of {0} is {1}.", value, value * value);
            this.AssertCpuMessage(value, expectedMessage, c => new Cpu32Bit(c));
        }

        [TestMethod]
        public void CpuShouldReturnTooLowMessageWithNegativeNumber()
        {
            var value = -20;
            var expectedMessage = "Number too low.";
            this.AssertCpuMessage(value, expectedMessage, c => new Cpu32Bit(c));
        }

        [TestMethod]
        public void CpuShouldReturnTooHighOn32Bit()
        {
            var value = 501;
            var expectedMessage = "Number too high.";
            this.AssertCpuMessage(value, expectedMessage, c => new Cpu32Bit(c));
        }

        [TestMethod]
        public void CpuShouldReturnTooHighOn64Bit()
        {
            var value = 1001;
            var expectedMessage = "Number too high.";
            this.AssertCpuMessage(value, expectedMessage, c => new Cpu64Bit(c));
        }

        [TestMethod]
        public void CpuShouldReturnTooHighOn128Bit()
        {
            var value = 2001;
            var expectedMessage = "Number too high.";
            this.AssertCpuMessage(value, expectedMessage, c => new Cpu128Bit(c));
        }

        private void AssertCpuMessage<TCpu>(int value, string expectedMessage, Func<byte, TCpu> cpuConstructor) where TCpu : Cpu
        {
            var result = string.Empty;

            this.cpu = cpuConstructor(2);
            this.cpu.Motherboard = MotherboardMock.GetDrawable(value, sqNumberMessage => result = sqNumberMessage);
            this.cpu.SquareNumber();

            Assert.AreEqual(expectedMessage, result);
        }
    }
}
