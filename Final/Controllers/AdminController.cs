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
    [RoutePrefix("api/Admin")]
    public class AdminController : ApiController
    {
        UserRepository userRepo = new UserRepository();

        [Route("")]
        public IHttpActionResult Get()
        {
            return Ok(userRepo.GetAll());
        }

        [Route("{id}", Name = "GetUserById")]
        public IHttpActionResult Get(int id)
        {
            User user = userRepo.GetByID(id);
            if (user == null)
            {
                return StatusCode(HttpStatusCode.NoContent);
            }
            user.HyperLinks.Add(new HyperLink() { HRef = "http://localhost:9170/api/Admin/" + user.Id , HttpMethod = "GET", Relation = "Self" });
            user.HyperLinks.Add(new HyperLink() { HRef = "http://localhost:9170/api/Admin", HttpMethod = "POST", Relation = "Create a new User" });
            user.HyperLinks.Add(new HyperLink() { HRef = "http://localhost:9170/api/Admin/" + user.Id , HttpMethod = "PUT", Relation = "Edit a existing User" });
            user.HyperLinks.Add(new HyperLink() { HRef = "http://localhost:9170/api/Admin/" + user.Id, HttpMethod = "DELETE", Relation = "Delete a existing User" });

            return Ok(user);
        }

        [Route("")]
        public IHttpActionResult Post(User user)
        {
            userRepo.Insert(user);
            string url = Url.Link("GetUserById", new { id = user.Id });
            return Created(url, user);
        }

        [Route("{id}")]
        public IHttpActionResult Put([FromBody]User user, [FromUri]int id)
        {
            user.Id = id;
            userRepo.Edit(user);

            return Ok(user);
        }
    }
}
