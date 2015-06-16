using Microsoft.VisualStudio.TestTools.UnitTesting;
using CalendarSystem;
using System;
using System.Linq;

namespace Calendar_System_Tests
{
    [TestClass]
    public class EventsManagerFastTests
    {
        private Event sampleEvent = new Event
                                   {
                                       Date = DateTime.Now,
                                       Location = "Telerik Academy",
                                       Title = "High-Quality Code Exam",
                                   };

        #region AddEvent method
        [TestMethod]
        public void AddNormalEvent()
        {
            IEventsManager eventsManager = new EventsManagerFast();
            eventsManager.AddEvent(sampleEvent);
            Assert.AreEqual(1, eventsManager.ListEvents(DateTime.MinValue, int.MaxValue).Count());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddNullEvent()
        {
            IEventsManager eventsManager = new EventsManagerFast();
            eventsManager.AddEvent(null);
        }

        [TestMethod]
        public void AddDuplicateEvents()
        {
            IEventsManager eventsManager = new EventsManagerFast();
            eventsManager.AddEvent(sampleEvent);
            eventsManager.AddEvent(sampleEvent);
            eventsManager.AddEvent(sampleEvent);
            Assert.AreEqual(3, eventsManager.ListEvents(DateTime.MinValue, int.MaxValue).Count());
        }
        #endregion

        #region DeleteEventsByTitle method
        [TestMethod]
        public void DeleteEventsWithGivenTitle()
        {
            IEventsManager eventsManager = new EventsManagerFast();
            eventsManager.AddEvent(sampleEvent);
            eventsManager.DeleteEventsByTitle(sampleEvent.Title);
            Assert.AreEqual(0, eventsManager.ListEvents(DateTime.MinValue, int.MaxValue).Count());
        }

        [TestMethod]
        public void DeleteEventsWithGivenNoMatchingTitle()
        {
            IEventsManager eventsManager = new EventsManagerFast();
            eventsManager.AddEvent(sampleEvent);
            eventsManager.DeleteEventsByTitle("High");
            Assert.AreEqual(1, eventsManager.ListEvents(DateTime.MinValue, int.MaxValue).Count());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void DeleteEventsWithNullTitle()
        {
            IEventsManager eventsManager = new EventsManagerFast();
            eventsManager.DeleteEventsByTitle(null);
        }

        [TestMethod]
        public void DeleteEventsByCaseInsensitiveTitle()
        {
            IEventsManager eventsManager = new EventsManagerFast();
            eventsManager.AddEvent(new Event { Date = DateTime.Now, Location = "Telerik Academy", Title = "High-Quality Code Exam", });
            eventsManager.AddEvent(new Event { Date = DateTime.Now, Location = "Telerik Academy", Title = "HIGH-Quality CODE Exam", });
            eventsManager.DeleteEventsByTitle("HIGH-Quality CODE Exam".ToLower());
            Assert.AreEqual(0, eventsManager.ListEvents(DateTime.MinValue, int.MaxValue).Count());
        }
        #endregion

        #region ListEvents method
        [TestMethod]
        public void ListEventsByDate()
        {
            IEventsManager eventsManager = new EventsManagerFast();
            eventsManager.AddEvent(new Event { Date = new DateTime(2013, 05, 20, 10, 00, 00), Location = "Telerik Academy", Title = "High-Quality Code Exam Morning", });
            eventsManager.AddEvent(new Event { Date = new DateTime(2013, 05, 20, 16, 30, 00), Location = "Telerik Academy", Title = "High-Quality Code Exam Evening", });
            var dateCriteria = new DateTime(2013, 05, 20, 12, 00, 00);
            var result = eventsManager.ListEvents(dateCriteria, int.MaxValue).ToList();
            Assert.AreEqual(1, result.Count);
            Assert.AreEqual("High-Quality Code Exam Evening", result[0].Title);
        }

        [TestMethod]
        public void ListEventsByDateAndLimitTheOutputCount()
        {
            IEventsManager eventsManager = new EventsManagerFast();
            const int CountLimit = 2;
            eventsManager.AddEvent(new Event { Date = new DateTime(2013, 05, 20, 10, 00, 00), Location = "Telerik Academy", Title = "High-Quality Code Exam", });
            eventsManager.AddEvent(new Event { Date = new DateTime(2013, 05, 20, 16, 30, 00), Location = "Telerik Academy", Title = "High-Quality Code Exam", });
            eventsManager.AddEvent(new Event { Date = new DateTime(2013, 05, 20, 17, 30, 00), Location = "Telerik Academy", Title = "High-Quality Code Exam", });
            eventsManager.AddEvent(new Event { Date = new DateTime(2013, 05, 20, 18, 30, 00), Location = "Telerik Academy", Title = "High-Quality Code Exam", });
            eventsManager.AddEvent(new Event { Date = new DateTime(2013, 05, 20, 19, 30, 00), Location = "Telerik Academy", Title = "High-Quality Code Exam", });
            var dateCriteria = new DateTime(2013, 05, 20, 12, 00, 00);
            Assert.AreEqual(CountLimit, eventsManager.ListEvents(dateCriteria, CountLimit).Count());
        }

        [TestMethod]
        public void NoEventsWillBeListedWithDateFarInTheFuture()
        {
            IEventsManager eventsManager = new EventsManagerFast();
            eventsManager.AddEvent(new Event { Date = new DateTime(2013, 05, 20, 10, 00, 00), Location = "Telerik Academy", Title = "High-Quality Code Exam", });
            eventsManager.AddEvent(new Event { Date = new DateTime(2013, 05, 20, 16, 30, 00), Location = "Telerik Academy", Title = "High-Quality Code Exam", });
            var dateCriteria = DateTime.MaxValue;
            Assert.AreEqual(0, eventsManager.ListEvents(dateCriteria, int.MaxValue).Count());
        }

        [TestMethod]
        public void NoEventsWillBeListedWhenCountIsZero()
        {
            IEventsManager eventsManager = new EventsManagerFast();
            eventsManager.AddEvent(new Event { Date = new DateTime(2013, 05, 20, 10, 00, 00), Location = "Telerik Academy", Title = "High-Quality Code Exam", });
            eventsManager.AddEvent(new Event { Date = new DateTime(2013, 05, 20, 16, 30, 00), Location = "Telerik Academy", Title = "High-Quality Code Exam", });
            var dateCriteria = DateTime.MinValue;
            Assert.AreEqual(0, eventsManager.ListEvents(dateCriteria, 0).Count());
        }
        #endregion
    }
}
