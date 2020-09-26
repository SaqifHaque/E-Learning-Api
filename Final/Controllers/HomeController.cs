using Final.Authentication;
using Final.Models;
using Final.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Final.Controllers
{
    [RoutePrefix("api/Home")]
    public class HomeController : ApiController
    {
        UserRepository userRepo = new UserRepository();
        CourseRepository course = new CourseRepository();
        

        //[BasicAuthorization]
        //[MyAuthorize(Roles="Student,Teacher")]
        [Route("")]
        public IHttpActionResult Get()
        {
            return Ok(course.GetAll());
        }


    }
}
