// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EventsManagerSlow.cs" company="Telerik">
//   Telerik Academy 2013
// </copyright>
// <summary>
//   A slow implementation of IEventsManager using List as data structure.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace CalendarSystem
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// A slow implementation of IEventsManager using List as data structure.
    /// </summary>
    public class EventsManagerSlow : IEventsManager
    {
        /// <summary>
        /// A list of events
        /// </summary>
        private readonly List<Event> events = new List<Event>();

        /// <summary>
        /// Adds an event to the list of events.
        /// If the event already exists, it is added again (duplicates are accepted).
        /// </summary>
        /// <param name="event">The event to be added.</param>
        public void AddEvent(Event @event)
        {
            this.events.Add(@event);
        }

        /// <summary>
        /// Deletes all events matching given title in case insensitive manner
        /// </summary>
        /// <param name="eventTitle">The title of the events that should be deleted</param>
        /// <returns>The number of deleted events</returns>
        public int DeleteEventsByTitle(string eventTitle)
        {
            string eventTitleLower = eventTitle.ToLowerInvariant();
            int deletedCount = this.events.RemoveAll(
                e => e.Title.ToLowerInvariant() == eventTitleLower);
            return deletedCount;
        }

        /// <summary>
        /// Returns a list of events starting from the given date and time
        /// The number of the listed events should be the given <paramref name="count"/> or less (if not enough events are available).
        /// </summary>
        /// <param name="date">Starting date for events list</param>
        /// <param name="count">The max number of events to be returned</param>
        /// <returns>The list of events</returns>
        public IEnumerable<Event> ListEvents(DateTime date, int count)
        {
            var matchedEvents =
                from e in this.events
                where e.Date >= date
                orderby e.Date, e.Title, e.Location
                select e;
            var limitedMatchedEvents = matchedEvents.Take(count);
            return limitedMatchedEvents;
        }
    }
}