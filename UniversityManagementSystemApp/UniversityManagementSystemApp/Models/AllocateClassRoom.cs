using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace UniversityManagementSystemApp.Models
{
    public class AllocateClassRoom
    {
        public int AllocateClassRoomId { get; set; }
        [Required(ErrorMessage = "Please select department")]
        public int DepartmentId { get; set; }
        public virtual Department Department { get; set; }
        [Required(ErrorMessage = "Course cann't be empty")]
        public int CourseId { get; set; }
        public virtual Course Course { get; set; }
        [Required(ErrorMessage = "Select desired room")]
        public int RoomId { get; set; }
        public virtual Room Room { get; set; }
        [Required(ErrorMessage = "Select a day")]
        public int DayId { get; set; }
        public virtual Day Day { get; set; }
        [Required(ErrorMessage = "Please enter start time")]
        //[StringLength(5,ErrorMessage = "Time format HH:MM")]
        [RegularExpression((@"^(20|21|22|23|[01]\d|\d)(([:][0-5]\d){1,2})$"), ErrorMessage = "Please enter a valid time")]
        //[Remote("CheckStartTimeFormat", "AllocateClassRoom", ErrorMessage = "Time format must be HH:MM")]
        //[DisplayFormat(DataFormatString = "{HH:mm}")]
        public string StartTime { get; set; }
            //public string StartTime { get; set; }
        [Required(ErrorMessage = "Please enter end time")]
        [RegularExpression((@"^(20|21|22|23|[01]\d|\d)(([:][0-5]\d){1,2})$"), ErrorMessage = "Please enter a valid time")]
        //[Remote("CheckEndTimeFormat", "AllocateClassRoom", ErrorMessage = "Time format must be HH:MM")]
        public string EndTime { get; set; }

    }
}