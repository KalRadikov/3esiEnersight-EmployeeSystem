using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using _3esiEmployeeSystemV1.Models.Employee;

namespace _3esiEmployeeSystemV1.ViewModels
{
    public class EntityGroup
    {
        public string Department { get; set; }

        public string BudgetArea { get; set; }

        public IEnumerable<Employee> Employees { get; set; }

        public int EmpCount { get; set; }

        public int DeptCount { get; set; }

        public int BAreaCount { get; set; }

    }
}