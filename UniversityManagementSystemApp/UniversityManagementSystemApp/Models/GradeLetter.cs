using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UniversityManagementSystemApp.Models
{
    public class GradeLetter
    {
        public int GradeLetterId { get; set; }
        public string Grade { get; set; }
        public virtual ICollection<ResultEntry> ResultEntries { get; set; }
    }
}