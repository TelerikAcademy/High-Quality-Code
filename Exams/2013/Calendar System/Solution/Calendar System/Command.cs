// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Command.cs" company="Telerik">
//   Telerik Academy 2013
// </copyright>
// <summary>
//   Class representing a single command with name and arguments
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace CalendarSystem
{
    using System;

    /// <summary>
    /// Class representing a single command with name and arguments
    /// </summary>
    public struct Command
    {
        /// <summary>
        /// Gets or sets the name of the command
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the arguments of the command
        /// </summary>
        public string[] Arguments { get; set; }

        /// <summary>
        /// Converts string to an instance of command
        /// </summary>
        /// <param name="commandText">A string representing the command</param>
        /// <returns>Parsed command</returns>
        public static Command Parse(string commandText)
        {
            if (commandText == null)
            {
                throw new ArgumentNullException("commandText");
            }

            int spaceIndex = commandText.IndexOf(' ');
            if (spaceIndex == -1)
            {
                throw new ArgumentException("Invalid command: " + commandText);
            }

            string commandName = commandText.Substring(0, spaceIndex);
            string argumentsString = commandText.Substring(spaceIndex + 1);

            var commandArguments = argumentsString.Split('|');
            for (int i = 0; i < commandArguments.Length; i++)
            {
                commandArguments[i] = commandArguments[i].Trim();
            }

            var command = new Command { Name = commandName, Arguments = commandArguments };

            return command;
        }
    }
}
