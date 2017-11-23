using _3esiEmployeeSystemV1.Models.Employee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _3esiEmployeeSystemV1.ViewModels
{
    public class EmployeeIndexData
    {
        public PagedList.IPagedList<Employee> Employees { get; set; }

        public IEnumerable<Status> Status { get; set; }

        public IEnumerable<Compensation> Compensations { get; set; }

        public IEnumerable<Career> Careers { get; set; }

        public IEnumerable<Benefit> Benefits { get; set; }

        public IEnumerable<Training> Trainings { get; set; }

        public IEnumerable<ParkingAccess> ParkingAccesses { get; set; }

        public IEnumerable<BuildingAccess> BuildingAccesses { get; set; }

    }
}