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
    public class OdemeController : ApiController
    {
        OdemeBusiness OdemeBusiness = new OdemeBusiness();
        // GET: api/Arac

        public IHttpActionResult Get()
        {
            var Odemeler = OdemeBusiness.OdemeHepsiniSec();
            return Ok(Odemeler);
        }

        // GET: api/Arac/5
        public IHttpActionResult Get(int id)
        {
            var Odeme = OdemeBusiness.OdemeIdSec(id);
            if (Odeme == null)
                return NotFound();
            return Ok(Odeme);
        }

        // POST: api/Arac
        public IHttpActionResult Post([FromBody]Odeme Odeme)
        {
            if (ModelState.IsValid)
            {
                var olusturulanOdeme = OdemeBusiness.OdemeEkle(Odeme);
                return CreatedAtRoute("DefaultApi", new { id = olusturulanOdeme.OdemeID }, olusturulanOdeme);
            }
            return BadRequest();

        }

        // PUT: api/Arac/5
        public IHttpActionResult Put(int id, [FromBody]Odeme Odeme)
        {
            Odeme.OdemeID = id;
            if (OdemeBusiness.OdemeIdSec(id) == null)
                return NotFound();
            else if (ModelState.IsValid == false)
                return BadRequest();
            else
                return Ok(OdemeBusiness.OdemeGuncelle(Odeme));
        }

        // DELETE: api/Arac/5
        public IHttpActionResult Delete(int id)
        {
            if (OdemeBusiness.OdemeIdSec(id) == null)
                return NotFound();
            return Ok(OdemeBusiness.OdemeIdSil(id));
        }
    }
}
