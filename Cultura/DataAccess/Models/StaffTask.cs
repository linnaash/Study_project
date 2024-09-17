using System;
using System.Collections.Generic;

namespace DataAccess.Models
{
    public partial class StaffTask
    {
        public int TaskId { get; set; }
        public string TaskDescription { get; set; } = null!;
        public int AssignedStaffId { get; set; }

        public virtual Employee AssignedStaff { get; set; } = null!;
    }
}
