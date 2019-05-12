using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Business.Concretes;
using Models.Concretes;
using RentaCarWebApi.ApiHelpers;

namespace RentaCarWebApi.Controllers
{
    [ApiExceptionAttribute]
    public class SirketController : ApiController
    {
        SirketBusiness sirketBusiness = new SirketBusiness();
        // GET: api/Arac
        [Authorize]
        public IHttpActionResult Get()
        {
            var sirketler = sirketBusiness.SirketHepsiniSec();
            return Ok(sirketler);
        }

        // GET: api/Arac/5
        public IHttpActionResult Get(int id)
        {
            var sirket = sirketBusiness.SirketIdSec(id);
            if (sirket == null)
                return NotFound();
            return Ok(sirket);
        }

        // POST: api/Arac
        public IHttpActionResult Post([FromBody]Sirket sirket)
        {
            if(ModelState.IsValid)
            {
                var olusturulanSirket = sirketBusiness.SirketEkle(sirket);
                return CreatedAtRoute("DefaultApi", new { id = olusturulanSirket.SirketID }, olusturulanSirket);
            }  
            return BadRequest();

        }

        // PUT: api/Arac/5
        public IHttpActionResult Put(int id,[FromBody]Sirket sirket)
        {
            sirket.SirketID = id;
            if (sirketBusiness.SirketIdSec(id) == null)
                return NotFound();
            else if (ModelState.IsValid == false)
                return BadRequest();
            else
                return Ok(sirketBusiness.SirketGuncelle(sirket));
        }

        // DELETE: api/Arac/5
        public IHttpActionResult Delete(int id)
        {
            if (sirketBusiness.SirketIdSec(id) == null)
                return NotFound();
            return Ok(sirketBusiness.SirketIdSil(id));
        }
    }
}
