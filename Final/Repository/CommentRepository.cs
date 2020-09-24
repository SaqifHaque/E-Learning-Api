using Final.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Final.Repository
{
    public class CommentRepository : Repository<Comment>
    {
        public Comment GetCommentWithPost(int id1, int id2)
        {
            return this.context.Comments.Where(x => x.PostId == id1 && x.CommentId == id2).FirstOrDefault();
        }
    }
}