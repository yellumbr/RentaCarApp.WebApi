using Business.Concretes;
using Models.Concretes;
using RentaCarWebApi.ApiHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace RentaCarWebApi.Controllers
{
    [ApiExceptionAttribute]

    [EnableCors("*", "*", "*")]
    public class LoginController : ApiController
    {
        KullaniciBusiness business = new KullaniciBusiness();
        // GET: api/Login
        public Guid PostIndex(string kullaniciAdi,string parola)
        {
            var kullanici = business.Giris(kullaniciAdi, parola);
            if (kullanici != null)
                return kullanici.Anahtar;
            else
                return Guid.Empty;
        }

        
    }
}
