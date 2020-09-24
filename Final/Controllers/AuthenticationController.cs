using Final.Authentication;
using Final.Models;
using Final.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace Final.Controllers
{
    [RoutePrefix("api/Authentication")]
    public class AuthenticationController : ApiController
    {
        UserRepository urepo = new UserRepository();

        [BasicAuthorization]
        //[MyAuthorize(Roles = "Admin,Teacher,Student")]
        [Route("")]
        public IHttpActionResult Get()
        {
            return Ok(urepo.GetAll());
        }
    }
}
