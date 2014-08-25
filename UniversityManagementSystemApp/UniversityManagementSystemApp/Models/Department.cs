using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UniversityManagementSystemApp.Models
{
    [ScaffoldTable(true)]
    public class Department
    {
        [DisplayName("Department")]
        public int DepartmentId { get; set; }
        [Required(ErrorMessage = "Code is required.")]
        [StringLength(31, MinimumLength = 2)]
        [Remote("CheckDepartmentCodeUniqueness", "Department", ErrorMessage = "This code already Exits")]
        public string Code { get; set; }
        
        [Required(ErrorMessage = "Name is required.")]
        [MaxLength(63, ErrorMessage = "Maximum 63 characters.")]
        [Remote("CheckDepartmentNameUniqueness", "Department", ErrorMessage = "This name already Exits")]
        public string Name { get; set; }

        public virtual ICollection<Course> Courses { get; set; }
        public virtual ICollection<Teacher> Teachers { get; set; }
        public virtual ICollection<TeacherCourseAssign> TeacherCourseAssigns { get; set; }
        public virtual ICollection<Student> Students { get; set; }
        public virtual ICollection<AllocateClassRoom> AllocateClassRooms { get; set; }
    }
}