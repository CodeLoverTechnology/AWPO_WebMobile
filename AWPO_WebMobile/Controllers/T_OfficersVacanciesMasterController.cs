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
    public class T_OfficersVacanciesMasterController : Controller
    {
        private AWPODBEntities db = new AWPODBEntities();
        CommonFunctions ObjCommonFunctions = new CommonFunctions();

        // GET: T_OfficersVacanciesMaster
        public ActionResult Index_officers_Vacancies()
        {
            if (!CommonFunctions.CheckUserAuthentication())
            {
                return RedirectToAction("Login", "Admin");
            }
            var VacancyList = from s in db.T_OfficersVacanciesMaster.Where(s=>s.TypOfVacancy=="1").OrderByDescending(s=>s.OfficersVacancyID) select s;
            IList<T_OfficersVacanciesMaster> ObjList = new List<T_OfficersVacanciesMaster>();
            foreach (var vacanciesMaster in VacancyList)
            {
                T_OfficersVacanciesMaster Obj = new T_OfficersVacanciesMaster();
                //string vac= CommonFunctions.getVacancyTypeById(Convert.ToInt32(vacanciesMaster.TypOfVacancy)); ;
                //Obj.TypOfVacancy = vac;
                Obj.OfficersVacancyID = vacanciesMaster.OfficersVacancyID;
                Obj.CompanyName = vacanciesMaster.CompanyName;
                Obj.NoOfPost = vacanciesMaster.NoOfPost;
                Obj.Post = vacanciesMaster.Post;
                Obj.Salary = vacanciesMaster.Salary;
                Obj.Location = vacanciesMaster.Location;
                Obj.QR = vacanciesMaster.QR;
                Obj.PostedDate = vacanciesMaster.PostedDate;
                Obj.LastDate = vacanciesMaster.LastDate;
                Obj.Exam_InterviewDate = vacanciesMaster.Exam_InterviewDate;
                Obj.Remarks = vacanciesMaster.Remarks;
                ObjList.Add(Obj);
            };
            return View(ObjList);
            //return View(await db.T_OfficersVacanciesMaster.ToListAsync());
        }

        public ActionResult Index_JCO_OCR()
        {
            if (!CommonFunctions.CheckUserAuthentication())
            {
                return RedirectToAction("Login", "Admin");
            }
            var VacancyList = from s in db.T_OfficersVacanciesMaster.Where(s => s.TypOfVacancy == "2").OrderByDescending(s => s.OfficersVacancyID) select s;
            IList<T_OfficersVacanciesMaster> ObjList = new List<T_OfficersVacanciesMaster>();
            foreach (var vacanciesMaster in VacancyList)
            {
                T_OfficersVacanciesMaster Obj = new T_OfficersVacanciesMaster();
                Obj.OfficersVacancyID = vacanciesMaster.OfficersVacancyID;
                Obj.CompanyName = vacanciesMaster.CompanyName;
                Obj.NoOfPost = vacanciesMaster.NoOfPost;
                Obj.Post = vacanciesMaster.Post;
                Obj.Salary = vacanciesMaster.Salary;
                Obj.Location = vacanciesMaster.Location;
                Obj.QR = vacanciesMaster.QR;
                Obj.PostedDate = vacanciesMaster.PostedDate;
                Obj.LastDate = vacanciesMaster.LastDate;
                Obj.Exam_InterviewDate = vacanciesMaster.Exam_InterviewDate;
                Obj.Remarks = vacanciesMaster.Remarks;
                ObjList.Add(Obj);
            };
            return View(ObjList);
            //return View(await db.T_OfficersVacanciesMaster.ToListAsync());
        }

        public ActionResult Index_Govt_Comp()
        {
            if (!CommonFunctions.CheckUserAuthentication())
            {
                return RedirectToAction("Login", "Admin");
            }
            var VacancyList = from s in db.T_OfficersVacanciesMaster.Where(s => s.TypOfVacancy == "3").OrderByDescending(s => s.OfficersVacancyID) select s;
            IList<T_OfficersVacanciesMaster> ObjList = new List<T_OfficersVacanciesMaster>();
            foreach (var vacanciesMaster in VacancyList)
            {
                T_OfficersVacanciesMaster Obj = new T_OfficersVacanciesMaster();
                Obj.OfficersVacancyID = vacanciesMaster.OfficersVacancyID;
                Obj.CompanyName = vacanciesMaster.CompanyName;
                Obj.NoOfPost = vacanciesMaster.NoOfPost;
                Obj.Post = vacanciesMaster.Post;
                Obj.Salary = vacanciesMaster.Salary;
                Obj.Location = vacanciesMaster.Location;
                Obj.QR = vacanciesMaster.QR;
                Obj.PostedDate = vacanciesMaster.PostedDate;
                Obj.LastDate = vacanciesMaster.LastDate;
                Obj.Exam_InterviewDate = vacanciesMaster.Exam_InterviewDate;
                Obj.Remarks = vacanciesMaster.Remarks;
                ObjList.Add(Obj);
            };
            return View(ObjList);
            //return View(await db.T_OfficersVacanciesMaster.ToListAsync());
        }

        // GET: T_OfficersVacanciesMaster/Details/5
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
            T_OfficersVacanciesMaster t_OfficersVacanciesMaster = await db.T_OfficersVacanciesMaster.FindAsync(id);
            if (t_OfficersVacanciesMaster == null)
            {
                return HttpNotFound();
            }
            return View(t_OfficersVacanciesMaster);
        }

        // GET: T_OfficersVacanciesMaster/Create
        public ActionResult Create_officers_Vacancies()
        {
            if (!CommonFunctions.CheckUserAuthentication())
            {
                return RedirectToAction("Login", "Admin");
            }

            return View();
        }

        // POST: T_OfficersVacanciesMaster/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create_officers_Vacancies([Bind(Include = "CompanyName,NoOfPost,Post,Salary,Location,QR,PostedDate,LastDate,Exam_InterviewDate,Remarks")] T_OfficersVacanciesMaster t_OfficersVacanciesMaster)
        {
            if (ModelState.IsValid)
            {
                t_OfficersVacanciesMaster.TypOfVacancy = "1";
                t_OfficersVacanciesMaster.CreatedBy = "Admin";
                t_OfficersVacanciesMaster.CreatedDate = DateTime.Now;
                t_OfficersVacanciesMaster.ModifiedBy = "Admin";
                t_OfficersVacanciesMaster.ModifiedDate = DateTime.Now;
                t_OfficersVacanciesMaster.Active = true;
                db.T_OfficersVacanciesMaster.Add(t_OfficersVacanciesMaster);
                await db.SaveChangesAsync();
                return RedirectToAction("Index_officers_Vacancies");
            }
            return View(t_OfficersVacanciesMaster);
        }

        // GET: T_OfficersVacanciesMaster/Create
        public ActionResult Create_JCO_OCR()
        {
            if (!CommonFunctions.CheckUserAuthentication())
            {
                return RedirectToAction("Login", "Admin");
            }

            return View();
        }

        // POST: T_OfficersVacanciesMaster/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create_JCO_OCR([Bind(Include = "CompanyName,NoOfPost,Post,Salary,Location,QR,PostedDate,LastDate,Exam_InterviewDate,Remarks")] T_OfficersVacanciesMaster t_OfficersVacanciesMaster)
        {
            if (ModelState.IsValid)
            {
                t_OfficersVacanciesMaster.TypOfVacancy = "2";
                t_OfficersVacanciesMaster.CreatedBy = "Admin";
                t_OfficersVacanciesMaster.CreatedDate = DateTime.Now;
                t_OfficersVacanciesMaster.ModifiedBy = "Admin";
                t_OfficersVacanciesMaster.ModifiedDate = DateTime.Now;
                t_OfficersVacanciesMaster.Active = true;
                db.T_OfficersVacanciesMaster.Add(t_OfficersVacanciesMaster);
                await db.SaveChangesAsync();
                return RedirectToAction("Index_JCO_OCR");
            }
            return View(t_OfficersVacanciesMaster);
        }


        // GET: T_OfficersVacanciesMaster/Create
        public ActionResult Create_Govt_Comp()
        {
            if (!CommonFunctions.CheckUserAuthentication())
            {
                return RedirectToAction("Login", "Admin");
            }
            return View();
        }

        // POST: T_OfficersVacanciesMaster/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create_Govt_Comp([Bind(Include = "CompanyName,NoOfPost,Post,Salary,Location,QR,PostedDate,LastDate,Exam_InterviewDate,Remarks")] T_OfficersVacanciesMaster t_OfficersVacanciesMaster)
        {
            if (ModelState.IsValid)
            {
                t_OfficersVacanciesMaster.TypOfVacancy = "3";
                t_OfficersVacanciesMaster.CreatedBy = "Admin";
                t_OfficersVacanciesMaster.CreatedDate = DateTime.Now;
                t_OfficersVacanciesMaster.ModifiedBy = "Admin";
                t_OfficersVacanciesMaster.ModifiedDate = DateTime.Now;
                t_OfficersVacanciesMaster.Active = true;
                db.T_OfficersVacanciesMaster.Add(t_OfficersVacanciesMaster);
                await db.SaveChangesAsync();
                return RedirectToAction("Index_Govt_Comp");
            }
            return View(t_OfficersVacanciesMaster);
        }


        // GET: T_OfficersVacanciesMaster/Edit/5
        public async Task<ActionResult> Edit_officers_Vacancies(int? id)
        {
            if (!CommonFunctions.CheckUserAuthentication())
            {
                return RedirectToAction("Login", "Admin");
            }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            T_OfficersVacanciesMaster t_OfficersVacanciesMaster = await db.T_OfficersVacanciesMaster.FindAsync(id);
            if (t_OfficersVacanciesMaster == null)
            {
                return HttpNotFound();
            }
            return View(t_OfficersVacanciesMaster);
        }

        public async Task<ActionResult> Edit_JCO_OCR(int? id)
        {
            if (!CommonFunctions.CheckUserAuthentication())
            {
                return RedirectToAction("Login", "Admin");
            }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            T_OfficersVacanciesMaster t_OfficersVacanciesMaster = await db.T_OfficersVacanciesMaster.FindAsync(id);
            if (t_OfficersVacanciesMaster == null)
            {
                return HttpNotFound();
            }
            return View(t_OfficersVacanciesMaster);
        }
        public async Task<ActionResult> Edit_Govt_Comp(int? id)
        {
            if (!CommonFunctions.CheckUserAuthentication())
            {
                return RedirectToAction("Login", "Admin");
            }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            T_OfficersVacanciesMaster t_OfficersVacanciesMaster = await db.T_OfficersVacanciesMaster.FindAsync(id);
            if (t_OfficersVacanciesMaster == null)
            {
                return HttpNotFound();
            }
            return View(t_OfficersVacanciesMaster);
        }

        // POST: T_OfficersVacanciesMaster/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit_officers_Vacancies([Bind(Include = "OfficersVacancyID,CompanyName,NoOfPost,Post,Salary,Location,QR,PostedDate,LastDate,Exam_InterviewDate,Remarks")] T_OfficersVacanciesMaster t_OfficersVacanciesMaster)
        {
            if (ModelState.IsValid)
            {
                t_OfficersVacanciesMaster.TypOfVacancy = "1";
                t_OfficersVacanciesMaster.CreatedBy = "Admin";
                t_OfficersVacanciesMaster.CreatedDate = DateTime.Now;
                t_OfficersVacanciesMaster.ModifiedBy = "Admin";
                t_OfficersVacanciesMaster.ModifiedDate = DateTime.Now;
                t_OfficersVacanciesMaster.Active = true;
                db.Entry(t_OfficersVacanciesMaster).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index_officers_Vacancies");
            }
            return View(t_OfficersVacanciesMaster);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit_JCO_OCR([Bind(Include = "OfficersVacancyID,CompanyName,NoOfPost,Post,Salary,Location,QR,PostedDate,LastDate,Exam_InterviewDate,Remarks")] T_OfficersVacanciesMaster t_OfficersVacanciesMaster)
        {
            if (ModelState.IsValid)
            {
                t_OfficersVacanciesMaster.TypOfVacancy = "2";
                t_OfficersVacanciesMaster.CreatedBy = "Admin";
                t_OfficersVacanciesMaster.CreatedDate = DateTime.Now;
                t_OfficersVacanciesMaster.ModifiedBy = "Admin";
                t_OfficersVacanciesMaster.ModifiedDate = DateTime.Now;
                t_OfficersVacanciesMaster.Active = true;
                db.Entry(t_OfficersVacanciesMaster).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index_JCO_OCR");
            }
            return View(t_OfficersVacanciesMaster);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit_Govt_Comp([Bind(Include = "OfficersVacancyID,CompanyName,NoOfPost,Post,Salary,Location,QR,PostedDate,LastDate,Exam_InterviewDate,Remarks")] T_OfficersVacanciesMaster t_OfficersVacanciesMaster)
        {
            if (ModelState.IsValid)
            {
                t_OfficersVacanciesMaster.TypOfVacancy = "3";
                t_OfficersVacanciesMaster.CreatedBy = "Admin";
                t_OfficersVacanciesMaster.CreatedDate = DateTime.Now;
                t_OfficersVacanciesMaster.ModifiedBy = "Admin";
                t_OfficersVacanciesMaster.ModifiedDate = DateTime.Now;
                t_OfficersVacanciesMaster.Active = true;
                db.Entry(t_OfficersVacanciesMaster).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index_Govt_Comp");
            }
            return View(t_OfficersVacanciesMaster);
        }

        // GET: T_OfficersVacanciesMaster/Delete/5
        public async Task<ActionResult> Delete_Officers_Vacancies(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            T_OfficersVacanciesMaster t_OfficersVacanciesMaster = await db.T_OfficersVacanciesMaster.FindAsync(id);
            if (t_OfficersVacanciesMaster == null)
            {
                return HttpNotFound();
            }
            return View(t_OfficersVacanciesMaster);
        }
        public async Task<ActionResult> Delete_JCO_OCR(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            T_OfficersVacanciesMaster t_OfficersVacanciesMaster = await db.T_OfficersVacanciesMaster.FindAsync(id);
            if (t_OfficersVacanciesMaster == null)
            {
                return HttpNotFound();
            }
            return View(t_OfficersVacanciesMaster);
        }
        public async Task<ActionResult> Delete_Govt_Comp(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            T_OfficersVacanciesMaster t_OfficersVacanciesMaster = await db.T_OfficersVacanciesMaster.FindAsync(id);
            if (t_OfficersVacanciesMaster == null)
            {
                return HttpNotFound();
            }
            return View(t_OfficersVacanciesMaster);
        }

        // POST: T_OfficersVacanciesMaster/Delete/5
        [HttpPost, ActionName("Delete_Govt_Comp")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete_Govt_Comp_Post(int id)
        {
            T_OfficersVacanciesMaster t_OfficersVacanciesMaster = await db.T_OfficersVacanciesMaster.FindAsync(id);
            db.T_OfficersVacanciesMaster.Remove(t_OfficersVacanciesMaster);
            await db.SaveChangesAsync();
            return RedirectToAction("Index_Govt_Comp");
        }
        // POST: T_OfficersVacanciesMaster/Delete/5
        [HttpPost, ActionName("Delete_Officers_Vacancies")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete_Officers_Vacancies_Post(int id)
        {
            T_OfficersVacanciesMaster t_OfficersVacanciesMaster = await db.T_OfficersVacanciesMaster.FindAsync(id);
            db.T_OfficersVacanciesMaster.Remove(t_OfficersVacanciesMaster);
            await db.SaveChangesAsync();
            return RedirectToAction("Index_officers_Vacancies");
        }
        // POST: T_OfficersVacanciesMaster/Delete/5
        [HttpPost, ActionName("Delete_JCO_OCR")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete_JCO_OCR_Post(int id)
        {
            T_OfficersVacanciesMaster t_OfficersVacanciesMaster = await db.T_OfficersVacanciesMaster.FindAsync(id);
            db.T_OfficersVacanciesMaster.Remove(t_OfficersVacanciesMaster);
            await db.SaveChangesAsync();
            return RedirectToAction("Index_JCO_OCR");
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
