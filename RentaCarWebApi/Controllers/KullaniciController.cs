using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using Business.Concretes;
using Models.Concretes;
using RentaCarWebApi.ApiHelpers;

namespace RentaCarWebApi.Controllers
{
    [ApiExceptionAttribute]
    
    [EnableCors("*","*","*")]
    public class KullaniciController : ApiController
    {
        KullaniciBusiness KullaniciBusiness = new KullaniciBusiness();

        //[APIAuthorizeAttribute(Roles="Y")]
        public IHttpActionResult Get()
        {
            var Kullanicilar = KullaniciBusiness.KullaniciHepsiniSec();
       
                return Ok(Kullanicilar);
        }

        // GET: api/Arac/Birkan14
        public IHttpActionResult Get(string kullaniciAdi)
        {
            var Kullanici = KullaniciBusiness.KullaniciSecIsim(kullaniciAdi);
            if (Kullanici == null)
                return NotFound();
            return Ok(Kullanici);
        }
        public IHttpActionResult Get(int id)
        {
            var Kullanici = KullaniciBusiness.KullaniciIdSec(id);
            if (Kullanici == null)
                return NotFound();
            return Ok(Kullanici);
        }

        // POST: api/Arac
        public IHttpActionResult Post([FromBody]Kullanici Kullanici)
        {
            if (ModelState.IsValid)
            {
                var olusturulanKullanici = KullaniciBusiness.KullaniciEkle(Kullanici);
                return CreatedAtRoute("DefaultApi", new { id = olusturulanKullanici.KullaniciID }, olusturulanKullanici);
            }
            return BadRequest();

        }

        // PUT: api/Arac/5
        public IHttpActionResult Put(int id, [FromBody]Kullanici Kullanici)
        {
            Kullanici.KullaniciID = id;
            if (KullaniciBusiness.KullaniciIdSec(id) == null)
                return NotFound();
            else if (ModelState.IsValid == false)
                return BadRequest();
            else
                return Ok(KullaniciBusiness.KullaniciGuncelle(Kullanici));
        }

        // DELETE: api/Arac/5
        public IHttpActionResult Delete(int id)
        {
            if (KullaniciBusiness.KullaniciIdSec(id) == null)
                return NotFound();
            return Ok(KullaniciBusiness.KullaniciIdSil(id));
        }
    }
}
