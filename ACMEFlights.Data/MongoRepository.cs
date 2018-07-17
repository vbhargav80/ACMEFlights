using System;
using System.Collections.Generic;
using System.Configuration;
using ACMEFlights.Core.Interfaces;
using ACMEFlights.Core.Model;
using MongoDB.Driver;

namespace ACMEFlights.Data
{
    public class MongoRepository : IRepository
    {
        private readonly MongoClient _mongoClient;
        private readonly string _connectionString;
        private readonly string _databaseName;

        public MongoRepository()
        {
            _connectionString = ConfigurationManager.AppSettings["MongoConnectionString"];
            _mongoClient = new MongoClient(_connectionString);
            _databaseName = "Acme";
        }

        public List<FlightBooking> GetBookings(DateTime startDate, DateTime endDate)
        {
            var db = _mongoClient.GetDatabase(_databaseName);
            var collection = db.GetCollection<FlightBooking>("FlightBookings");
            return collection.Find(a => a.DepartureTime >= startDate && a.ArrivalTime <= endDate).ToList();
        }

        public List<Flight> GetFlights()
        {
            var db = _mongoClient.GetDatabase(_databaseName);
            var collection = db.GetCollection<Flight>("Flights");
            return collection.Find(Builders<Flight>.Filter.Empty).ToList();
        }

        public void SeedFlightData()
        {
            var flight = new Flight()
            {
                Id = "RapidRoute1",
                Name = "Rapid Route",
                DepartsAtHourOfDay = 9,
                Duration = TimeSpan.FromHours(2),
                PassengerCapacity = 6
            };

            var db = _mongoClient.GetDatabase(_databaseName);
            var collection = db.GetCollection<Flight>("Flights");
            collection.ReplaceOne(p => p.Id == flight.Id, flight, new UpdateOptions { IsUpsert = true });
        }

        public void SeedFlightBookingData()
        {
            var flightBooking1 = new FlightBooking()
            {
                Id = "FlightBooking1",
                FlightId = "RapidRoute1",
                DepartureTime = new DateTime(2018, 7, 18, 9, 0, 0),
                ArrivalTime = new DateTime(2018, 7, 18, 11, 0, 0),
                NumberOfPassengers = 2
            };

            var db = _mongoClient.GetDatabase(_databaseName);
            var collection = db.GetCollection<FlightBooking>("FlightBookings");
            collection.ReplaceOne(p => p.Id == flightBooking1.Id, flightBooking1, new UpdateOptions { IsUpsert = true });

            var flightBooking2 = new FlightBooking()
            {
                Id = "FlightBooking2",
                FlightId = "RapidRoute1",
                DepartureTime = new DateTime(2018, 7, 24, 9, 0, 0),
                ArrivalTime = new DateTime(2018, 7, 24, 11, 0, 0),
                NumberOfPassengers = 5
            };

            collection.ReplaceOne(p => p.Id == flightBooking2.Id, flightBooking2, new UpdateOptions { IsUpsert = true });
        }
    }
}
