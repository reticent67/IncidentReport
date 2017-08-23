using System;
using System.Collections.Generic;

namespace IncidentReport.Models
{
    public class Person
    {
        public int PersonID { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Middle { get; set; }
        public DateTime BirthDate { get; set; }
        public string DriversLicense { get; set; }
        public int Height { get; set; }
        public int Weight { get; set; }
        public int PhoneNumber { get; set; }
        public string EmailAddress { get; set; }



        //Info pulled from Joined Tables
        
        public int GenderID { get; set; }
        public int EthnicityID { get; set; }
        public int HairID { get; set; }
        public int EyeColorID { get; set; }

        public virtual ICollection<PersonLocation> Locations { get; set; }
        public virtual ICollection<ReportPerson> ReportPersons { get; set; }
       
        
    }
}
