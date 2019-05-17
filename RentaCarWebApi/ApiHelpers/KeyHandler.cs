using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using Business.Concretes;

namespace RentaCarWebApi.ApiHelpers
{
    public class KeyHandler:DelegatingHandler
    {

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var queryString = request.RequestUri.ParseQueryString();
            var Key = queryString["Anahtar"];
            //var Key = request.Headers.GetValues("anahtar").FirstOrDefault();
            KullaniciBusiness kullaniciBusiness = new KullaniciBusiness();
            var user = kullaniciBusiness.KullaniciAnahtarSec(Key);

            if(user!=null)
            {
                var principal = new ClaimsPrincipal(new GenericIdentity(user.KullaniciAdi,"Anahtar"));
                HttpContext.Current.User = principal;
            }
           
            return base.SendAsync(request, cancellationToken);
        }
    }
}