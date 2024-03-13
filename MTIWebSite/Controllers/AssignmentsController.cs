using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MTIWebSite.Models;

namespace MTIWebSite.Controllers
{
    public class AssignmentsController : Controller
    {
        private MTIDatabaseEntities db = new MTIDatabaseEntities();

        // GET: Assignments
        public ActionResult Index()
        {
            var assignments = db.Assignments.Include(a => a.Projects).Include(a => a.Students);
            return View(assignments.ToList());
        }

        // GET: Assignments/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Assignments assignments = db.Assignments.Find(id);
            if (assignments == null)
            {
                return HttpNotFound();
            }
            return View(assignments);
        }

        // GET: Assignments/Create
        public ActionResult Create()
        {
            ViewBag.ProjectCode = new SelectList(db.Projects, "ProjectCode", "ProjectTitle");
            ViewBag.StudentNumber = new SelectList(db.Students, "StudentNumber", "FirstName");
            return View();
        }

        // POST: Assignments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AssignmentId,ProjectCode,StudentNumber,AssignmentDate")] Assignments assignments)
        {
            if (ModelState.IsValid)
            {
                db.Assignments.Add(assignments);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProjectCode = new SelectList(db.Projects, "ProjectCode", "ProjectTitle", assignments.ProjectCode);
            ViewBag.StudentNumber = new SelectList(db.Students, "StudentNumber", "FirstName", assignments.StudentNumber);
            return View(assignments);
        }

        // GET: Assignments/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Assignments assignments = db.Assignments.Find(id);
            if (assignments == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProjectCode = new SelectList(db.Projects, "ProjectCode", "ProjectTitle", assignments.ProjectCode);
            ViewBag.StudentNumber = new SelectList(db.Students, "StudentNumber", "FirstName", assignments.StudentNumber);
            return View(assignments);
        }

        // POST: Assignments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AssignmentId,ProjectCode,StudentNumber,AssignmentDate")] Assignments assignments)
        {
            if (ModelState.IsValid)
            {
                db.Entry(assignments).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProjectCode = new SelectList(db.Projects, "ProjectCode", "ProjectTitle", assignments.ProjectCode);
            ViewBag.StudentNumber = new SelectList(db.Students, "StudentNumber", "FirstName", assignments.StudentNumber);
            return View(assignments);
        }

        // GET: Assignments/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Assignments assignments = db.Assignments.Find(id);
            if (assignments == null)
            {
                return HttpNotFound();
            }
            return View(assignments);
        }

        // POST: Assignments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Assignments assignments = db.Assignments.Find(id);
            db.Assignments.Remove(assignments);
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
