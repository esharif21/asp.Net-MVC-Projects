using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using UniversityManagementSystemApp.Models;
using UniversityManagementSystemApp.Models.ViewModel;

namespace UniversityManagementSystemApp.Controllers
{
    public class ResultEntryController : Controller
    {
        private UniversityDbContext db = new UniversityDbContext();

        // GET: /ResultEntry/
        public ActionResult Index()
        {
            var resultentries = db.ResultEntries.Include(r => r.Course).Include(r => r.GradeLetter).Include(r => r.Student);
            ViewBag.StudentId = new SelectList(db.ResultEntries.Include(s =>s.Student), "StudentId", "RegNo");
            return View(resultentries.ToList());
        }

        // GET: /ResultEntry/Create
        public ActionResult ViewResult()
        {
            ViewBag.StudentId = new SelectList(db.Students, "StudentId", "RegNo");
            return View();
            //var enrollcourses = db.EnrollCourses.Include(e => e.Course).Include(e => e.Student);
            //return View(enrollcourses.ToList());
        }

        public PartialViewResult GetEnrollCourseAndResult(int studentId)
        {
            List<ViewResultModel> viewResultList = new List<ViewResultModel>();
            var enrolledCourseList = new List<EnrollCourse>();
            enrolledCourseList = db.EnrollCourses.Include(c => c.Course).Where(s => s.StudentId == studentId).ToList();
            foreach (var anEnrolledCourse in enrolledCourseList)
            {
                ViewResultModel aViewREsultRow = new ViewResultModel();
                aViewREsultRow.Id = anEnrolledCourse.CourseId;
                aViewREsultRow.CourseCode = anEnrolledCourse.Course.Code;
                aViewREsultRow.Name = anEnrolledCourse.Course.Name;
                aViewREsultRow.Grade = CheckIfEnrolledCourseHasAGradeAndGetGrade(anEnrolledCourse.CourseId, anEnrolledCourse.StudentId);
                viewResultList.Add(aViewREsultRow);
            }
            if (viewResultList.Count == 0)
                TempData["NoCourseFound"] = "No enrolled course found for this student";
            return PartialView("~/Views/Shared/_ViewResult.cshtml", viewResultList); 
        }

        private string CheckIfEnrolledCourseHasAGradeAndGetGrade(int courseId, int studentId)
        {
            var grade = db.ResultEntries.Include(re=> re.GradeLetter).Where(re => re.CourseId.Equals(courseId))
                .Where(re => re.StudentId.Equals(studentId)).Select(re => re.GradeLetter.Grade)
                .SingleOrDefault();
            if (grade == null)
                return "No result yet";
            return grade;
        }


        // GET: /ResultEntry/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ResultEntry resultentry = db.ResultEntries.Find(id);
            if (resultentry == null)
            {
                return HttpNotFound();
            }
            return View(resultentry);
        }

        // GET: /ResultEntry/Create
        public ActionResult Create()
        {
            ViewBag.CourseId = new SelectList("", "CourseId", "Code");
            ViewBag.GradeLetterId = new SelectList(db.GradeLetters, "GradeLetterId", "Grade");
            ViewBag.StudentId = new SelectList(db.Students, "StudentId", "RegNo");
            return View();
        }

        // POST: /ResultEntry/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="ResultEntryId,StudentId,CourseId,GradeLetterId")] ResultEntry resultentry)
        {
            if (ModelState.IsValid)
            {
                var resultAlreadyEntried = db.ResultEntries.Include(ec => ec.Course).Include(ec => ec.Student).Where(ec => ec.StudentId == resultentry.StudentId).Where(ec => ec.CourseId == resultentry.CourseId).Select(es => es.ResultEntryId).DefaultIfEmpty(0).Single();
                if (resultAlreadyEntried <= 0)
                {
                    db.ResultEntries.Add(resultentry);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                string result =
                db.ResultEntries.Where(s => s.StudentId == resultentry.StudentId).Where(s => s.CourseId == resultentry.CourseId)
                    .Select(s => s.GradeLetter.Grade)
                    .Single();
                TempData["resultAlreadyEntriedMessage"] = "Hey! this course already entried with " + result + ", try different course";
            
            }

            ViewBag.CourseId = new SelectList("", "CourseId", "Code", resultentry.CourseId);
            ViewBag.GradeLetterId = new SelectList(db.GradeLetters, "GradeLetterId", "Grade", resultentry.GradeLetterId);
            ViewBag.StudentId = new SelectList(db.Students, "StudentId", "RegNo", resultentry.StudentId);
            return View(resultentry);
        }

        // GET: /ResultEntry/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ResultEntry resultentry = db.ResultEntries.Find(id);
            if (resultentry == null)
            {
                return HttpNotFound();
            }
            ViewBag.CourseId = new SelectList(db.Courses, "CourseId", "Code", resultentry.CourseId);
            ViewBag.GradeLetterId = new SelectList(db.GradeLetters, "GradeLetterId", "Grade", resultentry.GradeLetterId);
            ViewBag.StudentId = new SelectList(db.Students, "StudentId", "RegNo", resultentry.StudentId);
            return View(resultentry);
        }

        // POST: /ResultEntry/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="ResultEntryId,StudentId,CourseId,GradeLetterId")] ResultEntry resultentry)
        {
            if (ModelState.IsValid)
            {
                db.Entry(resultentry).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CourseId = new SelectList(db.Courses, "CourseId", "Code", resultentry.CourseId);
            ViewBag.GradeLetterId = new SelectList(db.GradeLetters, "GradeLetterId", "Grade", resultentry.GradeLetterId);
            ViewBag.StudentId = new SelectList(db.Students, "StudentId", "RegNo", resultentry.StudentId);
            return View(resultentry);
        }

        // GET: /ResultEntry/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ResultEntry resultentry = db.ResultEntries.Find(id);
            if (resultentry == null)
            {
                return HttpNotFound();
            }
            return View(resultentry);
        }

        // POST: /ResultEntry/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ResultEntry resultentry = db.ResultEntries.Find(id);
            db.ResultEntries.Remove(resultentry);
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
