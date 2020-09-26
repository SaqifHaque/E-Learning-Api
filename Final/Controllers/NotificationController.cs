using Final.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Final.Controllers
{
    [RoutePrefix("api/Notification")]
    public class NotificationController : ApiController
    {
        NotificationRepository nRepo = new NotificationRepository();
        StatusRepository sRepo = new StatusRepository();
        [Route("")]
        public IHttpActionResult Get()
        {
            return Ok(nRepo.GetAll());
        }
        [Route("{id}")]
        public IHttpActionResult Get(int id)
        {
            var s = sRepo.GetByUserID(id);
            var n = nRepo.GetAll();
            

            return Ok(nRepo.GetAll());
        }
    }
}
