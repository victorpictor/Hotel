using System;
using System.Collections.Generic;
using System.Linq;
using Core.BookingProcess;
using Core.Markers;
using EventsStore.StreamReader;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using NUnit.Framework;

namespace EventsStore.Tests.AppendingToStream
{
    [TestFixture]
    public class WhenIAppendAEventToStream : HasMongoSetUp
    {
        private Guid Id;
        private List<IEvent> evs;

        private MongoCollection<EventDescriptor> events;

        public override void Given()
        {
            Id = Guid.NewGuid();

            events = database.GetCollection<EventDescriptor>("Events");

            events.Save(new EventDescriptor(new NewReservation() { Id = Id }));
            events.Save(new EventDescriptor(new AppliedHoldOnRoom() { Id = Id }));
        }

        public override void When()
        {
            new EventStore().AppendToStream(Id, new RoomPriced() { Id = Id });

            evs = events.AsQueryable().Where(ed => ed.StreamId == Id).Select(e => e.Event).ToList();
        }
        
        [Test]
        public void It_should_add_it_to_the_stream()
        {
            Assert.AreEqual(3, evs.Count);
        }
    }
}