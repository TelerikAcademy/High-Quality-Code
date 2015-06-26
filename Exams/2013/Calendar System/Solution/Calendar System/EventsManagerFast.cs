// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EventsManagerFast.cs" company="Telerik">
//   Telerik Academy 2013
// </copyright>
// <summary>
//   A fast implementation of IEventsManager using MultiDictionary and OrderedMultiDictionary as data structures.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace CalendarSystem
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Wintellect.PowerCollections;

    /// <summary>
    /// A fast implementation of IEventsManager using MultiDictionary and OrderedMultiDictionary as data structures.
    /// </summary>
    public class EventsManagerFast : IEventsManager
    {
        /// <summary>
        /// A MultiDictionary containing all events for fast access by title
        /// </summary>
        private readonly MultiDictionary<string, Event> eventsByTitle = new MultiDictionary<string, Event>(true);

        /// <summary>
        /// A OrderedMultiDictionary containing all events for fast access by date range
        /// </summary>
        private readonly OrderedMultiDictionary<DateTime, Event> eventsByDate = new OrderedMultiDictionary<DateTime, Event>(true);

        /// <summary>
        /// Adds an event to the list of events.
        /// If the event already exists, it is added again (duplicates are accepted).
        /// </summary>
        /// <param name="event">The event to be added.</param>
        public void AddEvent(Event @event)
        {
            if (@event == null)
            {
                throw new ArgumentNullException("event");
            }

            string eventTitleLowerCase = @event.Title.ToLowerInvariant();
            this.eventsByTitle.Add(eventTitleLowerCase, @event);
            this.eventsByDate.Add(@event.Date, @event);
        }

        /// <summary>
        /// Deletes all events matching given title in case insensitive manner
        /// </summary>
        /// <param name="eventTitle">The title of the events that should be deleted</param>
        /// <returns>The number of deleted events</returns>
        public int DeleteEventsByTitle(string eventTitle)
        {
            if (eventTitle == null)
            {
                throw new ArgumentNullException("eventTitle");
            }

            string eventTitleLowerCase = eventTitle.ToLowerInvariant();
            var eventsToDelete = this.eventsByTitle[eventTitleLowerCase];
            int deletedCount = eventsToDelete.Count;

            // Delete from this.eventsByDate
            foreach (var e in eventsToDelete)
            {
                this.eventsByDate.Remove(e.Date, e);
            }

            // Delete from this.eventsByTitle
            this.eventsByTitle.Remove(eventTitleLowerCase);

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
                from e in this.eventsByDate.RangeFrom(date, true).Values
                select e;
            var limitedMatchedEvents = matchedEvents.Take(count);
            return limitedMatchedEvents;
        }
    }
}
