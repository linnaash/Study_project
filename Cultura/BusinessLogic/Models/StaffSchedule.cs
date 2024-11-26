using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public partial class StaffSchedule
    {
        public int ScheduleId { get; set; }
        public DateTime ShiftStart { get; set; }
        public DateTime ShiftEnd { get; set; }
        public int StaffId { get; set; }
        public int VenueId { get; set; }

        public virtual Employee Staff { get; set; } = null!;
        public virtual Venue Venue { get; set; } = null!;
    }
}
