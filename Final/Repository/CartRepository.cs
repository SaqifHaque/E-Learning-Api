using Final.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Final.Repository
{
    public class CartRepository : Repository<Cart>
    {

        public List<Cart> GetItemsWithUserId(int id)
        {
            //return this.context.Comments.Where(x => x.PostId == id1 && x.CommentId == id2).FirstOrDefault();
            return this.context.Carts.Where(x => x.Student_Id == id).ToList();
        }

        public Cart GetItemsWithUserIdCartId(int id1,int id2)
        {
            //return this.context.Comments.Where(x => x.PostId == id1 && x.CommentId == id2).FirstOrDefault();
            return this.context.Carts.Where(x => x.Student_Id == id1 && x.Cart_Id == id2).FirstOrDefault();
        }
    }
}