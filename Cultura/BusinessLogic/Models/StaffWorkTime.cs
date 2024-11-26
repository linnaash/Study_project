using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public partial class StaffWorkTime
    {
        public int WorkTimeId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int StaffId { get; set; }
        public int? EventId { get; set; }

        public virtual Event? Event { get; set; }
        public virtual Employee Staff { get; set; } = null!;
    }
}
