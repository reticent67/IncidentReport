namespace IncidentReport.Models
{
    public class ReportPerson
    {
        public int ReportPersonID { get; set; }
        public int ReportID { get; set; }
        public int PersonID { get; set; }
        public int RoleID { get; set; }

        public InvestigativeReport Report { get; set; }
        public Person Person { get; set; }
        public Role Role { get; set; }
    }
}
