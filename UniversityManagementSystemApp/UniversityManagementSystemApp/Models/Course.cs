using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UniversityManagementSystemApp.Models
{
    public class Course
    {
        [Display(Name = "Course")]
        public int CourseId { get; set; }
        [Required(ErrorMessage = "Code is required.")]
        [StringLength(63, MinimumLength = 2)]
        [Remote("CheckCourseCodeUniqueness", "Course", ErrorMessage = "This code already Exits")]
        public string Code { get; set; }
        
        [Required(ErrorMessage = "Name is required.")]
        [StringLength(127, MinimumLength = 2)]
        [Remote("CheckCourseNameUniqueness", "Course", ErrorMessage = "This name already Exits")]
        public string Name { get; set; }
        [Required]
        public double Credit { get; set; }
        public string Description { get; set; }
        [Required(ErrorMessage = "Please select department")]
        public int DepartmentId { get; set; }
        public virtual Department Department { get; set; }
        [Required(ErrorMessage = "Please select semester")]
        public int SemesterId { get; set; }
        public virtual Semester Semester { get; set; }
        [DefaultValue(0)]
        public int CourseStatus { get; set; }
        public virtual ICollection<TeacherCourseAssign> TeacherCourseAssigns { get; set; }
        public virtual ICollection<EnrollCourse> EnrollCourses { get; set; }
        public virtual ICollection<ResultEntry> ResultEntries { get; set; }
        public virtual ICollection<AllocateClassRoom> AllocateClassRooms { get; set; }

    }
}