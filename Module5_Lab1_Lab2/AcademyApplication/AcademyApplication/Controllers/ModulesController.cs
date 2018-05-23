using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AcademyApplication.Models;

namespace AcademyApplication.Controllers
{
    public class ModulesController : Controller
    {
        private AcademyAppDbContext db = new AcademyAppDbContext();

        // GET: Modules
        public ActionResult Index()
        {
            return View(db.Modules.ToList());
        }

        // GET: Modules/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Module module = db.Modules.Find(id);
            if (module == null)
            {
                return HttpNotFound();
            }
            return View(module);
        }

        // GET: Modules/Create
        public ActionResult Create()
        {
            ViewBag.Courses = db.Courses.ToList();
            return View();
        }

        // POST: Modules/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ModuleId,ModuleName,ModuleDescription,SelectedCourseId")] Module module)
        {
            if (ModelState.IsValid)
            {
                module.Course = db.Courses.Find(module.SelectedCourseId);
                db.Modules.Add(module);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(module);
        }

        // GET: Modules/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Module module = db.Modules.Include(x => x.Course).First(x => x.ModuleId == id);
            if (module == null)
            {
                return HttpNotFound();
            }

            module.SelectedCourseId = module.Course.CourseId;
            ViewBag.Courses = db.Courses.ToList();
            return View(module);
        }

        // POST: Modules/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ModuleId,ModuleName,ModuleDescription,SelectedCourseId")] Module module)
        {
            if (ModelState.IsValid)
            {
                db.Entry(module).State = EntityState.Modified;
                db.SaveChanges();

                var dbModule = db.Modules.Include(x => x.Course).FirstOrDefault(x => x.ModuleId == module.ModuleId);

                if (dbModule != null &&
                    dbModule.Course.CourseId != module.SelectedCourseId)
                {
                    var oldCourse = db.Courses.Include(x => x.Modules)
                        .FirstOrDefault(x => x.CourseId == dbModule.Course.CourseId);

                    oldCourse?.Modules.Remove(dbModule);

                    var newCourse = db.Courses.Include(x => x.Modules)
                        .FirstOrDefault(x => x.CourseId == module.SelectedCourseId);

                    newCourse?.Modules.Add(dbModule);
                    db.SaveChanges();
                }

                return RedirectToAction("Index");
            }

            return View(module);
        }

        // GET: Modules/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Module module = db.Modules.Find(id);
            if (module == null)
            {
                return HttpNotFound();
            }
            return View(module);
        }

        // POST: Modules/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Module module = db.Modules.Find(id);
            db.Modules.Remove(module);
            db.SaveChanges();
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
