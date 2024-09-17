using System;
using System.Collections.Generic;

namespace DataAccess.Models
{
    public partial class StaffReport
    {
        public int ReportId { get; set; }
        public string ReportDescription { get; set; } = null!;
        public int StaffId { get; set; }
        public int? EventId { get; set; }

        public virtual Event? Event { get; set; }
        public virtual Employee Staff { get; set; } = null!;
    }
}
