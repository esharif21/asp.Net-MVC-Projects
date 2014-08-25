using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using UniversityManagementSystemApp.Models;

namespace UniversityManagementSystemApp.Controllers
{
    public class EnrollCourseController : Controller
    {
        private UniversityDbContext db = new UniversityDbContext();

        // GET: /EnrollCourse/
        public ActionResult Index()
        {
            var enrollcourses = db.EnrollCourses.Include(e => e.Course).Include(e => e.Student);
            return View(enrollcourses.ToList());
        }

        // GET: /EnrollCourse/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EnrollCourse enrollcourse = db.EnrollCourses.Find(id);
            if (enrollcourse == null)
            {
                return HttpNotFound();
            }
            return View(enrollcourse);
        }

        // GET: /EnrollCourse/Create
        public ActionResult Create()
        {
            ViewBag.CourseId = new SelectList("", "CourseId", "Code");
            ViewBag.StudentId = new SelectList(db.Students, "StudentId", "RegNo");
            return View();
        }

        // POST: /EnrollCourse/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="EnrollCourseId,StudentId,CourseId,Date")] EnrollCourse enrollcourse)
        {
            if (ModelState.IsValid)
            {
                //EnrollCourse courseAlreadyEnrolled = new EnrollCourse();
                var courseAlreadyEnrolled = db.EnrollCourses.Include(ec => ec.Course).Include(ec => ec.Student).Where(ec => ec.StudentId == enrollcourse.StudentId).Where(ec => ec.CourseId == enrollcourse.CourseId).Select(es => es.EnrollCourseId).DefaultIfEmpty(0).Single();
                if (courseAlreadyEnrolled <=0)
                {
                    db.EnrollCourses.Add(enrollcourse);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                var eDate = db.EnrollCourses.Include(ec => ec.Course).Include(ec => ec.Student).Where(ec => ec.StudentId == enrollcourse.StudentId).Where(ec => ec.CourseId == enrollcourse.CourseId).Select(es => es.Date).Single();
                TempData["CourseAlreadyAssignedMessage"] =
            "Hi, " + db.Students.Where(s => s.StudentId == enrollcourse.StudentId).Select(s => s.Name).Single() + "! you already enrolled this course on " + eDate.ToShortDateString() + ", try different course";
            
            }
            ViewBag.CourseId = new SelectList("", "CourseId", "Code", enrollcourse.CourseId);
            ViewBag.StudentId = new SelectList(db.Students, "StudentId", "RegNo", enrollcourse.StudentId);
            return View(enrollcourse);
        }

        // GET: /EnrollCourse/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EnrollCourse enrollcourse = db.EnrollCourses.Find(id);
            if (enrollcourse == null)
            {
                return HttpNotFound();
            }
            ViewBag.CourseId = new SelectList(db.Courses, "CourseId", "Code", enrollcourse.CourseId);
            ViewBag.StudentId = new SelectList(db.Students, "StudentId", "RegNo", enrollcourse.StudentId);
            return View(enrollcourse);
        }

        // POST: /EnrollCourse/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="EnrollCourseId,StudentId,CourseId,Date")] EnrollCourse enrollcourse)
        {
            if (ModelState.IsValid)
            {
                db.Entry(enrollcourse).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CourseId = new SelectList(db.Courses, "CourseId", "Code", enrollcourse.CourseId);
            ViewBag.StudentId = new SelectList(db.Students, "StudentId", "RegNo", enrollcourse.StudentId);
            return View(enrollcourse);
        }

        // GET: /EnrollCourse/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EnrollCourse enrollcourse = db.EnrollCourses.Find(id);
            if (enrollcourse == null)
            {
                return HttpNotFound();
            }
            return View(enrollcourse);
        }

        // POST: /EnrollCourse/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EnrollCourse enrollcourse = db.EnrollCourses.Find(id);
            db.EnrollCourses.Remove(enrollcourse);
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

        public JsonResult GetStudentInfo(int studentId)
        {
            db.Configuration.ProxyCreationEnabled = false;
            var student = db.Students.Include(x => x.Department).FirstOrDefault(x => x.StudentId == studentId);
            var studentRequiredInfo =new {Name = student.Name, Email=student.Email, Dept= student.Department.Name, DeptId=student.Department.DepartmentId};
            return Json(studentRequiredInfo, JsonRequestBehavior.AllowGet);
        }
    }
}
