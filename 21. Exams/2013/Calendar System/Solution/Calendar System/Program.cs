// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Program.cs" company="Telerik">
//   Telerik Academy 2013
// </copyright>
// <summary>
//   Class containing a program that executes a sequence of commands
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace CalendarSystem
{
    using System;
    using System.Text;

    /// <summary>
    /// Class containing a program that executes a sequence of commands
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// Constant representing the end command
        /// </summary>
        private const string EndCommandString = "End";

        /// <summary>
        /// Entry point of the application
        /// </summary>
        internal static void Main()
        {
            var eventsManager = new EventsManagerFast();
            var processor = new CommandProcessor(eventsManager);
            var output = new StringBuilder();

            while (true)
            {
                string commandText = Console.ReadLine();
                if (commandText == EndCommandString || commandText == null)
                {
                    // The sequence of commands is finished
                    break;
                }

                try
                {
                    var command = Command.Parse(commandText);
                    var result = processor.ProcessCommand(command);
                    output.AppendLine(result);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    break;
                }
            }

            Console.WriteLine(output);
        }
    }
}
