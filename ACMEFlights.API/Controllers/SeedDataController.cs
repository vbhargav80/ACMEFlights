using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ACMEFlights.Core.Interfaces;

namespace ACMEFlights.API.Controllers
{
    public class SeedDataController : ApiController
    {
        private readonly IRepository _repository;

        public SeedDataController(IRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        [Route("seeddata/flights")]
        public string SeedFlightData()
        {
            _repository.SeedFlightData();
            return "Done";
        }

        [HttpGet]
        [Route("seeddata/flightbookings")]
        public string SeedFlightBookingData()
        {
            _repository.SeedFlightBookingData();
            return "Done";
        }
    }
}
