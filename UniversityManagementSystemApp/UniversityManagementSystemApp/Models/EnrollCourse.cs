using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Services.Description;

namespace UniversityManagementSystemApp.Models
{
    public class EnrollCourse
    {
        public int EnrollCourseId { get; set; }
        [Required]
        public int StudentId { get; set; }
        public virtual Student Student { get; set; }
        [Required(ErrorMessage = "Select a course")]
        public int CourseId { get; set; }
        public virtual Course Course { get; set; }
        [Required(ErrorMessage = "Date missing")]
        public DateTime Date { get; set; }
    }
}