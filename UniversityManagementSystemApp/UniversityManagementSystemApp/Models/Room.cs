using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

namespace UniversityManagementSystemApp.Models
{
    public class Room
    {
        public int RoomId { get; set; }
        public string RoomNo { get; set; }
        [DefaultValue(0)]
        public int RoomStatus { get; set; }
        public virtual ICollection<AllocateClassRoom> AllocateClassRooms { get; set; }
    }
}