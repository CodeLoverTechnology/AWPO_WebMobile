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
    public class ExamMaterAPIController : ApiController
    {
        private AWPODBEntities db = new AWPODBEntities();

        // GET: api/ExamMaterAPI
        [Route("api/ExamMaterAPI/GetM_ExamMater")]
        public IQueryable<M_ExamMater> GetM_ExamMater()
        {
            return db.M_ExamMater;
        }

        // GET: api/ExamMaterAPI/5
        [Route("api/ExamMaterAPI/GetM_ExamMater")]
        [ResponseType(typeof(M_ExamMater))]
        public async Task<IHttpActionResult> GetM_ExamMater(int id)
        {
            M_ExamMater m_ExamMater = await db.M_ExamMater.FindAsync(id);
            if (m_ExamMater == null)
            {
                return NotFound();
            }

            return Ok(m_ExamMater);
        }

        // PUT: api/ExamMaterAPI/5
        [Route("api/ExamMaterAPI/PutM_ExamMater")]
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutM_ExamMater(int id, M_ExamMater m_ExamMater)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != m_ExamMater.ExamID)
            {
                return BadRequest();
            }

            db.Entry(m_ExamMater).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!M_ExamMaterExists(id))
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

        // POST: api/ExamMaterAPI
        [Route("api/ExamMaterAPI/PostM_ExamMater")]
        [ResponseType(typeof(M_ExamMater))]
        public async Task<IHttpActionResult> PostM_ExamMater(M_ExamMater m_ExamMater)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.M_ExamMater.Add(m_ExamMater);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = m_ExamMater.ExamID }, m_ExamMater);
        }

        // DELETE: api/ExamMaterAPI/5
        [Route("api/ExamMaterAPI/DeleteM_ExamMater")]
        [ResponseType(typeof(M_ExamMater))]
        public async Task<IHttpActionResult> DeleteM_ExamMater(int id)
        {
            M_ExamMater m_ExamMater = await db.M_ExamMater.FindAsync(id);
            if (m_ExamMater == null)
            {
                return NotFound();
            }

            db.M_ExamMater.Remove(m_ExamMater);
            await db.SaveChangesAsync();

            return Ok(m_ExamMater);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool M_ExamMaterExists(int id)
        {
            return db.M_ExamMater.Count(e => e.ExamID == id) > 0;
        }
    }
}