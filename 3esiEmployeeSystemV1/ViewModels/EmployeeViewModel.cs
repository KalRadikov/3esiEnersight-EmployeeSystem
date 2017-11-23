using _3esiEmployeeSystemV1.Models.Employee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _3esiEmployeeSystemV1.ViewModels
{
    public class EmployeeViewModel
    {
        public string LastName { get; set; }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public Gender Gender { get; set; }

        public DateTime BirthDate { get; set; }

        public string Citizenship { get; set; }

        public string Address1 { get; set; }

        public string Address2 { get; set; }

        public string City { get; set; }

        public string ProvinceState { get; set; }

        public string Country { get; set; }

        public string PostalZip { get; set; }

        public string HomePhone { get; set; }

        public string MobilePhone { get; set; }

        public string OfficePhone { get; set; }

        public DateTime HireDate { get; set; }

        public DateTime? ContractEndDate { get; set; }

        public DateTime? TerminationDate { get; set; }

        public string EmergencyContactName { get; set; }

        public string EmergencyContactRelationship { get; set; }

        public string EmergencyContactNumber { get; set; }

        public int YearsIndustryService { get; set; }

    }
}