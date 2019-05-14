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
    public class M_ContactMasterController : Controller
    {
        private AWPODBEntities db = new AWPODBEntities();

        // GET: M_ContactMaster
        public async Task<ActionResult> Index()
        {
            if (!CommonFunctions.CheckUserAuthentication())
            {
                return RedirectToAction("Login", "Admin");
            }
            return View(await db.M_ContactMaster.ToListAsync());
        }

        // GET: M_ContactMaster/Details/5
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
            M_ContactMaster m_ContactMaster = await db.M_ContactMaster.FindAsync(id);
            if (m_ContactMaster == null)
            {
                return HttpNotFound();
            }
            return View(m_ContactMaster);
        }

        // GET: M_ContactMaster/Create
        public ActionResult Create()
        {
            if (!CommonFunctions.CheckUserAuthentication())
            {
                return RedirectToAction("Login", "Admin");
            }
            return View();
        }

        // POST: M_ContactMaster/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "PlacementNode,TelephoneNo,Email")] M_ContactMaster m_ContactMaster)
        {
            if (ModelState.IsValid)
            {
                m_ContactMaster.Address = "NA";
                m_ContactMaster.Website = "NA";
                m_ContactMaster.PlacementHeadName = "NA";
                m_ContactMaster.ContactNo = "NA";
                m_ContactMaster.EmailID = "NA";
                m_ContactMaster.Description = "NA";
                m_ContactMaster.CreatedBy = "Admin";
                m_ContactMaster.CreatedDate = DateTime.Now;
                m_ContactMaster.ModifiedBy = "Admin";
                m_ContactMaster.ModifiedDate = DateTime.Now;
                m_ContactMaster.Active = true;
                db.M_ContactMaster.Add(m_ContactMaster);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(m_ContactMaster);
        }

        // GET: M_ContactMaster/Edit/5
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
            M_ContactMaster m_ContactMaster = await db.M_ContactMaster.FindAsync(id);
            if (m_ContactMaster == null)
            {
                return HttpNotFound();
            }
            return View(m_ContactMaster);
        }

        // POST: M_ContactMaster/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ContactID,PlacementNode,TelephoneNo,Email")] M_ContactMaster m_ContactMaster)
        {
            if (ModelState.IsValid)
            {
                m_ContactMaster.Address = "NA";
                m_ContactMaster.Website = "NA";
                m_ContactMaster.PlacementHeadName = "NA";
                m_ContactMaster.ContactNo = "NA";
                m_ContactMaster.EmailID = "NA";
                m_ContactMaster.Description = "NA";
                m_ContactMaster.CreatedBy = "Admin";
                m_ContactMaster.CreatedDate = DateTime.Now;
                m_ContactMaster.ModifiedBy = "Admin";
                m_ContactMaster.ModifiedDate = DateTime.Now;
                m_ContactMaster.Active = true;
                db.Entry(m_ContactMaster).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(m_ContactMaster);
        }

        // GET: M_ContactMaster/Delete/5
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
            M_ContactMaster m_ContactMaster = await db.M_ContactMaster.FindAsync(id);
            if (m_ContactMaster == null)
            {
                return HttpNotFound();
            }
            return View(m_ContactMaster);
        }

        // POST: M_ContactMaster/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            M_ContactMaster m_ContactMaster = await db.M_ContactMaster.FindAsync(id);
            db.M_ContactMaster.Remove(m_ContactMaster);
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
