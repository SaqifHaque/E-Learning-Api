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
    [RoutePrefix("api/Forum")]
    public class ForumController : ApiController
    {
        PostRepository postRepo = new PostRepository();
        CommentRepository comRepo = new CommentRepository();
        UserRepository uRepo = new UserRepository();
        
        [BasicAuthorization]
        [MyAuthorize(Roles = "Admin,Student,Teacher")]
        [Route("")]
        public IHttpActionResult Get()
        {
            List<Post> p = postRepo.GetAll();
            foreach (Post item in p)
            {
                item.Comments = postRepo.GetCommentsByPost(item.PostId);
                item.User = uRepo.GetByID(item.UserId);
            }
            return Ok(p);
        }
        [BasicAuthorization]
        [MyAuthorize(Roles = "Admin,Student,Teacher")]
        [Route("{id}",Name ="GetPostById")]
        public IHttpActionResult Get(int id)
        {
            Post p = postRepo.GetByID(id);
            if(p == null)
            {
                return StatusCode(HttpStatusCode.NoContent);
            }
            return Ok(p);

        }
        [BasicAuthorization]
        [MyAuthorize(Roles = "Admin,Student,Teacher")]
        //Post Done
        [Route("")]
        public IHttpActionResult Post(Post post)
        {
            postRepo.Insert(post);
            string url = Url.Link("GetPostById", new { id = post.PostId });
            return Created(url, post);
            
        }
        //Get Specific Comment
        [BasicAuthorization]
        [MyAuthorize(Roles = "Admin,Student,Teacher")]
        [Route("{id1}/comments/{id2}", Name = "GetCommentById")]
        public IHttpActionResult Get(int id1, int id2)
        {
            Comment comment = comRepo.GetCommentWithPost(id1,id2);
            if (comment == null)
            {
                return StatusCode(HttpStatusCode.NoContent);
            }
            return Ok(comment);

        }


        [Route("{id1}/comments")]
        public IHttpActionResult Post(Comment c,[FromUri]int id1)
        {
            c.PostId = id1;
            comRepo.Insert(c);
            string url = Url.Link("GetCommentById", new { id1 = c.PostId, id2 = c.CommentId });
            return Created(url, c);

        }


    }
}
