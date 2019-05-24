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
    public class YoneticiController : ApiController
    {
        YoneticiBusiness YoneticiBusiness = new YoneticiBusiness();

        // GET: api/Arac

        public IHttpActionResult Get()
        {
            var Yoneticilar = YoneticiBusiness.YoneticiHepsiniSec();

            return Ok(Yoneticilar);
        }

        // GET: api/Arac/5
        //public IHttpActionResult Get(int id)
        //{
        //    var Yonetici = YoneticiBusiness.YoneticiIdSec(id);
        //    if (Yonetici == null)
        //        return NotFound();
        //    return Ok(Yonetici);
        //}

        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            var Yonetici = YoneticiBusiness.YoneticiKullaniciIdSec(id);
            if (Yonetici == null)
                return NotFound();
            return Ok(Yonetici);
        }

        public IHttpActionResult GetYonetici(int kullaniciID)
        {
            var Yonetici = YoneticiBusiness.YoneticiKullaniciIdSec(kullaniciID);
            if (Yonetici == null)
                return NotFound();
            return Ok(Yonetici);
        }
        // POST: api/Arac
        public IHttpActionResult Post([FromBody]Yonetici Yonetici)
        {
            if (ModelState.IsValid)
            {
                var olusturulanYonetici = YoneticiBusiness.YoneticiEkle(Yonetici);
                return CreatedAtRoute("DefaultApi", new { id = olusturulanYonetici.YoneticiID }, olusturulanYonetici);
            }
            return BadRequest();

        }

        // PUT: api/Arac/5
        public IHttpActionResult Put(int id, [FromBody]Yonetici Yonetici)
        {
            Yonetici.YoneticiID = id;
            if (YoneticiBusiness.YoneticiIdSec(id) == null)
                return NotFound();
            else if (ModelState.IsValid == false)
                return BadRequest();
            else
                return Ok(YoneticiBusiness.YoneticiGuncelle(Yonetici));
        }

        // DELETE: api/Arac/5
        public IHttpActionResult Delete(int id)
        {
            if (YoneticiBusiness.YoneticiIdSec(id) == null)
                return NotFound();
            return Ok(YoneticiBusiness.YoneticiIdSil(id));
        }
    }
}
