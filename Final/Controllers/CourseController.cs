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
    [RoutePrefix("api/Course")]
    public class CourseController : ApiController
    {
        CourseRepository courseRepository = new CourseRepository();
        CategoryRepository catRepository = new CategoryRepository();
        UserRepository userRepository = new UserRepository();

        [Route("")]
        public IHttpActionResult Get()
        {

            return Ok(courseRepository.GetAll());
        }

        [Route("{id}", Name = "GetCourseById")]
        public IHttpActionResult Get(int id)
        {
            Course c = courseRepository.GetByID(id);
            c.Category = catRepository.GetByID(c.Category_Id);
            c.User = userRepository.GetByID(c.Instructor_Id);
            if (c == null)
            {
                return StatusCode(HttpStatusCode.NoContent);
            }
            c.HyperLinks.Add(new HyperLink() { HRef = "http://localhost:9170/api/Course/" + c.C_Id , HttpMethod = "GET", Relation = "Self" });
            c.HyperLinks.Add(new HyperLink() { HRef = "http://localhost:9170/api/Course", HttpMethod = "POST", Relation = "Create a new Couse" });
            c.HyperLinks.Add(new HyperLink() { HRef = "http://localhost:9170/api/Course/" + c.C_Id , HttpMethod = "PUT", Relation = "Edit a existing Course" });
            c.HyperLinks.Add(new HyperLink() { HRef = "http://localhost:9170/api/Course/" + c.C_Id , HttpMethod = "DELETE", Relation = "Delete a existing Course" });

            return Ok(c);
        }
    }
}
