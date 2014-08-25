using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UniversityManagementSystemApp.Models
{
    public class Day
    {
        public int DayId { get; set; }
        public string TimeDay { get; set; }
        public virtual ICollection<AllocateClassRoom> AllocateClassRooms { get; set; }
    }
}