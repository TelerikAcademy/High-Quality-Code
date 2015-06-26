namespace Calendar_System_Tests
{
    using System;

    using CalendarSystem;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class CommandParseTests
    {
        [TestMethod]
        public void CommandWithOneParameter()
        {
            string commandText = "DeleteEvents c# exam";
            var command = Command.Parse(commandText);
            Assert.AreEqual("DeleteEvents", command.Name);
            Assert.AreEqual(1, command.Arguments.Length);
            Assert.AreEqual("c# exam", command.Arguments[0]);
        }

        [TestMethod]
        public void CommandWithMoreThanOneParameters()
        {
            string commandText = "AddEvent 2012-03-07T22:30:00 | party | Club XXX";
            var command = Command.Parse(commandText);
            Assert.AreEqual("AddEvent", command.Name);
            Assert.AreEqual(3, command.Arguments.Length);
            Assert.AreEqual("2012-03-07T22:30:00", command.Arguments[0]);
            Assert.AreEqual("party", command.Arguments[1]);
            Assert.AreEqual("Club XXX", command.Arguments[2]);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CommandWithNoParameters()
        {
            string commandText = "End";
            Command.Parse(commandText);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void NullCommandString()
        {
            string commandText = null;
            Command.Parse(commandText);
        }
    }
}
