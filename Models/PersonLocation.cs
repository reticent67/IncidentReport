namespace IncidentReport.Models
{
    public class PersonLocation
    {
        public int PersonLocationID { get; set; }
        public int PersonID { get; set; }
        public int LocationID { get; set; }
        public int LocTypeID { get; set; }

        public Person Person { get; set; }
        public Location Location { get; set; }
        public Role Role { get; set; }
    }
}
