using System.Collections.Generic;

namespace IncidentReport.Models
{
    public class Crime
    {
        public int CrimeID { get; set; }
        public string CrimeTitle { get; set; }
        public int Section { get; set; } //(i.e. 211, 245, 187... no subsections)
        public string Subsection { get; set; }
        public string Type { get; set; } //Vehicle Code, Penal Code, H&S...
        public string Level { get; set; } //Felony or Misdemeanor
        public int BailAmount { get; set; }

        public virtual ICollection<InvestigativeReport> Reports { get; set; }
    }
}
