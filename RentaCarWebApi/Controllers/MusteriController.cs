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
    [EnableCors("*", "*", "*")]
    public class MusteriController : ApiController
    {
        MusteriBusiness MusteriBusiness = new MusteriBusiness();

        // GET: api/Arac

        public IHttpActionResult Get()
        {
            var Musterilar = MusteriBusiness.MusteriHepsiniSec();

            return Ok(Musterilar);
        }

        // GET: api/Arac/5
        public IHttpActionResult Get(int id)
        {
            var Musteri = MusteriBusiness.MusteriIdSec(id);
            if (Musteri == null)
                return NotFound();
            return Ok(Musteri);
        }

        // POST: api/Arac
        public IHttpActionResult Post([FromBody]Musteri Musteri)
        {
            if (ModelState.IsValid)
            {
                var olusturulanMusteri = MusteriBusiness.MusteriEkle(Musteri);
                return CreatedAtRoute("DefaultApi", new { id = olusturulanMusteri.MusteriID }, olusturulanMusteri);
            }
            return BadRequest();

        }

        // PUT: api/Arac/5
        public IHttpActionResult Put(int id, [FromBody]Musteri Musteri)
        {
            Musteri.MusteriID = id;
            if (MusteriBusiness.MusteriIdSec(id) == null)
                return NotFound();
            else if (ModelState.IsValid == false)
                return BadRequest();
            else
                return Ok(MusteriBusiness.MusteriGuncelle(Musteri));
        }

        // DELETE: api/Arac/5
        public IHttpActionResult Delete(int id)
        {
            if (MusteriBusiness.MusteriIdSec(id) == null)
                return NotFound();
            return Ok(MusteriBusiness.MusteriIdSil(id));
        }
    }
}
