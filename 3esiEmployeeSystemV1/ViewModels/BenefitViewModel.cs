using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _3esiEmployeeSystemV1.ViewModels
{
    public class BenefitViewModel
    {
        public string LastName { get; set; }

        public string FirstName { get; set; }

        public DateTime EffectiveDate { get; set; }

        public DateTime? EndDate { get; set; }

        public string BenefitPlan { get; set; }

        public string BenefitType { get; set; }

        public decimal Amount { get; set; }

        public string Currency { get; set; }

        public string Comment { get; set; }
    }
}