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
    [RoutePrefix("api/Invoice")]
    public class InvoiceController : ApiController
    {
        InvoiceRepository inRepo = new InvoiceRepository();
        [Route("")]
        [BasicAuthorization]
        [MyAuthorize(Roles = "Admin,Student")]
        public IHttpActionResult Get()
        {
            List<Invoice> invoice = inRepo.GetAll();
            if(invoice == null)
            {
                return StatusCode(HttpStatusCode.NoContent);
            }
            return Ok(invoice);
        }
        [BasicAuthorization]
        [MyAuthorize(Roles = "Admin,Student")]
        [Route("{id}",Name ="GetByInvoiceId")]
        public IHttpActionResult Get(int id)
        {
            Invoice invoice = inRepo.GetByID(id);
            if (invoice == null)
            {
                return StatusCode(HttpStatusCode.NoContent);
            }
            return Ok(invoice);
        }
        [BasicAuthorization]
        [MyAuthorize(Roles = "Admin,Student")]
        [Route("")]
        public IHttpActionResult Post(Invoice invoice)
        {
            inRepo.Insert(invoice);
            string url = Url.Link("GetByInvoiceId", new { id = invoice.Invoice_Id });
            return Created(url,invoice);
        }

    }
}
