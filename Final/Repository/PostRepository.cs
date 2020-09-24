using Final.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Final.Repository
{
    public class PostRepository : Repository<Post>
    {
        public List<Comment> GetCommentsByPost(int id)
        {
            return this.context.Comments.Where(x => x.PostId == id).ToList();
        }


    }
}