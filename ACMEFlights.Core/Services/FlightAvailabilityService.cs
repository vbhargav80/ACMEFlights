using System;
using System.Collections.Generic;
using System.Linq;
using ACMEFlights.Core.Interfaces;
using ACMEFlights.Core.Model;

namespace ACMEFlights.Core.Services
{
    public class FlightAvailabilityService : IFlightAvailabilityService
    {
        private readonly IRepository _repository;

        public FlightAvailabilityService(IRepository repository)
        {
            _repository = repository;
        }

        public List<FlightAvailability> GetAvailability(SearchRequest searchRequest)
        {
            var existingBookings = _repository.GetBookings(searchRequest.StartDate, searchRequest.EndDate);
            var allFlights = _repository.GetFlights();

            var date = searchRequest.StartDate;
            var availabilities = new List<FlightAvailability>();
            while (date < searchRequest.EndDate)
            {
                foreach (var flight in allFlights)
                {
                    var hasAvailability = HasAvailabilityOn(
                        date, 
                        searchRequest.NumberOfPassengers, 
                        flight, 
                        existingBookings
                        );

                    if (hasAvailability)
                    {
                        var departureTime = date.Date.AddHours(flight.DepartsAtHourOfDay);
                        availabilities.Add(new FlightAvailability()
                        {
                            DepartureTime = departureTime,
                            ArrivalTime = departureTime + flight.Duration,
                            FlightId = flight.Id,
                            FlightName = flight.Name
                        });
                    }
                }

                date = date.AddDays(1);
            }
            
            return availabilities;
        }

        public bool HasAvailabilityOn(
            DateTime dateOfBooking, 
            int numberOfPassengers, 
            Flight flight,
            List<FlightBooking> existingBookings)
        {
            var existingBooking = existingBookings
                .FirstOrDefault(a => a.FlightId == flight.Id && a.DepartureTime.ToLocalTime().Date == dateOfBooking.Date);

            if (existingBooking == null && flight.PassengerCapacity >= numberOfPassengers)
            {
                return true;
            }

            if (existingBooking != null)
            {
                var remainingCapacity = flight.PassengerCapacity - existingBooking.NumberOfPassengers;
                if (remainingCapacity >= numberOfPassengers)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
