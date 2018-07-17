using System;
using System.Collections.Generic;
using ACMEFlights.Core.Model;

namespace ACMEFlights.Core.Interfaces
{
    public interface IRepository
    {
        List<FlightBooking> GetBookings(DateTime startDate, DateTime endDate);
        List<Flight> GetFlights();

        void SeedFlightData();
        void SeedFlightBookingData();
    }
}
