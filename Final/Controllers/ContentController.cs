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
    [RoutePrefix("api/Content")]
    public class ContentController : ApiController
    {
        Content con = new Content();
        ContentRepository conRepo = new ContentRepository();
        public static string savefile;

        [Route("")]
        public IHttpActionResult Get()
        {
            return Ok(conRepo.GetAll());
        }

        [Route("{id}", Name = "GetContent")]

        public IHttpActionResult Get(int id)
        {
            Content con = new Content();
            if (con == null)
            {
                StatusCode(HttpStatusCode.NoContent);
            }
            con.HyperLinks.Add(new HyperLink() { HRef = "http://localhost:9170/api/Content/" + con.Content_Id , HttpMethod = "GET", Relation = "Self" });
            con.HyperLinks.Add(new HyperLink() { HRef = "http://localhost:9170/api/Content/", HttpMethod = "POST", Relation = "Create a new Comment" });
            con.HyperLinks.Add(new HyperLink() { HRef = "http://localhost:9170/api/Content/" + con.Content_Id, HttpMethod = "PUT", Relation = "Edit a existing Comment" });
            con.HyperLinks.Add(new HyperLink() { HRef = "http://localhost:9170/api/Content/" + con.Content_Id , HttpMethod = "DELETE", Relation = "Delete a existing Comment" });

            return Ok(con);
        }

        [Route("Save")]
        public IHttpActionResult Post()
        {

            string dir = HttpContext.Current.Server.MapPath("~/Uploads/");
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }

            if (HttpContext.Current.Request.Files.AllKeys.Any())
            {
                var file = HttpContext.Current.Request.Files["UploadFile"];
                if (file != null)
                {
                    savefile = Path.Combine(HttpContext.Current.Server.MapPath("~/Uploads/"), file.FileName);
                    con.File_Name = file.FileName;
                    con.File_Path = "~/Uploads/";
                    file.SaveAs(savefile);
                }
            }
            return Ok();
        }

        [Route("")]

        public IHttpActionResult Post(Content cont)
        {
            cont.File_Path = savefile;
            conRepo.Insert(cont);
            string url = Url.Link("GetContent", new { id = cont.Content_Id });
            return Created(url, cont);
        }


        /* [Route("sections/{id}/subjects/{id2}/assignments/t/{id3}/db/")] //20-0000-03
        //[TeacherAuthorization]
        public IHttpActionResult PostAssignmenttoDB(Assignment_t a, [FromUri] int id, [FromUri] int id2, [FromUri] string id3)
        {
            a.sectionid = id;
            a.subjectid = id2;
            a.directory = "/Uploads/Assignments/Teachers/" + id3 + id + id2 + "/";
            ass_t_repo.Insert(a);
            string url = Url.Link("GetAssignmentById", new { id = a.sectionid, id2 = a.subjectid, id3 = a.assignmentid });
            return Created(url, a);
        }
*/

    }
}
