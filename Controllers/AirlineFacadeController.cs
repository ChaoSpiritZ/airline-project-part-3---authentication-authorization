using AirlineProject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AirlineProjectWebAPI.Controllers
{
    [AirlineAuthentication]
    public class AirlineFacadeController : ApiController
    {
        private FlyingCenterSystem fcs = FlyingCenterSystem.GetInstance();

        public bool TryGetConnector(out ILoggedInAirlineFacade airlineFacade, out LoginToken<AirlineCompany> token)
        {
            if (Request.Properties["facade"] != null && Request.Properties["token"] != null) 
            {
                if (Request.Properties["facade"].GetType() == typeof(ILoggedInAirlineFacade) && Request.Properties["token"].GetType() == typeof(LoginToken<AirlineCompany>))
                {
                    airlineFacade = (ILoggedInAirlineFacade)Request.Properties["facade"];
                    token = (LoginToken<AirlineCompany>)Request.Properties["token"];
                    return true;
                }
            }

            airlineFacade = null;
            token = null;

            return false;

            //ILoginToken token;
            //airlineFacade = (ILoggedInAirlineFacade)fcs.Login("DeltaRune", "UnderTale", out token);

            //return token;
        }

        [HttpGet]
        [Route("api/airlinefacade/getalltickets")]
        public IHttpActionResult GetAllTickets()
        {
            ILoggedInAirlineFacade airlineFacade;
            LoginToken<AirlineCompany> token;
            if(TryGetConnector(out airlineFacade, out token) == true)
            {
                IList<Ticket> result = airlineFacade.GetAllTickets(token);
                return Ok(result);
            }
            return Unauthorized();
        }

        [HttpGet]
        [Route("api/airlinefacade/getallflights")]
        public IHttpActionResult GetAllFlights()
        {
            ILoggedInAirlineFacade airlineFacade;
            LoginToken<AirlineCompany> token;
            if (TryGetConnector(out airlineFacade, out token) == true)
            {
                IList<Flight> result = airlineFacade.GetAllFlights(token);
                return Ok(result);
            }
            return Unauthorized();

            //LoginToken<AirlineCompany> token = (LoginToken<AirlineCompany>)GetLoginToken();
            //IList<Flight> result = airlineFacade.GetAllFlights(token);
            //return Ok(result);
        }

        [HttpDelete]
        [Route("api/airlinefacade/cancelflight")]
        public IHttpActionResult CancelFlight([FromBody] Flight flight)
        {
            ILoggedInAirlineFacade airlineFacade;
            LoginToken<AirlineCompany> token;
            if (TryGetConnector(out airlineFacade, out token) == true)
            {
                airlineFacade.CancelFlight(token, flight);
                return Ok();
            }
            return Unauthorized();

            //LoginToken<AirlineCompany> token = (LoginToken<AirlineCompany>)GetLoginToken();
            //airlineFacade.CancelFlight(token, flight);
            //return Ok();
        }

        [HttpPost]
        [Route("api/airlinefacade/createflight")]
        public IHttpActionResult CreateFlight([FromBody] Flight flight)
        {
            ILoggedInAirlineFacade airlineFacade;
            LoginToken<AirlineCompany> token;
            if (TryGetConnector(out airlineFacade, out token) == true)
            {
                airlineFacade.CreateFlight(token, flight);
                return Ok();
            }
            return Unauthorized();

            //LoginToken<AirlineCompany> token = (LoginToken<AirlineCompany>)GetLoginToken();
            //airlineFacade.CreateFlight(token, flight);
            //return Ok();
        }

        [HttpPut]
        [Route("api/airlinefacade/updateflight")]
        public IHttpActionResult UpdateFlight([FromBody] Flight flight)
        {
            ILoggedInAirlineFacade airlineFacade;
            LoginToken<AirlineCompany> token;
            if (TryGetConnector(out airlineFacade, out token) == true)
            {
                airlineFacade.UpdateFlight(token, flight);
                return Ok();
            }
            return Unauthorized();

            //LoginToken<AirlineCompany> token = (LoginToken<AirlineCompany>)GetLoginToken();
            //airlineFacade.UpdateFlight(token, flight);
            //return Ok();
        }

        [HttpPut]
        [Route("api/airlinefacade/changemypassword")]
        public IHttpActionResult ChangeMyPassword(string oldPassword, string newPassword) //path parameter
        {
            ILoggedInAirlineFacade airlineFacade;
            LoginToken<AirlineCompany> token;
            if (TryGetConnector(out airlineFacade, out token) == true)
            {
                airlineFacade.ChangeMyPassword(token, oldPassword, newPassword);
                return Ok();
            }
            return Unauthorized();

            //LoginToken<AirlineCompany> token = (LoginToken<AirlineCompany>)GetLoginToken();
            //airlineFacade.ChangeMyPassword(token, oldPassword, newPassword);
            //return Ok();
        }

        [HttpPut]
        [Route("api/airlinefacade/modifyairlinedetails")]
        public IHttpActionResult MofidyAirlineDetails([FromBody] AirlineCompany airline)
        {
            ILoggedInAirlineFacade airlineFacade;
            LoginToken<AirlineCompany> token;
            if (TryGetConnector(out airlineFacade, out token) == true)
            {
                airlineFacade.ModifyAirlineDetails(token, airline);
                return Ok();
            }
            return Unauthorized();

            //LoginToken<AirlineCompany> token = (LoginToken<AirlineCompany>)GetLoginToken();
            //airlineFacade.ModifyAirlineDetails(token, airline);
            //return Ok();
        }
    }
}
