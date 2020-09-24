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
        CourseRepository courepo = new CourseRepository();
        CategoryRepository catrepo = new CategoryRepository();

        [BasicAuthorization]
        [MyAuthorize(Roles="Student,Teacher")]
        [Route("")]
        public IHttpActionResult Get()
        {
            return Ok(courepo.GetAll());
        }

        [Route("{id}", Name = "GetCourseById")]
        public IHttpActionResult Get(int id)
        {
            Course c = courepo.GetByID(id);
            c.Category = catrepo.GetByID(c.Category_Id);
            
            if (c == null)
            {
                return StatusCode(HttpStatusCode.NoContent);
            }
            return Ok(c);
        }
    }
}
