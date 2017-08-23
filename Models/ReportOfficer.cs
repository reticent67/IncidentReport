namespace IncidentReport.Models
{
    public class ReportOfficer
    {
        public int ReportOfficerID { get; set; }
        public int ReportID { get; set; }
        public int OfficerID { get; set; }

        public InvestigativeReport Report { get; set; }
        public Officer Officer { get; set; }
    }
}
