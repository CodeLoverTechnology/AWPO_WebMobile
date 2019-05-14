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
    public class OfficersVacanciesMasterAPIController : ApiController
    {
        private AWPODBEntities db = new AWPODBEntities();

        // GET: api/OfficersVacanciesMasterAPI
        [Route("api/OfficersVacanciesMasterAPI/GetT_OfficersVacanciesMaster")]
        public IQueryable<T_OfficersVacanciesMaster> GetT_OfficersVacanciesMaster()
        {
            return db.T_OfficersVacanciesMaster.Where(x => x.LastDate >= DateTime.Now).OrderByDescending(x=>x.OfficersVacancyID);
        }

        // GET: api/OfficersVacanciesMasterAPI/5
        [Route("api/OfficersVacanciesMasterAPI/GetT_OfficersVacanciesMaster/id")]
        [ResponseType(typeof(T_OfficersVacanciesMaster))]
        public async Task<IHttpActionResult> GetT_OfficersVacanciesMaster(int id)
        {
            T_OfficersVacanciesMaster t_OfficersVacanciesMaster = await db.T_OfficersVacanciesMaster.FindAsync(id);
            if (t_OfficersVacanciesMaster == null)
            {
                return NotFound();
            }

            return Ok(t_OfficersVacanciesMaster);
        }

        // PUT: api/OfficersVacanciesMasterAPI/5
        [Route("api/OfficersVacanciesMasterAPI/PutT_OfficersVacanciesMaster")]
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutT_OfficersVacanciesMaster(int id, T_OfficersVacanciesMaster t_OfficersVacanciesMaster)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != t_OfficersVacanciesMaster.OfficersVacancyID)
            {
                return BadRequest();
            }

            db.Entry(t_OfficersVacanciesMaster).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!T_OfficersVacanciesMasterExists(id))
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

        // POST: api/OfficersVacanciesMasterAPI
        [Route("api/OfficersVacanciesMasterAPI/PostT_OfficersVacanciesMaster")]
        [ResponseType(typeof(T_OfficersVacanciesMaster))]
        public async Task<IHttpActionResult> PostT_OfficersVacanciesMaster(T_OfficersVacanciesMaster t_OfficersVacanciesMaster)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.T_OfficersVacanciesMaster.Add(t_OfficersVacanciesMaster);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = t_OfficersVacanciesMaster.OfficersVacancyID }, t_OfficersVacanciesMaster);
        }

        // DELETE: api/OfficersVacanciesMasterAPI/5
        [Route("api/OfficersVacanciesMasterAPI/DeleteT_OfficersVacanciesMaster")]
        [ResponseType(typeof(T_OfficersVacanciesMaster))]
        public async Task<IHttpActionResult> DeleteT_OfficersVacanciesMaster(int id)
        {
            T_OfficersVacanciesMaster t_OfficersVacanciesMaster = await db.T_OfficersVacanciesMaster.FindAsync(id);
            if (t_OfficersVacanciesMaster == null)
            {
                return NotFound();
            }

            db.T_OfficersVacanciesMaster.Remove(t_OfficersVacanciesMaster);
            await db.SaveChangesAsync();

            return Ok(t_OfficersVacanciesMaster);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool T_OfficersVacanciesMasterExists(int id)
        {
            return db.T_OfficersVacanciesMaster.Count(e => e.OfficersVacancyID == id) > 0;
        }
    }
}