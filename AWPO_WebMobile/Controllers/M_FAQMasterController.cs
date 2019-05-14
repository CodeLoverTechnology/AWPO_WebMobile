using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AWPO_WebMobile.DbModel;
using AWPO_WebMobile.App_Code;

namespace AWPO_WebMobile.Controllers
{
    public class M_FAQMasterController : Controller
    {
        private AWPODBEntities db = new AWPODBEntities();

        // GET: M_FAQMaster
        public async Task<ActionResult> Index()
        {
            if (!CommonFunctions.CheckUserAuthentication())
            {
                return RedirectToAction("Login", "Admin");
            }
            return View(await db.M_FAQMaster.ToListAsync());
        }

        // GET: M_FAQMaster/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (!CommonFunctions.CheckUserAuthentication())
            {
                return RedirectToAction("Login", "Admin");
            }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            M_FAQMaster m_FAQMaster = await db.M_FAQMaster.FindAsync(id);
            if (m_FAQMaster == null)
            {
                return HttpNotFound();
            }
            return View(m_FAQMaster);
        }

        // GET: M_FAQMaster/Create
        public ActionResult Create()
        {
            if (!CommonFunctions.CheckUserAuthentication())
            {
                return RedirectToAction("Login", "Admin");
            }
            return View();
        }

        // POST: M_FAQMaster/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Question,Answer,Remarks")] M_FAQMaster m_FAQMaster)
        {
            if (ModelState.IsValid)
            {
                m_FAQMaster.Remarks = "NA";
                m_FAQMaster.CreatedBy = "Admin";
                m_FAQMaster.CreatedDate = DateTime.Now;
                m_FAQMaster.ModifiedBy = "Admin";
                m_FAQMaster.ModifiedDate = DateTime.Now;
                m_FAQMaster.Active = true;
                db.M_FAQMaster.Add(m_FAQMaster);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(m_FAQMaster);
        }

        // GET: M_FAQMaster/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (!CommonFunctions.CheckUserAuthentication())
            {
                return RedirectToAction("Login", "Admin");
            }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            M_FAQMaster m_FAQMaster = await db.M_FAQMaster.FindAsync(id);
            if (m_FAQMaster == null)
            {
                return HttpNotFound();
            }
            return View(m_FAQMaster);
        }

        // POST: M_FAQMaster/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "FAQID,Question,Answer,Remarks")] M_FAQMaster m_FAQMaster)
        {
            if (ModelState.IsValid)
            {
                m_FAQMaster.Remarks = "NA";
                m_FAQMaster.CreatedBy = "Admin";
                m_FAQMaster.CreatedDate = DateTime.Now;
                m_FAQMaster.ModifiedBy = "Admin";
                m_FAQMaster.ModifiedDate = DateTime.Now;
                m_FAQMaster.Active = true;
                db.Entry(m_FAQMaster).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(m_FAQMaster);
        }

        // GET: M_FAQMaster/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (!CommonFunctions.CheckUserAuthentication())
            {
                return RedirectToAction("Login", "Admin");
            }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            M_FAQMaster m_FAQMaster = await db.M_FAQMaster.FindAsync(id);
            if (m_FAQMaster == null)
            {
                return HttpNotFound();
            }
            return View(m_FAQMaster);
        }

        // POST: M_FAQMaster/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            M_FAQMaster m_FAQMaster = await db.M_FAQMaster.FindAsync(id);
            db.M_FAQMaster.Remove(m_FAQMaster);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
