using System;
using System.Collections.Generic;

namespace DataAccess.Models
{
    public partial class EventCategory
    {
        public EventCategory()
        {
            Events = new HashSet<Event>();
        }

        public int EventCategoryId { get; set; }
        public string CategoryName { get; set; } = null!;

        public virtual ICollection<Event> Events { get; set; }
    }
}
