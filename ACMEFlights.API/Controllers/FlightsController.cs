using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ACMEFlights.Core.Interfaces;
using ACMEFlights.Core.Model;

namespace ACMEFlights.API.Controllers
{
    public class FlightsController : ApiController
    {
        private readonly IFlightAvailabilityService _availabilityService;

        public FlightsController(IFlightAvailabilityService availabilityService)
        {
            _availabilityService = availabilityService;
        }

        [Route("flights/availability")]
        public List<FlightAvailability> GetAvailability([FromUri]SearchRequest searchRequest)
        {
            return _availabilityService.GetAvailability(searchRequest);
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
