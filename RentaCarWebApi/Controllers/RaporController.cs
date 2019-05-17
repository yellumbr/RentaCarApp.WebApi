//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Net;
//using System.Net.Http;
//using System.Web.Http;
//using System.Web.Http.Cors;
//using Business.Concretes;
//using Models.Concretes;
//using RentaCarWebApi.ApiHelpers;

//namespace RentaCarWebApi.Controllers
//{
//    [ApiExceptionAttribute]
//    [BasicAuthentication]
//    [EnableCors("*", "*", "*")]
//    public class RaporController : ApiController
//    {
//        RaporBusiness RaporBusiness = new RaporBusiness();
//        // GET: api/Arac

//        public IHttpActionResult Get()
//        {
//            var Raporler = RaporBusiness.RaporHepsiniSec();
//            return Ok(Raporler);
//        }

//        // GET: api/Arac/5
//        public IHttpActionResult Get(int id)
//        {
//            var Rapor = RaporBusiness.RaporIdSec(id);
//            if (Rapor == null)
//                return NotFound();
//            return Ok(Rapor);
//        }

//        // POST: api/Arac
//        public IHttpActionResult Post([FromBody]Rapor Rapor)
//        {
//            if (ModelState.IsValid)
//            {
//                var olusturulanRapor = RaporBusiness.RaporEkle(Rapor);
//                return CreatedAtRoute("DefaultApi", new { id = olusturulanRapor.RaporID }, olusturulanRapor);
//            }
//            return BadRequest();

//        }

//        // PUT: api/Arac/5
//        public IHttpActionResult Put(int id, [FromBody]Rapor Rapor)
//        {
//            Rapor.RaporID = id;
//            if (RaporBusiness.RaporIdSec(id) == null)
//                return NotFound();
//            else if (ModelState.IsValid == false)
//                return BadRequest();
//            else
//                return Ok(RaporBusiness.RaporGuncelle(Rapor));
//        }

//        // DELETE: api/Arac/5
//        public IHttpActionResult Delete(int id)
//        {
//            if (RaporBusiness.RaporIdSec(id) == null)
//                return NotFound();
//            return Ok(RaporBusiness.RaporIdSil(id));
//        }
//    }
//}
