using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using _3esiEmployeeSystemV1.Models.Employee;

namespace _3esiEmployeeSystemV1.ViewModels
{
    public class EmployeeHistoryData
    {

        public int EmployeeID { get; set; }

        public IEnumerable<Status> Status { get; set; }

        public IEnumerable<Compensation> Compensations { get; set; }

        public IEnumerable<Career> Careers { get; set; }

        public IEnumerable<Benefit> Benefits { get; set; }

        public IEnumerable<Training> Trainings { get; set; }

        public IEnumerable<ParkingAccess> ParkingAccesses { get; set; }

        public IEnumerable<BuildingAccess> BuildingAccesses { get; set; }

        public string Department { get; set; }

        public string BudgetArea { get; set; }
    }
}