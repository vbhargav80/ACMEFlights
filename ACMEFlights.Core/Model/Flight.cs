using System;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;

namespace ACMEFlights.Core.Model
{
    public class Flight
    {
        [BsonId(IdGenerator = typeof(StringObjectIdGenerator))]
        public string Id { get; set; }
        public string Name { get; set; }
        public int PassengerCapacity { get; set; }
        public int DepartsAtHourOfDay { get; set; }
        public TimeSpan Duration { get; set; }
    }
}
