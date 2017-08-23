namespace IncidentReport.Models
{
    public class ReportLocation
    {
        public int ReportLocationID { get; set; }
        public int PersonID { get; set; }
        public int LocationID { get; set; }
        public int LocTypeID { get; set; }

        public Person Person { get; set; }
        public Location Location { get; set; }
        public LocType LocType { get; set; }

    }
}
