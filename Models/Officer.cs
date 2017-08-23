using System.Collections.Generic;

namespace IncidentReport.Models
{
    public class Officer
    {
        public int OfficerID { get; set; }
        public string Serial { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Division { get; set; }
        public string Assignment { get; set; }

        public virtual ICollection<ReportOfficer> ReportOfficer { get; set; }
    }
}
