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
    [RoutePrefix("api/Notice")]
    public class NoticeController : ApiController
    {
        NoticeRepository nRepo = new NoticeRepository();

        [Route("")]
        public IHttpActionResult Get()
        {
            return Ok(nRepo.GetAll());
        }

        [Route("{id}", Name ="GetByNoticeId")]

        public IHttpActionResult Get(int id)
        {
            Notice notice = nRepo.GetByID(id);
            if(notice == null)
            {
                return StatusCode(HttpStatusCode.NoContent);
            }
            return Ok(nRepo.GetAll());
        }

        [Route("")]

        public IHttpActionResult Post(Notice no)
        {
            nRepo.Insert(no);
            string url = Url.Link("GetByNoticeId", new { id = no.Notice_Id });
            return Created(url,no);
        }

    }
}
