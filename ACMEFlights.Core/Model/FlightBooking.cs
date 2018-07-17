using System;

namespace ACMEFlights.Core.Model
{
    public class FlightBooking
    {
        public string Id { get; set; }
        public string FlightId { get; set; }
        public DateTime DepartureTime { get; set; }
        public DateTime ArrivalTime { get; set; }
        public int NumberOfPassengers { get; set; }
    }
}
