using Final.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Principal;
using System.Threading;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using Final.Repository;
using System.Text;

namespace Final.Authentication
{
    public class BasicAuthorization : AuthorizationFilterAttribute
    {
        FinalDataContext context = new FinalDataContext();
        public override void OnAuthorization(System.Web.Http.Controllers.HttpActionContext actionContext)
        {
            base.OnAuthorization(actionContext);

            if (actionContext.Request.Headers.Authorization != null)
            {
                string encoded = actionContext.Request.Headers.Authorization.Parameter;
                string decoded = Encoding.UTF8.GetString(Convert.FromBase64String(encoded));
                string[] splittedData = decoded.Split(new char[] { ':' });
                string email = splittedData[0];
                string password = splittedData[1];
                var u = context.Users.Where(x => x.Email == email && x.Password == password).FirstOrDefault();
                if (context.Users.Any(x=>x.Email == email) && context.Users.Any(x => x.Password == password))
                {
                    IPrincipal principal = new GenericPrincipal(new GenericIdentity(email), u.Type.Split(','));
                    Thread.CurrentPrincipal = principal;
                    if (HttpContext.Current.User!=null)
                    {
                        HttpContext.Current.User = principal;
                    }
                }
                else
                {
                    actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
                }
            }
            else
            {
                actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
            }
        }
    }
}
