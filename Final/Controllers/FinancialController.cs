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
    [RoutePrefix("api/Financial")]
    public class FinancialController : ApiController
    {
        FinancialRepository fnRepo = new FinancialRepository();
        [BasicAuthorization]
        [MyAuthorize(Roles = "Student,Admin")]
        [Route("")]
        public IHttpActionResult Get()
        {
            List<Financial> finance = fnRepo.GetAll();
            return Ok(finance);
        }
        [BasicAuthorization]
        [MyAuthorize(Roles = "Student,Admin")]
        [Route("{id}", Name ="GetByFinancialId")]
        public IHttpActionResult Get(int id)
        {
            Financial finance = fnRepo.GetByID(id);
            if(finance == null)
            {
                StatusCode(HttpStatusCode.NoContent);
            }
            finance.HyperLinks.Add(new HyperLink() { HRef = "http://localhost:9170/api/Financial/" + finance.F_Id , HttpMethod = "GET", Relation = "Self" });
            finance.HyperLinks.Add(new HyperLink() { HRef = "http://localhost:9170/api/Financial", HttpMethod = "POST", Relation = "Create a new Comment" });
            finance.HyperLinks.Add(new HyperLink() { HRef = "http://localhost:9170/api/Financial/" + finance.F_Id , HttpMethod = "PUT", Relation = "Edit a existing Comment" });
            finance.HyperLinks.Add(new HyperLink() { HRef = "http://localhost:9170/api/Financial/" + finance.F_Id , HttpMethod = "DELETE", Relation = "Delete a existing Comment" });

            return Ok(finance);
        }

        [Route("")]
        [BasicAuthorization]
        [MyAuthorize(Roles = "Student,Admin")]
        public IHttpActionResult Post(Financial financial)
        {
            fnRepo.Insert(financial);
            string url = Url.Link("GetByFinancialId", new { id = financial.F_Id });
            return Created(url,financial);
        }

    }
    }
