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
    [RoutePrefix("api/Enroll")]
    public class EnrollController : ApiController
    {
        EnrollRepository enRepo = new EnrollRepository();
        CourseRepository couRepo = new CourseRepository();
        UserRepository userRepo = new UserRepository();

        [BasicAuthorization]
        [MyAuthorize(Roles = "Student,Admin")]
        [Route("")]
        public IHttpActionResult Get()
        {
            var en = enRepo.GetAll();
            foreach (var item in en)
            {
                item.Course = couRepo.GetByID(item.Course_Id);
                item.Course.User = userRepo.GetByID(item.Course.Instructor_Id);
                //item.EnrolledUser = userRepo.GetByID(item.Enroll_Id);
            }
            return Ok(en);
        }
        [BasicAuthorization]
        [MyAuthorize(Roles = "Student,Admin")]
        [Route("{id}",Name ="GetByUserId")]
        public IHttpActionResult Get(int id)
        {
            var en = enRepo.GetByID(id);
            if(en == null)
            {
                return StatusCode(HttpStatusCode.NoContent);
            }
            
            return Ok(en);
        }
        [BasicAuthorization]
        [MyAuthorize(Roles = "Student")]
        [Route("")]
        public IHttpActionResult Post(Enroll enroll)
        {
            enRepo.Insert(enroll);
            
            string url = Url.Link("GetByUserId", new { id = enroll.E_Id });
            return Created(url,enroll);
        }


        [Route("All/{id}")]
        public IHttpActionResult GetAll(int id)
        {
            var en = enRepo.GetAllEnrolledStudents(id);
            
            return Ok(en);
        }


    }
}
