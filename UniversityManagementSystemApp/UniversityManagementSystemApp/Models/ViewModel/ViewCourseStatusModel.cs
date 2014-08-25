using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UniversityManagementSystemApp.Models.ViewModel
{
    public class ViewCourseStatusModel
    {
        public int Id { get; set; }
        public string Code { get; set; }
        [Display(Name = "Name/Title")]
        public string NameOrTitle { get; set; }
        public string Semester { get; set; }
        [Display(Name = "Assigned To")]
        public string AssignedTo { get; set; }
    }
}