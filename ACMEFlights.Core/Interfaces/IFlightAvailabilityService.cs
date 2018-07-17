using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ACMEFlights.Core.Model;

namespace ACMEFlights.Core.Interfaces
{
    public interface IFlightAvailabilityService
    {
        List<FlightAvailability> GetAvailability(SearchRequest searchRequest);
    }
}
