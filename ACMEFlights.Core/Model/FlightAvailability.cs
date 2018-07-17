using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACMEFlights.Core.Model
{
    public class FlightAvailability
    {
        public string FlightId { get; set; }
        public string FlightName { get; set; }
        public DateTime DepartureTime { get; set; }
        public DateTime ArrivalTime { get; set; }
    }
}
