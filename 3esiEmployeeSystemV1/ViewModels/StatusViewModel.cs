using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _3esiEmployeeSystemV1.ViewModels
{
    public class StatusViewModel
    {
        public string LastName { get; set; }

        public string FirstName { get; set; }

        public DateTime EffectiveDate { get; set; }

        public DateTime? EndDate { get; set; }

        public string HeritageCompany { get; set; }

        public string LegalCompany { get; set; }

        public string EmployeeType { get; set; }

        public double PercentFullTime { get; set; }

        public string OverTimeStatus { get; set; }

        public string UnionStatus { get; set; }

        public string PayRollNumber { get; set; }
    }
}