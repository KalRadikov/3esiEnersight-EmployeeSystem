using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _3esiEmployeeSystemV1.ViewModels
{
    public class CompensationViewModel
    {
        public string LastName { get; set; }

        public string FirstName { get; set; }

        public DateTime EffectiveDate { get; set; }

        public DateTime? EndDate { get; set; }

        public string CompensationType { get; set; }

        public decimal Amount { get; set; }

        public string Currency { get; set; }

        public double ExchangeRate { get; set; }

        public string Comment { get; set; }
    }
}