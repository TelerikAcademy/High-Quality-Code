namespace Computers.UI.Console
{
    using System;

    using Computers.Common.Factories;

    public class Program
    {
        private const string ExitCommand = "Exit";
        private const string ChargeCommand = "Charge";
        private const string ProcessCommand = "Process";
        private const string PlayCommand = "Play";
        private const string InvalidCommandMessage = "Invalid command!";
        private const string InvalidManufacturerMessage = "Invalid manufacturer!";

        public static void Main()
        {
            var manufacturer = Console.ReadLine();
            var factory = CreateFactory(manufacturer);

            var laptop = factory.CreateLaptop();
            var pc = factory.CreatePc();
            var server = factory.CreateServer();

            while (true)
            {
                var command = Console.ReadLine();
                if (command == null)
                {
                    break;
                }

                if (command.StartsWith(ExitCommand))
                {
                    break;
                }

                var commandParts = command.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                if (commandParts.Length != 2)
                {
                    throw new ArgumentException(InvalidCommandMessage);
                }

                var commandName = commandParts[0];
                var commandArgument = int.Parse(commandParts[1]);

                if (commandName == ChargeCommand)
                {
                    laptop.ChargeBattery(commandArgument);
                }
                else if (commandName == ProcessCommand)
                {
                    server.Process(commandArgument);
                }
                else if (commandName == PlayCommand)
                {
                    pc.Play(commandArgument);
                }
            }
        }

        public static IComputerFactory CreateFactory(string manufacturer)
        {
            IComputerFactory factory;
            if (manufacturer == LenovoFactory.FactoryName)
            {
                factory = new LenovoFactory();
            }
            else if (manufacturer == HpFactory.FactoryName)
            {
                factory = new HpFactory();
            }
            else if (manufacturer == DellFactory.FactoryName)
            {
                factory = new DellFactory();
            }
            else
            {
                throw new ArgumentException(InvalidManufacturerMessage);
            }

            return factory;
        }
    }
}
