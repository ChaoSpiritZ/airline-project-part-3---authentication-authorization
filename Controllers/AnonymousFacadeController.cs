using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AirlineProject;

namespace AirlineProjectWebAPI.Controllers
{
    public class AnonymousFacadeController : ApiController
    {
        private FlyingCenterSystem fcs = FlyingCenterSystem.GetInstance();
        public IAnonymousUserFacade anonymousUserFacade;

        public AnonymousFacadeController()
        {
            anonymousUserFacade = (IAnonymousUserFacade)fcs.Login("", "", out ILoginToken token);
        }

        [HttpGet]
        [Route("api/anonymousfacade/getallairlinecompanies")]
        public IHttpActionResult GetAllAirlineCompanies()
        {
            IList<AirlineCompany> result = anonymousUserFacade.GetAllAirlineCompanies();

            if(result.Count == 0)
            {
                return StatusCode(HttpStatusCode.NoContent);
            }

            return Ok(result);
        }

        [HttpGet]
        [Route("api/anonymousfacade/getallflights")]
        public IHttpActionResult GetAllFlights()
        {
            IList<Flight> result = anonymousUserFacade.GetAllFlights();

            if (result.Count == 0)
            {
                return StatusCode(HttpStatusCode.NoContent);
            }

            return Ok(result);
        }
        [HttpGet]
        [Route("api/anonymousfacade/getallflightsvacancy")]
        public IHttpActionResult GetAllFlightsVacancy()
        {
            Dictionary<Flight, int> result = anonymousUserFacade.GetAllFlightsVacancy();

            if (result.Count == 0)
            {
                return StatusCode(HttpStatusCode.NoContent);
            }

            return Ok(result);
        }

        [HttpGet]
        [Route("api/anonymousfacade/getairlinecompanybyid/{id}")]
        public IHttpActionResult GetAirlineCompanyById(long id)
        {
            AirlineCompany result = anonymousUserFacade.GetAirlineCompanyById(id);

            if(result is null)
            {
                return StatusCode(HttpStatusCode.NoContent);
            }

            return Ok(result);
        }

        [HttpGet]
        [Route("api/anonymousfacade/getflight")] //query parameter
        public IHttpActionResult GetFlight(long id)
        {
            Flight result = anonymousUserFacade.GetFlight(id);

            if (result is null)
            {
                return StatusCode(HttpStatusCode.NoContent);
            }

            return Ok(result);
        }

        [HttpGet]
        [Route("api/anonymousfacade/getflightsbydeparturedate")]
        public IHttpActionResult GetFlightsByDepartureDate([FromBody] DateTime departureDate)
        {
            IList<Flight> result = anonymousUserFacade.GetFlightsByDepartureDate(departureDate);

            if (result.Count == 0)
            {
                return StatusCode(HttpStatusCode.NoContent);
            }

            return Ok(result);
        }

        [HttpGet]
        [Route("api/anonymousfacade/getflightsbydestinationcountry/{countryCode}")]
        public IHttpActionResult GetFlightsByDestinationCountry(long countryCode)
        {
            IList<Flight> result = anonymousUserFacade.GetFlightsByDestinationCountry(countryCode);

            if (result.Count == 0)
            {
                return StatusCode(HttpStatusCode.NoContent);
            }

            return Ok(result);
        }

        [HttpGet]
        [Route("api/anonymousfacade/getflightsbylandingdate")]
        public IHttpActionResult GetFlightsByLandingDate([FromBody] DateTime landingDate)
        {
            IList<Flight> result = anonymousUserFacade.GetFlightsByLandingDate(landingDate);

            if (result.Count == 0)
            {
                return StatusCode(HttpStatusCode.NoContent);
            }

            return Ok(result);
        }

        [HttpGet]
        [Route("api/anonymousfacade/getflightsbyorigincountry/{countryCode}")]
        public IHttpActionResult GetFlightsByOriginCountry(long countryCode)
        {
            IList<Flight> result = anonymousUserFacade.GetFlightsByOriginCountry(countryCode);
            if (result.Count == 0)
            {
                return StatusCode(HttpStatusCode.NoContent);
            }

            return Ok(result);
        }
    }
}
