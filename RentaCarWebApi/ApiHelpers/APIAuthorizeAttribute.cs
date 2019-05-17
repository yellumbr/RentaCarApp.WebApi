using Business.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;

namespace RentaCarWebApi.ApiHelpers
{
    public class APIAuthorizeAttribute:AuthorizeAttribute
    {
        KullaniciBusiness business = new KullaniciBusiness();
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            var kullaniciTipi = Roles;
            var userName = HttpContext.Current.User.Identity.Name;
            var user =business.KullaniciSecIsim(userName);
            if (user != null && kullaniciTipi.Contains(user.KullaniciTipi))
            {
                

            }
            else
            {
                actionContext.Response = new System.Net.Http.HttpResponseMessage(System.Net.HttpStatusCode.Unauthorized);
            }
      
        }
    }
}