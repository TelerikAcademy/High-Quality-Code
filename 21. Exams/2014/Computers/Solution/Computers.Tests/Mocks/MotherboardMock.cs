namespace Computers.Tests.Mocks
{
    using System;

    using Computers.Common.Components;

    using Moq;

    public static class MotherboardMock
    {
        public static IMotherboard GetDrawable(int ramValue, Action<string> drawOnVideoCardAction)
        {
            var motherBoardMock = new Mock<IMotherboard>();
            motherBoardMock.Setup(m => m.LoadRamValue()).Returns(ramValue);
            motherBoardMock.Setup(m => m.SaveRamValue(It.IsAny<int>())).Verifiable();
            motherBoardMock.Setup(m => m.DrawOnVideoCard(It.IsAny<string>())).Callback(drawOnVideoCardAction);
            return motherBoardMock.Object;
        }

        public static IMotherboard GetSaveableInRam(Action<int> saveInRam)
        {
            var motherBoardMock = new Mock<IMotherboard>();
            motherBoardMock.Setup(m => m.LoadRamValue()).Verifiable();
            motherBoardMock.Setup(m => m.SaveRamValue(It.IsAny<int>())).Callback(saveInRam);
            motherBoardMock.Setup(m => m.DrawOnVideoCard(It.IsAny<string>())).Verifiable();
            return motherBoardMock.Object;
        }
    }
}
