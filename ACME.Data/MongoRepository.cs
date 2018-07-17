using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ACMEFlights.Core.Interfaces;
using ACMEFlights.Core.Model;
using MongoDB.Driver;

namespace ACME.Data
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
            throw new NotImplementedException();
        }

        public List<Flight> GetFlights()
        {
            throw new NotImplementedException();
        }

        public void SeedFlightData()
        {
            var flight = new Flight()
            {
                Name = "Rapid Route",
                FirstFlightAt = new TimeSpan(9, 0, 0),
                LastFlightAt = new TimeSpan(17, 0, 0),
                Duration = TimeSpan.FromHours(1),
                PassengerCapacity = 6
            };

            var db = _mongoClient.GetDatabase(_databaseName);
            var collection = db.GetCollection<Flight>("Flights");
            collection.ReplaceOneAsync(p => p.Id == flight.Id, flight, new UpdateOptions { IsUpsert = true });
        }

        public void SeedFlightBookingData()
        {
            throw new NotImplementedException();
        }
    }
}
