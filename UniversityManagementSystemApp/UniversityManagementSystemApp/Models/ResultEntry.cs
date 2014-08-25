using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UniversityManagementSystemApp.Models
{
    public class ResultEntry
    {
        public int ResultEntryId { get; set; }
        [Required(ErrorMessage = "Select a reg. no.")]
        [Display(Name = "Select Reg. no.")]
        public int StudentId { get; set; }
        public virtual Student Student { get; set; }
        [Required(ErrorMessage = "Select a course")]
        [Display(Name = "Select course")]
        public int CourseId { get; set; }
        public virtual Course Course { get; set; }
        [Required(ErrorMessage = "Grade missing")]
        [Display(Name = "Select grade letter")]
        public int GradeLetterId { get; set; }
        public virtual GradeLetter GradeLetter { get; set; }
    }
}