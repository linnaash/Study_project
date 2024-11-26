using System;
using System.Collections.Generic;

namespace DataAccess.Models
{
    public partial class StaffTraining
    {
        public int TrainingId { get; set; }
        public string TrainingName { get; set; } = null!;
        public int StaffId { get; set; }

        public virtual Employee Staff { get; set; } = null!;
    }
}
