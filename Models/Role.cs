using System.Collections.Generic;

namespace IncidentReport.Models
{
    public class Role
    {
        public int RoleID { get; set; }
        public string RoleName { get; set; }

        public virtual ICollection<ReportPerson> ReportPersons { get; set; }
    }
}
