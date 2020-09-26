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
    [RoutePrefix("api/Cart")]
    public class CartController : ApiController
    {
        CartRepository cartRepo = new CartRepository();
        CourseRepository couRepo = new CourseRepository();

        [BasicAuthorization]
        [MyAuthorize(Roles = "Student")]
        [Route("{id}")]
        public IHttpActionResult Get(int id)
        {
            List<Cart> cart = cartRepo.GetItemsWithUserId(id).ToList();
            foreach (Cart item in cart)
            {
                item.Course = couRepo.GetByID(item.Item_Id);
            }
            return Ok(cart);
        }



        [BasicAuthorization]
        [MyAuthorize(Roles = "Student")]
        [Route("{id}/items/{id2}",Name = "GetItemById")]
        public IHttpActionResult Get(int id,int id2)
        {
            Cart cart = cartRepo.GetItemsWithUserIdCartId(id,id2);
            if(cart == null)
            {
                return StatusCode(HttpStatusCode.NoContent);
            }
            return Ok(cart);
        }


        [BasicAuthorization]
        [MyAuthorize(Roles = "Student")]
        [Route("{id}/items/")]
        public IHttpActionResult Post(Cart cart,[FromUri]int id)
        {
            cart.Student_Id = id;
            cartRepo.Insert(cart);
            string url = Url.Link("GetItemById", new { id = cart.Student_Id, id2 = cart.Cart_Id });
            return Created(url, cart);
        }

        //Delete By Cart Id
        [BasicAuthorization]
        [MyAuthorize(Roles = "Student")]

        [Route("{id}")]
        public IHttpActionResult Delete(int id)
        {
            cartRepo.Delete(id);
            return StatusCode(HttpStatusCode.NoContent);
        }




    }
}
