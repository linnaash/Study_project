using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public partial class Employee
    {
        public Employee()
        {
            Departments = new HashSet<Department>();
            EmergencyPlans = new HashSet<EmergencyPlan>();
            EventPlannings = new HashSet<EventPlanning>();
            Events = new HashSet<Event>();
            StaffReports = new HashSet<StaffReport>();
            StaffSchedules = new HashSet<StaffSchedule>();
            StaffTasks = new HashSet<StaffTask>();
            StaffTrainings = new HashSet<StaffTraining>();
            StaffWorkTimes = new HashSet<StaffWorkTime>();
        }

        public int EmployeeId { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public int? DepartmentId { get; set; }

        public virtual Department? Department { get; set; }
        public virtual ICollection<Department> Departments { get; set; }
        public virtual ICollection<EmergencyPlan> EmergencyPlans { get; set; }
        public virtual ICollection<EventPlanning> EventPlannings { get; set; }
        public virtual ICollection<Event> Events { get; set; }
        public virtual ICollection<StaffReport> StaffReports { get; set; }
        public virtual ICollection<StaffSchedule> StaffSchedules { get; set; }
        public virtual ICollection<StaffTask> StaffTasks { get; set; }
        public virtual ICollection<StaffTraining> StaffTrainings { get; set; }
        public virtual ICollection<StaffWorkTime> StaffWorkTimes { get; set; }
    }
}
