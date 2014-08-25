using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;

namespace UniversityManagementSystemApp.Models
{
    public class UniversityDbContext : DbContext
    {
        public UniversityDbContext()
            : base("BugBooster")
        {
        }

        public DbSet<Department> Departments { get; set; }
        public DbSet<Semester> Semesters { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Designation> Designations { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<TeacherCourseAssign> TeacherCourseAssigns { get; set; }
        public DbSet<Student> Students { get; set; }

        public DbSet<EnrollCourse> EnrollCourses { get; set; }
        public DbSet<GradeLetter> GradeLetters { get; set; }
        public DbSet<ResultEntry> ResultEntries { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Day> Days { get; set; }
        public DbSet<AllocateClassRoom> AllocateClassRooms { get; set; }

        public System.Data.Entity.DbSet<UniversityManagementSystemApp.Models.ViewModel.ViewCourseStatusModel> ViewCourseStatusModels { get; set; }

        public System.Data.Entity.DbSet<UniversityManagementSystemApp.Models.ViewModel.ViewResultModel> ViewResultModels { get; set; }
    }
}