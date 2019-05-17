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
    public class AracController : ApiController
    {
        AracBusiness AracBusiness = new AracBusiness();

        // GET: api/Arac

        public IHttpActionResult Get()
        {
            var Araclar = AracBusiness.AracHepsiniSec();

            return Ok(Araclar);
        }

        // GET: api/Arac/5
        public IHttpActionResult Get(int id)
        {
            var Arac = AracBusiness.AracIdSec(id);
            if (Arac == null)
                return NotFound();
            return Ok(Arac);
        }

        // POST: api/Arac
        public IHttpActionResult Post([FromBody]Arac Arac)
        {
            if (ModelState.IsValid)
            {
                var olusturulanArac = AracBusiness.AracEkle(Arac);
                return CreatedAtRoute("DefaultApi", new { id = olusturulanArac.AracID }, olusturulanArac);
            }
            return BadRequest();

        }

        // PUT: api/Arac/5
        public IHttpActionResult Put(int id, [FromBody]Arac Arac)
        {
            Arac.AracID = id;
            if (AracBusiness.AracIdSec(id) == null)
                return NotFound();
            else if (ModelState.IsValid == false)
                return BadRequest();
            else
                return Ok(AracBusiness.AracGuncelle(Arac));
        }

        // DELETE: api/Arac/5
        public IHttpActionResult Delete(int id)
        {
            if (AracBusiness.AracIdSec(id) == null)
                return NotFound();
            return Ok(AracBusiness.AracIdSil(id));
        }
    }
}
