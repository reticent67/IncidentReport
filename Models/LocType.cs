using System.Collections.Generic;

namespace IncidentReport.Models
{
    public class LocType
    {
        public int LocTypeID { get; set; }
        public string LocTypeName { get; set; }

        public virtual ICollection<Location> Locations { get; set; }
    }
}
