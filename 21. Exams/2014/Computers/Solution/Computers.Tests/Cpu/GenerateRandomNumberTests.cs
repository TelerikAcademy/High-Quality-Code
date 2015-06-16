namespace Computers.Tests.Cpu
{
    using Computers.Common.Components;
    using Computers.Tests.Mocks;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Collections.Generic;

    [TestClass]
    public class GenerateRandomNumberTests
    {
        private Cpu cpu;
        private int random;

        [TestInitialize]
        public void CpuInitialize()
        {
            this.cpu = new Cpu32Bit(2);
            this.cpu.Motherboard = MotherboardMock.GetSaveableInRam(s => this.random = s);
        }

        [TestMethod]
        public void CpuShouldAlwaysReturnRandomNumberBelowOrEqualToTheMaxValue()
        {
            int minValue = 0;
            int maxValue = 1000;
            for (int i = 0; i < 1000; i++)
            {
                cpu.GenerateRandomNumber(minValue, maxValue);
                var result = this.random <= maxValue;
                Assert.IsTrue(result);
            }
        }

        [TestMethod]
        public void CpuShouldAlwaysReturnRandomNumberAboveOrEqualToTheMinimumValue()
        {
            int minValue = 0;
            int maxValue = 1000;
            for (int i = 0; i < 1000; i++)
            {
                cpu.GenerateRandomNumber(minValue, maxValue);
                var result = this.random >= minValue;
                Assert.IsTrue(result);
            }
        }

        [TestMethod]
        public void CpuShouldAlwaysReturnRandomNumberInRange()
        {
            int minValue = 1;
            int maxValue = 1;
            for (int i = 0; i < 1000; i++)
            {
                cpu.GenerateRandomNumber(minValue, maxValue);
                var result = minValue <= this.random && this.random <= maxValue;
                Assert.IsTrue(result);
            }
        }

        [TestMethod]
        public void CpuShouldAlmostAlwaysReturnDifferentRandomNumber()
        {
            int minValue = 0;
            int maxValue = 1000;
            var counts = new Dictionary<int, int>();

            for (int i = 0; i < 1000; i++)
            {
                cpu.GenerateRandomNumber(minValue, maxValue);
                if (!counts.ContainsKey(this.random))
                {
                    counts[random] = 0;
                }

                counts[random]++;
            }

            foreach (var keyValuePair in counts)
            {
                // we check whether a random number has repeated no more than ten times in 1 000 tries (fair enough - less than 1%)
                var result = keyValuePair.Value < 10;
                Assert.IsTrue(result);
            }
        }
    }
}
