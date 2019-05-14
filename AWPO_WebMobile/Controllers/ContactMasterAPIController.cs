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
using System.Web.Http.Description;
using AWPO_WebMobile.DbModel;
using System.Web.Http.Cors;

namespace AWPO_WebMobile.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ContactMasterAPIController : ApiController
    {
        private AWPODBEntities db = new AWPODBEntities();

        // GET: api/ContactMasterAPI
        [Route("api/ContactMasterAPI/GetM_ContactMaster")]
        public IQueryable<M_ContactMaster> GetM_ContactMaster()
        {
            return db.M_ContactMaster;
        }

        // GET: api/ContactMasterAPI/5
        [Route("api/ContactMasterAPI/GetM_ContactMaster")]
        [ResponseType(typeof(M_ContactMaster))]
        public async Task<IHttpActionResult> GetM_ContactMaster(int id)
        {
            M_ContactMaster m_ContactMaster = await db.M_ContactMaster.FindAsync(id);
            if (m_ContactMaster == null)
            {
                return NotFound();
            }

            return Ok(m_ContactMaster);
        }

        // PUT: api/ContactMasterAPI/5
        [Route("api/ContactMasterAPI/PutM_ContactMaster")]
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutM_ContactMaster(int id, M_ContactMaster m_ContactMaster)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != m_ContactMaster.ContactID)
            {
                return BadRequest();
            }

            db.Entry(m_ContactMaster).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!M_ContactMasterExists(id))
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

        // POST: api/ContactMasterAPI
        [Route("api/ContactMasterAPI/PostM_ContactMaster")]
        [ResponseType(typeof(M_ContactMaster))]
        public async Task<IHttpActionResult> PostM_ContactMaster(M_ContactMaster m_ContactMaster)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.M_ContactMaster.Add(m_ContactMaster);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = m_ContactMaster.ContactID }, m_ContactMaster);
        }

        // DELETE: api/ContactMasterAPI/5
        [Route("api/ContactMasterAPI/DeleteM_ContactMaster")]
        [ResponseType(typeof(M_ContactMaster))]
        public async Task<IHttpActionResult> DeleteM_ContactMaster(int id)
        {
            M_ContactMaster m_ContactMaster = await db.M_ContactMaster.FindAsync(id);
            if (m_ContactMaster == null)
            {
                return NotFound();
            }

            db.M_ContactMaster.Remove(m_ContactMaster);
            await db.SaveChangesAsync();

            return Ok(m_ContactMaster);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool M_ContactMasterExists(int id)
        {
            return db.M_ContactMaster.Count(e => e.ContactID == id) > 0;
        }
    }
}