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
    public class M_ExamMaterController : Controller
    {
        private AWPODBEntities db = new AWPODBEntities();

        // GET: M_ExamMater
        public async Task<ActionResult> Index()
        {
            if (!CommonFunctions.CheckUserAuthentication())
            {
                return RedirectToAction("Login", "Admin");
            }
            return View(await db.M_ExamMater.ToListAsync());
        }

        // GET: M_ExamMater/Details/5
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
            M_ExamMater m_ExamMater = await db.M_ExamMater.FindAsync(id);
            if (m_ExamMater == null)
            {
                return HttpNotFound();
            }
            return View(m_ExamMater);
        }

        // GET: M_ExamMater/Create
        public ActionResult Create()
        {
            if (!CommonFunctions.CheckUserAuthentication())
            {
                return RedirectToAction("Login", "Admin");
            }
            return View();
        }

        // POST: M_ExamMater/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                M_ExamMater m_ExamMater = new M_ExamMater();
                string StudentImagePath = null;
                if (!string.IsNullOrEmpty(Request.Files["PdfPath"].FileName))
                {
                    string FolderPath = Server.MapPath(Resources.AWPOResources.TextNewImagesPath);// + "\\" + DateTime.Now.Year + "_" + DateTime.Now.Month + "_" + DateTime.Now.Day + "_" + DateTime.Now.DayOfWeek;
                    string FullPathWithFileName = FolderPath + "\\" + Request.Files["PdfPath"].FileName;
                    string FolderPathForImage = Request.Files["PdfPath"].FileName;  //"\\" + DateTime.Now.Year + "_" + DateTime.Now.Month + "_" + DateTime.Now.Day + "_" + DateTime.Now.DayOfWeek + "\\" + Request.Files["StdProfilePicPath"].FileName;
                    if (CommonFunctions.IsFolderExist(FolderPath))
                    {
                        Request.Files["PdfPath"].SaveAs(FullPathWithFileName);
                        StudentImagePath = FolderPathForImage;
                    }
                }
                m_ExamMater.PdfPath = StudentImagePath;
                m_ExamMater.ExamName = collection["ExamName"].ToString();
                m_ExamMater.Location = "NA";
                m_ExamMater.Description = "NA";
                m_ExamMater.CreatedBy = "Admin";
                m_ExamMater.CreatedDate = DateTime.Now;
                m_ExamMater.ModifiedBy = "Admin";
                m_ExamMater.ModifiedDate = DateTime.Now;
                m_ExamMater.Active = true;
                db.M_ExamMater.Add(m_ExamMater);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                ViewBag.Message = "Error Due To : "+ ex.ToString();
            }
            return View();
        }

        // GET: M_ExamMater/Edit/5
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
            M_ExamMater m_ExamMater = await db.M_ExamMater.FindAsync(id);
            if (m_ExamMater == null)
            {
                return HttpNotFound();
            }
            return View(m_ExamMater);
        }

        // POST: M_ExamMater/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit_Post(FormCollection collection)
        {
            try
            {
                M_ExamMater m_ExamMater = new M_ExamMater();
                string StudentImagePath = null;
                if (!string.IsNullOrEmpty(Request.Files["PdfPath"].FileName))
                {
                    string FolderPath = Server.MapPath(Resources.AWPOResources.TextNewImagesPath);// + "\\" + DateTime.Now.Year + "_" + DateTime.Now.Month + "_" + DateTime.Now.Day + "_" + DateTime.Now.DayOfWeek;
                    string FullPathWithFileName = FolderPath + "\\" + Request.Files["PdfPath"].FileName;
                    string FolderPathForImage = Request.Files["PdfPath"].FileName;  //"\\" + DateTime.Now.Year + "_" + DateTime.Now.Month + "_" + DateTime.Now.Day + "_" + DateTime.Now.DayOfWeek + "\\" + Request.Files["StdProfilePicPath"].FileName;
                    if (CommonFunctions.IsFolderExist(FolderPath))
                    {
                        Request.Files["PdfPath"].SaveAs(FullPathWithFileName);
                        StudentImagePath = FolderPathForImage;
                    }
                }
                m_ExamMater.ExamID= Convert.ToInt32(collection["ExamID"]);
                m_ExamMater.PdfPath = StudentImagePath;
                m_ExamMater.ExamName = collection["ExamName"].ToString();
                m_ExamMater.Location = "NA";
                m_ExamMater.Description = "NA";
                m_ExamMater.CreatedBy = "Admin";
                m_ExamMater.CreatedDate = DateTime.Now;
                m_ExamMater.ModifiedBy = "Admin";
                m_ExamMater.ModifiedDate = DateTime.Now;
                m_ExamMater.Active = true;
                db.Entry(m_ExamMater).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewBag.Message = "Error Due To : " + ex.ToString();
            }
            return View();
        }

        // GET: M_ExamMater/Delete/5
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
            M_ExamMater m_ExamMater = await db.M_ExamMater.FindAsync(id);
            if (m_ExamMater == null)
            {
                return HttpNotFound();
            }
            return View(m_ExamMater);
        }

        // POST: M_ExamMater/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            M_ExamMater m_ExamMater = await db.M_ExamMater.FindAsync(id);
            db.M_ExamMater.Remove(m_ExamMater);
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
