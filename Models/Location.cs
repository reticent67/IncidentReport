using System.Collections.Generic;

namespace IncidentReport.Models
{
    public class Location
    {
        public int LocationID { get; set; }
        public int AddressNum { get; set; }
        public string StreetName { get; set; }
        public string UnitNum { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int ZipCode { get; set; }
        public double Lattitude { get; set; }
        public double Longitude { get; set; }

        public virtual ICollection<PersonLocation> PersonLocations { get; set; }
        public virtual ICollection<ReportLocation> ReportLocations { get; set; }
      
    }
}
