using AirlineProject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AirlineProjectWebAPI.Controllers
{
    [AdminAuthentication]
    public class AdminFacadeController : ApiController
    {
        private FlyingCenterSystem fcs = FlyingCenterSystem.GetInstance();
        //public ILoggedInAdministratorFacade adminFacade;

        public bool TryGetConnector(out ILoggedInAdministratorFacade adminFacade, out LoginToken<Administrator> token)
        {
            if (Request.Properties["facade"] != null && Request.Properties["token"] != null)
            {
                if (Request.Properties["facade"].GetType() == typeof(ILoggedInAdministratorFacade) && Request.Properties["token"].GetType() == typeof(LoginToken<Administrator>))
                {
                    adminFacade = (ILoggedInAdministratorFacade)Request.Properties["facade"];
                    token = (LoginToken<Administrator>)Request.Properties["token"];
                    return true;
                }
            }

            adminFacade = null;
            token = null;

            return false;

            //ILoginToken token;
            //airlineFacade = (ILoggedInAirlineFacade)fcs.Login("DeltaRune", "UnderTale", out token);

            //return token;
        }

        //public ILoginToken GetLoginToken()
        //{
        //    ILoginToken token;
        //    adminFacade = (ILoggedInAdministratorFacade)fcs.Login("admin", "9999", out token);
        //    return token;
        //}

        /// <summary>
        /// creates a new airline company
        /// </summary>
        /// <param name="token"></param>
        /// <param name="airline">id is generated upon creation, leave it at 0</param>
        [HttpPost]
        [Route("api/adminfacade/createnewairline")]
        public IHttpActionResult CreateNewAirline([FromBody] AirlineCompany airline)
        {
            ILoggedInAdministratorFacade adminFacade;
            LoginToken<Administrator> token;
            if (TryGetConnector(out adminFacade, out token) == true)
            {
                adminFacade.CreateNewAirline(token, airline);
                return Ok();
            }
            return Unauthorized();

            //LoginToken<Administrator> token = (LoginToken<Administrator>)GetLoginToken();
            //adminFacade.CreateNewAirline(token, airline);
            //return Ok();
        }

        /// <summary>
        /// updates an airline company
        /// </summary>
        /// <param name="token"></param>
        /// <param name="airline">updates the airline company with this parameter's ID</param>
        [HttpPut]
        [Route("api/adminfacade/updateairlinedetails")]
        public IHttpActionResult UpdateAirlineDetails([FromBody] AirlineCompany airline)
        {
            ILoggedInAdministratorFacade adminFacade;
            LoginToken<Administrator> token;
            if (TryGetConnector(out adminFacade, out token) == true)
            {
                adminFacade.UpdateAirlineDetails(token, airline);
                return Ok();
            }
            return Unauthorized();

            //LoginToken<Administrator> token = (LoginToken<Administrator>)GetLoginToken();
            //adminFacade.UpdateAirlineDetails(token, airline);
            //return Ok();
        }

        /// <summary>
        /// removes an airline company
        /// </summary>
        /// <param name="token"></param>
        /// <param name="airline">removes an airline company that has this parameter's ID</param>
        [HttpDelete]
        [Route("api/adminfacade/removeairline")]
        public IHttpActionResult RemoveAirline([FromBody] AirlineCompany airline)
        {
            ILoggedInAdministratorFacade adminFacade;
            LoginToken<Administrator> token;
            if (TryGetConnector(out adminFacade, out token) == true)
            {
                adminFacade.RemoveAirline(token, airline);
                return Ok();
            }
            return Unauthorized();

            //LoginToken<Administrator> token = (LoginToken<Administrator>)GetLoginToken();
            //adminFacade.RemoveAirline(token, airline);
            //return Ok();
        }

        /// <summary>
        /// creates a new customer
        /// </summary>
        /// <param name="token"></param>
        /// <param name="customer">id is generated upon creation, leave it at 0</param>
        [HttpPost]
        [Route("api/adminfacade/createnewcustomer")]
        public IHttpActionResult CreateNewCustomer([FromBody] Customer customer)
        {
            ILoggedInAdministratorFacade adminFacade;
            LoginToken<Administrator> token;
            if (TryGetConnector(out adminFacade, out token) == true)
            {
                adminFacade.CreateNewCustomer(token, customer);
                return Ok();
            }
            return Unauthorized();

            //LoginToken<Administrator> token = (LoginToken<Administrator>)GetLoginToken();
            //adminFacade.CreateNewCustomer(token, customer);
            //return Ok();
        }

        /// <summary>
        /// updates a customer
        /// </summary>
        /// <param name="token"></param>
        /// <param name="customer">updates the customer with this parameter's ID</param>
        [HttpPut]
        [Route("api/adminfacade/updatecustomerdetails")]
        public IHttpActionResult UpdateCustomerDetails([FromBody] Customer customer)
        {
            ILoggedInAdministratorFacade adminFacade;
            LoginToken<Administrator> token;
            if (TryGetConnector(out adminFacade, out token) == true)
            {
                adminFacade.UpdateCustomerDetails(token, customer);
                return Ok();
            }
            return Unauthorized();

            //LoginToken<Administrator> token = (LoginToken<Administrator>)GetLoginToken();
            //adminFacade.UpdateCustomerDetails(token, customer);
            //return Ok();
        }

        /// <summary>
        /// removes a customer
        /// </summary>
        /// <param name="token"></param>
        /// <param name="customer">removes a customer that has this parameter's ID</param>
        [HttpDelete]
        [Route("api/adminfacade/removecustomer")]
        public IHttpActionResult RemoveCustomer([FromBody] Customer customer)
        {
            ILoggedInAdministratorFacade adminFacade;
            LoginToken<Administrator> token;
            if (TryGetConnector(out adminFacade, out token) == true)
            {
                adminFacade.RemoveCustomer(token, customer);
                return Ok();
            }
            return Unauthorized();

            //LoginToken<Administrator> token = (LoginToken<Administrator>)GetLoginToken();
            //adminFacade.RemoveCustomer(token, customer);
            //return Ok();
        }
    }
}
