// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IEventsManager.cs" company="Telerik">
//   Telerik Academy 2013
// </copyright>
// <summary>
//   Defines an events manager interface
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace CalendarSystem
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Defines an events manager interface.
    /// </summary>
    public interface IEventsManager
    {
        /// <summary>
        /// Adds an event to the list of events.
        /// If the event already exists, it is added again (duplicates are accepted).
        /// </summary>
        /// <param name="event">The event to be added.</param>
        void AddEvent(Event @event);

        /// <summary>
        /// Deletes all events matching given title in case insensitive manner
        /// </summary>
        /// <param name="eventTitle">The title of the events that should be deleted</param>
        /// <returns>The number of deleted events</returns>
        int DeleteEventsByTitle(string eventTitle);

        /// <summary>
        /// Returns a list of events starting from the given date and time
        /// The number of the listed events should be the given <paramref name="count"/> or less (if not enough events are available).
        /// </summary>
        /// <param name="date">Starting date for events list</param>
        /// <param name="count">The max number of events to be returned</param>
        /// <returns>The list of events</returns>
        IEnumerable<Event> ListEvents(DateTime date, int count);
    }
}