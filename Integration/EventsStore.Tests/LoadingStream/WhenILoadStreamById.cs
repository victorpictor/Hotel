using System;
using System.Collections.Generic;
using Core.BookingProcess;
using Core.Markers;
using EventsStore.StreamReader;
using NUnit.Framework;

namespace EventsStore.Tests.LoadingStream
{
    [TestFixture]
    public class WhenILoadStreamOf3EventsById : HasMongoSetUp
    {
        private Guid Id;
        private List<IEvent> eventSource;


        public override void Given()
        {
            Id = Guid.NewGuid();

            var events = database.GetCollection("Events");

            events.Save(new EventDescriptor(new NewReservation(){Id = Id}));
            events.Save(new EventDescriptor(new AppliedHoldOnRoom() { Id = Id }));
            events.Save(new EventDescriptor(new RoomPriced() { Id = Id }));
        }

        public override void When()
        {
            eventSource = new EventStore().LoadStream(Id);
        }

        [Test]
        public void It_should_return_the_stream_of_3_events()
        {
            Assert.AreEqual(3,eventSource.Count);
        }
    }
}