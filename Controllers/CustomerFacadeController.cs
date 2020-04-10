using AirlineProject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AirlineProjectWebAPI.Controllers
{
    public class CustomerFacadeController : ApiController //inheriting from AnonymousFacadeController does problems
    {
        private FlyingCenterSystem fcs = FlyingCenterSystem.GetInstance();
        //public ILoggedInCustomerFacade customerFacade;

        public bool TryGetConnector(out ILoggedInCustomerFacade customerFacade, out LoginToken<Customer> token)
        {
            if (Request.Properties["facade"] != null && Request.Properties["token"] != null)
            {
                if (Request.Properties["facade"].GetType() == typeof(ILoggedInCustomerFacade) && Request.Properties["token"].GetType() == typeof(LoginToken<Customer>))
                {
                    customerFacade = (ILoggedInCustomerFacade)Request.Properties["facade"];
                    token = (LoginToken<Customer>)Request.Properties["token"];
                    return true;
                }
            }

            customerFacade = null;
            token = null;

            return false;

            //ILoginToken token;
            //airlineFacade = (ILoggedInAirlineFacade)fcs.Login("DeltaRune", "UnderTale", out token);

            //return token;
        }

        //public ILoginToken GetLoginToken()
        //{
        //    ILoginToken token;
        //    customerFacade = (ILoggedInCustomerFacade)fcs.Login("YoLevi", "123", out token);
        //    return token;
        //}

        [HttpGet]
        [Route("api/customerfacade/getallmyflights")]
        public IHttpActionResult GetAllMyFlights()
        {
            ILoggedInCustomerFacade customerFacade;
            LoginToken<Customer> token;
            if (TryGetConnector(out customerFacade, out token) == true)
            {
                IList<Flight> result = customerFacade.GetAllMyFlights(token);
                return Ok(result);
            }
            return Unauthorized();

            //LoginToken<Customer> token = (LoginToken<Customer>)GetLoginToken();
            //IList<Flight> result = customerFacade.GetAllMyFlights(token);
            //return Ok(result);
        }

        [HttpPost]
        [Route("api/customerfacade/purchaseticket")]
        public IHttpActionResult PurchaseTicket(Flight flight)
        {
            ILoggedInCustomerFacade customerFacade;
            LoginToken<Customer> token;
            if (TryGetConnector(out customerFacade, out token) == true)
            {
                Ticket result = customerFacade.PurchaseTicket(token, flight);
                return Ok(result);
            }
            return Unauthorized();

            //LoginToken<Customer> token = (LoginToken<Customer>)GetLoginToken();
            //Ticket result = customerFacade.PurchaseTicket(token, flight);
            //return Ok(result);
        }

        [HttpDelete]
        [Route("api/customerfacade/cancelticket")]
        public IHttpActionResult CancelTicket(Ticket ticket)
        {
            ILoggedInCustomerFacade customerFacade;
            LoginToken<Customer> token;
            if (TryGetConnector(out customerFacade, out token) == true)
            {
                customerFacade.CancelTicket(token, ticket);
                return Ok();
            }
            return Unauthorized();

            //LoginToken<Customer> token = (LoginToken<Customer>)GetLoginToken();
            //customerFacade.CancelTicket(token, ticket);
            //return Ok();
        }
    }
}
