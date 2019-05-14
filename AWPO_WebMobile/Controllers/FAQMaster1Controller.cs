using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using AWPO_WebMobile.DbModel;

namespace AWPO_WebMobile.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class FAQMaster1Controller : ApiController
    {
        private AWPODBEntities db = new AWPODBEntities();

        // GET: api/FAQMaster1
        [Route("api/FAQMaster1/GetM_FAQMaster")]

        public IQueryable<M_FAQMaster> GetM_FAQMaster()
        {
            return db.M_FAQMaster;
        }
        [Route("api/FAQMaster1/GetM_FAQMaster/id")]
        // GET: api/FAQMaster1/5
        [ResponseType(typeof(M_FAQMaster))]
        public async Task<IHttpActionResult> GetM_FAQMaster(int id)
        {
            M_FAQMaster m_FAQMaster = await db.M_FAQMaster.FindAsync(id);
            if (m_FAQMaster == null)
            {
                return NotFound();
            }

            return Ok(m_FAQMaster);
        }
        [Route("api/FAQMaster1/PutM_FAQMaster")]
        // PUT: api/FAQMaster1/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutM_FAQMaster(int id, M_FAQMaster m_FAQMaster)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != m_FAQMaster.FAQID)
            {
                return BadRequest();
            }

            db.Entry(m_FAQMaster).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!M_FAQMasterExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }
        [Route("api/FAQMaster1/PostM_FAQMaster")]
        // POST: api/FAQMaster1
        [ResponseType(typeof(M_FAQMaster))]
        public async Task<IHttpActionResult> PostM_FAQMaster(M_FAQMaster m_FAQMaster)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.M_FAQMaster.Add(m_FAQMaster);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = m_FAQMaster.FAQID }, m_FAQMaster);
        }

        // DELETE: api/FAQMaster1/5
        [Route("api/FAQMaster1/DeleteM_FAQMaster")]
        [ResponseType(typeof(M_FAQMaster))]
        public async Task<IHttpActionResult> DeleteM_FAQMaster(int id)
        {
            M_FAQMaster m_FAQMaster = await db.M_FAQMaster.FindAsync(id);
            if (m_FAQMaster == null)
            {
                return NotFound();
            }

            db.M_FAQMaster.Remove(m_FAQMaster);
            await db.SaveChangesAsync();

            return Ok(m_FAQMaster);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool M_FAQMasterExists(int id)
        {
            return db.M_FAQMaster.Count(e => e.FAQID == id) > 0;
        }
    }
}