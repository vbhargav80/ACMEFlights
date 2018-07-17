using System;

namespace ACMEFlights.Core.Model
{
    public class SearchRequest
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int NumberOfPassengers { get; set; }
    }
}
