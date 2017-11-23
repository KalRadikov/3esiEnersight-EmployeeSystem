using _3esiEmployeeSystemV1.Models;
using _3esiEmployeeSystemV1.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace _3esiEmployeeSystemV1.Helpers
{
    public class ReportingHelpers
    {
        private static readonly EmployeeDBContext db = new EmployeeDBContext();

        public static IQueryable<EntityGroup> GetDepartmentDashboard()
        {
            IQueryable<EntityGroup> data = from employee in db.Careers
                                           .Include(e => e.Employee.EmployeeStatus.Select(c => c.EmployeeStatus))
                .Where(e => (e.Employee.EmployeeStatus.GroupBy(x => x.EmployeeID)
                    .Select(y => y.OrderByDescending(i => i.EffectiveDate)
                    .FirstOrDefault()).Select(c => c.EmployeeStatus.Name).FirstOrDefault() == "Active") ||
                    (e.Employee.EmployeeStatus.GroupBy(x => x.EmployeeID)
                    .Select(y => y.OrderByDescending(i => i.EffectiveDate)
                    .FirstOrDefault()).Select(c => c.EmployeeStatus.Name).FirstOrDefault() == "Contractor"))
                               .Include(x => x.Employee)
                               .GroupBy(x => x.EmployeeID)
                               .Select(y => y.OrderByDescending(i => i.EffectiveDate)
                               .FirstOrDefault())
                                           group employee by employee.Department.Name into EntityGroup
                                           select new EntityGroup()
                                           {
                                               Department = EntityGroup.Key,
                                               DeptCount = EntityGroup.Count()
                                           };
            return data;
        }

        //------------------------------ Entity Dashboard Query ------------------------------//
        public static IQueryable<EntityGroup> GetEntityDashboard()
        {
            var careers = db.Careers.Include(e => e.Employee.EmployeeStatus.Select(c => c.EmployeeStatus))
                .Where(e =>
                //Select all active employees
                    (e.Employee.EmployeeStatus.GroupBy(x => x.EmployeeID)
                    .Select(y => y.OrderByDescending(i => i.EffectiveDate)
                    .FirstOrDefault()).Select(c => c.EmployeeStatus.Name).FirstOrDefault() == "Active") ||
                    //OR all contract employees
                    (e.Employee.EmployeeStatus.GroupBy(x => x.EmployeeID)
                    .Select(y => y.OrderByDescending(i => i.EffectiveDate)
                    .FirstOrDefault()).Select(c => c.EmployeeStatus.Name).FirstOrDefault() == "Contractor"))
                    // AND Select most recent career records
                    .Include(x => x.Employee)
                    .GroupBy(x => x.EmployeeID)
                    .Select(y => y.OrderByDescending(i => i.EffectiveDate)
                    .FirstOrDefault());

            IQueryable<EntityGroup> data = from employee in careers
                                           group employee by new { employee.BudgetArea.Abbreviation, employee.Department.Name } into EntityGroup
                                           select new EntityGroup()
                                           {
                                               BudgetArea = EntityGroup.Key.Abbreviation,
                                               Department = EntityGroup.Key.Name,
                                               BAreaCount = EntityGroup.Count(),
                                               DeptCount = EntityGroup.Count(),
                                               Employees = careers.Where(e=>e.Department.Name.Equals(EntityGroup.Key.Name)).Select(e=>e.Employee).ToList()
                                           };



            return data;
        }

        //------------------------------ Career List Compiler ------------------------------//
        public static IList<CareerViewModel> GetCareerList()
        {
            var employeeList = (from e in db.Careers.Include(x => x.Employee)
                                join d in db.Departments on e.DepartmentID equals d.ID
                                join b in db.BudgetAreas on e.BudgetAreaID equals b.ID
                                select new CareerViewModel
                                {
                                    LastName = e.Employee.LastName,
                                    FirstName = e.Employee.FirstName,
                                    Department = d.Name,
                                    BudgetArea = b.Name,
                                    Title = e.Title,
                                    Supervisor = e.Supervisor,
                                    EffectiveDate = e.EffectiveDate,
                                    EndDate = e.EndDate
                                }).ToList();
            return employeeList;
        }

        //------------------------------ Status List Compiler ------------------------------//

        public static IList<StatusViewModel> GetStatusList()
        {
            var employeeList = (from e in db.Status.Include(x => x.Employee)
                                select new StatusViewModel
                                {
                                    LastName = e.Employee.LastName,
                                    FirstName = e.Employee.FirstName,
                                    EffectiveDate = e.EffectiveDate,
                                    EndDate = e.EndDate,
                                    HeritageCompany = e.HeritageCompany.Name,
                                    LegalCompany = e.LegalCompany.Name,
                                    EmployeeType = e.EmployeeType.Name,
                                    PercentFullTime = e.PercentFullTime,
                                    OverTimeStatus = e.OverTimeStatus.Name,
                                    UnionStatus = e.UnionStatus.Name,
                                    PayRollNumber = e.PayRollNumber
                                }).ToList();
            return employeeList;
        }

        //------------------------------ Compensation List Compiler ------------------------------//
        public static IList<CompensationViewModel> GetCompensationList()
        {
            var employeeList = (from e in db.Compensations.Include(x => x.Employee)
                                select new CompensationViewModel
                                {
                                    LastName = e.Employee.LastName,
                                    FirstName = e.Employee.FirstName,
                                    EffectiveDate = e.EffectiveDate,
                                    EndDate = e.EndDate,
                                    CompensationType = e.CompensationType.Name,
                                    Amount = e.Amount,
                                    Currency = e.Currency.Name,
                                    ExchangeRate = e.ExchangeRate,
                                    Comment = e.CompensationComment
                                }).ToList();
            return employeeList;
        }

        //------------------------------ Benefit List Compiler ------------------------------//

        public static IList<BenefitViewModel> GetBenefitList()
        {
            var employeeList = (from e in db.Benefits.Include(x => x.Employee)
                                select new BenefitViewModel
                                {
                                    LastName = e.Employee.LastName,
                                    FirstName = e.Employee.FirstName,
                                    EffectiveDate = e.EffectiveDate,
                                    EndDate = e.EndDate,
                                    BenefitPlan = e.BenefitPlan,
                                    BenefitType = e.BenefitType.Name,
                                    Amount = e.Amount,
                                    Currency = e.Currency.Name,
                                    Comment = e.Comment

                                }).ToList();
            return employeeList;
        }

        //------------------------------ Training List Compiler ------------------------------//

        public static IList<TrainingViewModel> GetTrainingList()
        {
            var employeeList = (from e in db.Trainings.Include(x => x.Employee)
                                select new TrainingViewModel
                                {
                                    LastName = e.Employee.LastName,
                                    FirstName = e.Employee.FirstName,
                                    CourseName = e.CourseName,
                                    TrainingType = e.TrainingType.Name,
                                    TrainingCategory = e.TrainingCategory.Name,
                                    OfferedBy = e.OfferedBy,
                                    StartDate = e.StartDate,
                                    EndDate = e.EndDate,
                                    Amount = e.Amount,
                                    Feedback = e.Feedback

                                }).ToList();
            return employeeList;
        }

        //------------------------------ Employee List Compiler ------------------------------//
        public static IList<EmployeeViewModel> GetEmployeeList()
        {
            var employeeList = (from e in db.Employees
                                select new EmployeeViewModel
                                {
                                    LastName = e.LastName,
                                    FirstName = e.FirstName,
                                    MiddleName = e.MiddleName,
                                    Gender = e.Gender,
                                    BirthDate = e.BirthDate,
                                    Citizenship = e.Citizenship,
                                    Address1 = e.Address1,
                                    Address2 = e.Address2,
                                    City = e.City,
                                    ProvinceState = e.ProvinceState,
                                    Country = e.Country,
                                    PostalZip = e.PostalZip,
                                    HomePhone = e.HomePhone,
                                    MobilePhone = e.MobilePhone,
                                    OfficePhone = e.OfficePhone,
                                    HireDate = e.HireDate,
                                    ContractEndDate = e.ContractEndDate,
                                    TerminationDate = e.TerminationDate,
                                    EmergencyContactName = e.EmergencyContactName,
                                    EmergencyContactNumber = e.EmergencyContactNumber,
                                    EmergencyContactRelationship = e.EmergencyContactRelationship,
                                    YearsIndustryService = e.YearsIndustryService ?? 0
                                }).ToList();
            return employeeList;
        }

    }
}