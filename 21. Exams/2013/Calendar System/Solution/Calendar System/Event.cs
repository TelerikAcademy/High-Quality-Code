// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Event.cs" company="Telerik">
//   Telerik Academy 2013
// </copyright>
// <summary>
//   Class representing information for events.
//   Each event has date, time, title and location.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace CalendarSystem
{
    using System;

    /// <summary>
    /// Class representing information for events.
    /// Each event has date, time, title and location.
    /// </summary>
    public class Event : IComparable<Event>
    {
        /// <summary>
        /// Represents the date format when converting event to string. This field is constant.
        /// </summary>
        public const string DateFormat = "yyyy-MM-ddTHH:mm:ss";

        /// <summary>
        /// Gets or sets the date of the event
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// Gets or sets the title of the event
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the location of the event
        /// </summary>
        public string Location { get; set; }

        /// <summary>
        /// Converts the event to its equivalent string representation.
        /// </summary>
        /// <returns>The string representation of the value of this instance</returns>
        public override string ToString()
        {
            string eventFormat = "{0:" + DateFormat + "} | {1}";
            if (this.Location != null)
            {
                eventFormat += " | {2}";
            }

            string eventAsString = string.Format(eventFormat, this.Date, this.Title, this.Location);
            return eventAsString;
        }

        /// <summary>
        /// Compares the current event with another event.
        /// </summary>
        /// <param name="other">An event to compare with this event.</param>
        /// <returns>
        /// A value that indicates the relative order of the objects being compared. The return value has the following meanings:
        /// Less than zero: This object is less than the <paramref name="other"/> parameter.
        /// Zero: This object is equal to <paramref name="other"/>.
        /// Greater than zero: This object is greater than <paramref name="other"/>.
        /// </returns>
        public int CompareTo(Event other)
        {
            int compareResult = DateTime.Compare(this.Date, other.Date);
            if (compareResult == 0)
            {
                compareResult = string.Compare(this.Title, other.Title, StringComparison.InvariantCulture);
            }

            if (compareResult == 0)
            {
                compareResult = string.Compare(this.Location, other.Location, StringComparison.InvariantCulture);
            }

            return compareResult;
        }
    }
}