using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace IncidentReport.Models
{
    public class InvestigativeReport
    {
        [Key]
        public int ReportID { get; set; }
        public int ReportNum { get; set; }
        public int IncidentNum { get; set; }
        public string Title { get; set; }
        public int ReportingDistrict { get; set; }
        public DateTime ReportDate { get; set; }
        public TimeSpan ReportTime { get; set; }
        public DateTime OccurranceDate { get; set; }
        public TimeSpan OccurranceTime { get; set; }
        public string MoBox { get; set; }
        public string Narrative { get; set; }
       
        
        //Navigation Properties
        public Crime Crime { get; set; }
        public virtual ICollection<ReportLocation> OccurranceLocation{ get; set; }
        public virtual ICollection<ReportPerson> InvolvedPersons { get; set; }
        public virtual ICollection<ReportOfficer> ReportingEmployee { get; set; }
    }
}
