using Final.Models;
using Final.Repository;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace Final.Controllers
{
    [RoutePrefix("api/Video")]
    public class VideoController : ApiController
    {
        Video con = new Video();
        VideoRepository videoRepo = new VideoRepository();
        public static string saveVideo;

        [Route("")]
        public IHttpActionResult Get()
        {
            return Ok(videoRepo.GetAll());
        }



        [Route("{id}", Name = "GetVideo")]

        public IHttpActionResult Get(int id)
        {
            Video con = new Video();
            if (con == null)
            {
                StatusCode(HttpStatusCode.NoContent);
            }
            return Ok(con);
        }

        [Route("Save")]
        public IHttpActionResult Post()
        {

            string dir = System.Web.HttpContext.Current.Server.MapPath("~/Videos/");
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }

            if (HttpContext.Current.Request.Files.AllKeys.Any())
            {
                var file = HttpContext.Current.Request.Files["videoFile"];
                if (file != null)
                {
                    saveVideo = Path.Combine(HttpContext.Current.Server.MapPath("~/Videos/"), file.FileName);
                    con.Video_Name = file.FileName;
                    con.Video_Path = "~/Videos/";
                    file.SaveAs(saveVideo);
                }
            }
            return Ok();
        }

        [Route("")]

        public IHttpActionResult Post(Video cont)
        {
            cont.Video_Path = con.Video_Path;
            videoRepo.Insert(cont);
            string url = Url.Link("GetVideo", new { id = cont.V_Id });
            return Created(url, cont);
        }
    }
}
