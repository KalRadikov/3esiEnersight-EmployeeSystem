using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using _3esiEmployeeSystemV1.Models.Employee;

namespace _3esiEmployeeSystemV1.ViewModels
{
    public class CareerViewModel
    {
        public string LastName { get; set; }

        public string FirstName { get; set; }

        public string BudgetArea { get; set; }

        public string Department { get; set; }

        public string Title { get; set; }

        public string Supervisor { get; set; }

        public DateTime EffectiveDate { get; set; }

        public DateTime? EndDate { get; set; }
    }
}