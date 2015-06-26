namespace Computers.Tests.LaptopBattery
{
    using Computers.Common.Components;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class LaptopBatteryTests
    {
        private LaptopBattery battery;

        [TestInitialize]
        public void LaptopBatteryInitialize()
        {
            this.battery = new LaptopBattery();
        }

        [TestMethod]
        public void LaptopBatteryShouldHaveHalfChargeInitially()
        {
            this.AssertChargePercentage(50);
        }

        [TestMethod]
        public void LaptopBatteryShouldChargeItselfWithPositiveNumber()
        {
            this.battery.Charge(25);
            this.AssertChargePercentage(75);
        }

        [TestMethod]
        public void LaptopBatteryShouldDechargeItselfWithNegativeNumber()
        {
            this.battery.Charge(-25);
            this.AssertChargePercentage(25);
        }

        [TestMethod]
        public void LaptopBatteryShouldNotHaveMoreThanOneHundredPercentageCharge()
        {
            this.battery.Charge(1000);
            this.AssertChargePercentage(100);
        }

        [TestMethod]
        public void LaptopBatteryShouldNotHaveLessThanZeroPercentageCharge()
        {
            this.battery.Charge(-1000);
            this.AssertChargePercentage(0);
        }

        private void AssertChargePercentage(int expectedCharge)
        {
            Assert.AreEqual(expectedCharge, this.battery.Percentage);
        }
    }
}
