// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CommandProcessor.cs" company="Telerik">
//   Telerik Academy 2013
// </copyright>
// <summary>
//   An implementation of ICommandProcessor.
//   Class for processing commands
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace CalendarSystem
{
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// An implementation of ICommandProcessor.
    /// Class for processing commands
    /// </summary>
    public class CommandProcessor
    {
        /// <summary>
        /// Constant holding the command name for adding events
        /// </summary>
        public const string AddEventCommandName = "AddEvent";

        /// <summary>
        /// Constant holding the command name for deleting events
        /// </summary>
        public const string DeleteEventCommandName = "DeleteEvents";

        /// <summary>
        /// Constant holding the command name for listing events
        /// </summary>
        public const string ListEventCommandName = "ListEvents";

        /// <summary>
        /// Private instance of an IEventsProcessor
        /// </summary>
        private readonly IEventsManager eventsManager;

        /// <summary>
        /// Initializes a new instance of the <see cref="CommandProcessor"/> class by given an instance of events manager.
        /// </summary>
        /// <param name="eventsManager">
        /// An instance of IEventsProcessor
        /// </param>
        public CommandProcessor(IEventsManager eventsManager)
        {
            this.eventsManager = eventsManager;
        }

        /// <summary>
        /// Gets the events processor used by the command processor
        /// </summary>
        public IEventsManager EventsProcessor
        {
            get
            {
                return this.eventsManager;
            }
        }

        /// <summary>
        /// Process a command using an event processor
        /// </summary>
        /// <param name="command">The command to process</param>
        /// <returns>String representing the result of command processing</returns>
        public string ProcessCommand(Command command)
        {
            if ((command.Name == AddEventCommandName) && (command.Arguments.Length == 2))
            {
                var date = DateTime.ParseExact(command.Arguments[0], Event.DateFormat, CultureInfo.InvariantCulture);
                return this.ProcessAddEventCommand(date, command.Arguments[1]);
            }

            if ((command.Name == AddEventCommandName) && (command.Arguments.Length == 3))
            {
                var date = DateTime.ParseExact(command.Arguments[0], Event.DateFormat, CultureInfo.InvariantCulture);
                return this.ProcessAddEventCommand(date, command.Arguments[1], command.Arguments[2]);
            }

            if ((command.Name == DeleteEventCommandName) && (command.Arguments.Length == 1))
            {
                return this.ProcessDeleteEventsCommand(command.Arguments[0]);
            }

            if ((command.Name == ListEventCommandName) && (command.Arguments.Length == 2))
            {
                var date = DateTime.ParseExact(command.Arguments[0], Event.DateFormat, CultureInfo.InvariantCulture);
                var count = int.Parse(command.Arguments[1]);
                return this.ProcessListEventsCommand(date, count);
            }

            throw new ArgumentException("Unknown command: " + command.Name);
        }

        /// <summary>
        /// Process the command for adding events by given data and time, title and optional location
        /// </summary>
        /// <param name="date">Event date</param>
        /// <param name="title">Event title</param>
        /// <param name="location">Event location</param>
        /// <returns>Successful message string if everything is OK</returns>
        private string ProcessAddEventCommand(DateTime date, string title, string location = null)
        {
            var @event = new Event
                          {
                              Date = date,
                              Title = title,
                              Location = location,
                          };

            this.eventsManager.AddEvent(@event);

            return "Event added";
        }

        /// <summary>
        /// Process the command for deleting events
        /// </summary>
        /// <param name="eventTitle">The title of the event to be deleted</param>
        /// <returns>Message string representing the result of the deletion</returns>
        private string ProcessDeleteEventsCommand(string eventTitle)
        {
            int deletedCount = this.eventsManager.DeleteEventsByTitle(eventTitle);

            if (deletedCount == 0)
            {
                return "No events found";
            }

            return deletedCount + " events deleted";
        }

        /// <summary>
        /// Process the command for listing events
        /// </summary>
        /// <param name="date">The date to start search from</param>
        /// <param name="count">The count of events to list</param>
        /// <returns>Message string representing the list of the events</returns>
        private string ProcessListEventsCommand(DateTime date, int count)
        {
            var events = this.eventsManager.ListEvents(date, count).ToList();
            var result = new StringBuilder();

            if (!events.Any())
            {
                return "No events found";
            }

            foreach (var @event in events)
            {
                result.AppendLine(@event.ToString());
            }

            return result.ToString().Trim();
        }
    }
}