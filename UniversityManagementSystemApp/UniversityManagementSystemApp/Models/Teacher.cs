using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;

namespace UniversityManagementSystemApp.Models
{
    public class Teacher
    {
        public int TeacherId { get; set; }
        
        [Required(ErrorMessage = "Name is required.")]
        [StringLength(63, MinimumLength = 2)]
        public string Name { get; set; }
        public string Address { get; set; }
        
        [Required(ErrorMessage = "Email is required.")]
        [StringLength(127, MinimumLength = 2)]
        [Remote("CheckTeacherEmailUniquness", "Teacher", ErrorMessage = "This email already Exits")]
        [EmailAddress]
        public string Email { get; set; }
        public string ContactNo { get; set; }
        [Required(ErrorMessage = "Please select designation")]
        public int DesignationId { get; set; }
        public virtual Designation Designation { get; set; }
        
        [Required(ErrorMessage = "Please select department")]
        public int DepartmentId { get; set; }
        public virtual Department Department { get; set; }
        [Required(ErrorMessage = "Credit missing")]
        public double Credit { get; set; }
        public virtual ICollection<TeacherCourseAssign> TeacherCourseAssigns { get; set; }
    }
}