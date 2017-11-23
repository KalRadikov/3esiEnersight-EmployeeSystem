namespace _3esiEmployeeSystemV1.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
    using Models.Employee;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Web;

    internal sealed class Configuration : DbMigrationsConfiguration<_3esiEmployeeSystemV1.Models.EmployeeDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "_3esiEmployeeSystemV1.Models.EmployeeDBContext";
        }

        protected override void Seed(_3esiEmployeeSystemV1.Models.EmployeeDBContext context)
        {


            //context.Departments.AddOrUpdate(
            //    x => x.ID,
            //    new Department() { ID = 1, Name = "Executive" },
            //    new Department() { ID = 2, Name = "Finance" },
            //    new Department() { ID = 3, Name = "Corporate Services" },
            //    new Department() { ID = 4, Name = "Information Services" },
            //    new Department() { ID = 5, Name = "Fellows" },
            //    new Department() { ID = 6, Name = "Admin Prod Development" },
            //    new Department() { ID = 7, Name = "R & D" },
            //    new Department() { ID = 8, Name = "Product Management" },
            //    new Department() { ID = 9, Name = "Quality Assurance" },
            //    new Department() { ID = 10, Name = "Global Sales" },
            //    new Department() { ID = 11, Name = "Global Business Development" },
            //    new Department() { ID = 12, Name = "Sales" },
            //    new Department() { ID = 13, Name = "Marketing" },
            //    new Department() { ID = 14, Name = "Global Project Services" },
            //    new Department() { ID = 15, Name = "Admin Project Services" },
            //    new Department() { ID = 16, Name = "Project Services" },
            //    new Department() { ID = 17, Name = "Customer Support" },
            //    new Department() { ID = 18, Name = "Admin Strategic Consulting" },
            //    new Department() { ID = 19, Name = "Strategic Consulting" }
            //    );

            //context.BudgetAreas.AddOrUpdate(
            //    x => x.ID,
            //    new BudgetArea() { ID = 1, Name = "General and Administrative" },
            //    new BudgetArea() { ID = 2, Name = "Product Development" },
            //    new BudgetArea() { ID = 3, Name = "Sales" },
            //    new BudgetArea() { ID = 4, Name = "Marketing" },
            //    new BudgetArea() { ID = 5, Name = "Project Services" },
            //    new BudgetArea() { ID = 6, Name = "Strategic Consulting" }
            //    );

            //context.HeritageCompanies.AddOrUpdate(
            //    x => x.ID,
            //    new HeritageCompany() { ID = 1, Abbreviation = "3eE", Name = "3esi-Enersight" },
            //    new HeritageCompany() { ID = 2, Abbreviation = "3esi", Name = "3es Innovations" },
            //    new HeritageCompany() { ID = 3, Abbreviation = "COGS", Name = "COGS" },
            //    new HeritageCompany() { ID = 4, Abbreviation = "ES", Name = "Enersight" },
            //    new HeritageCompany() { ID = 5, Abbreviation = "PD", Name = "Portfolio Decisions" }
            //    );

            //context.LegalCompanies.AddOrUpdate(
            //    x => x.ID,
            //    new LegalCompany() { ID = 1, Abbreviation = "3es Innov", Name = "3es Innovations Inc." },
            //    new LegalCompany() { ID = 2, Abbreviation = "3esi APAC", Name = "3esi APAC Limited" },
            //    new LegalCompany() { ID = 3, Abbreviation = "3esi Col", Name = "3esi Colombia S.A.S." },
            //    new LegalCompany() { ID = 4, Abbreviation = "3esi Eur", Name = "3esi Europe" },
            //    new LegalCompany() { ID = 5, Abbreviation = "3esi UK", Name = "3esi UK Ltd" },
            //    new LegalCompany() { ID = 6, Abbreviation = "Ener Pty", Name = "Enersight Pty Ltd" },
            //    new LegalCompany() { ID = 7, Abbreviation = "Ener USA", Name = "Enersight (USA) Inc." }
            //    );

            //context.TrainingCategories.AddOrUpdate(
            //    x => x.ID,
            //    new TrainingCategory() { ID = 1, Name = "Leadership" },
            //    new TrainingCategory() { ID = 2, Name = "Sales" },
            //    new TrainingCategory() { ID = 3, Name = "HR" },
            //    new TrainingCategory() { ID = 4, Name = "Development" }
            //    );

            //context.TrainingTypes.AddOrUpdate(
            //    x => x.ID,
            //    new TrainingType() { ID = 1, Name = "Online" },
            //    new TrainingType() { ID = 2, Name = "In-Person" }
            //    );

            //context.Currencies.AddOrUpdate(
            //    x => x.ID,
            //    new Currency() { ID = 1, Name = "CAD" },
            //    new Currency() { ID = 2, Name = "USD" },
            //    new Currency() { ID = 3, Name = "EUR" },
            //    new Currency() { ID = 4, Name = "GBP" },
            //    new Currency() { ID = 5, Name = "NZL" },
            //    new Currency() { ID = 6, Name = "AUD" },
            //    new Currency() { ID = 7, Name = "MXN" }
            //    );

            //context.CompensationTypes.AddOrUpdate(
            //    x => x.ID,
            //    new CompensationType() { ID = 1, Abbreviation = "BG", Name = "General Bonus" },
            //    new CompensationType() { ID = 2, Abbreviation = "BE", Name = "Executive Bonus" },
            //    new CompensationType() { ID = 3, Abbreviation = "BO", Name = "One-time Bonus" },
            //    new CompensationType() { ID = 4, Abbreviation = "BP", Name = "Bonus Percentage" },
            //    new CompensationType() { ID = 5, Abbreviation = "BR", Name = "Referral Bonus" },
            //    new CompensationType() { ID = 6, Abbreviation = "BS", Name = "Service Bonus" },
            //    new CompensationType() { ID = 7, Abbreviation = "C", Name = "Commission" },
            //    new CompensationType() { ID = 8, Abbreviation = "S", Name = "Salary" }
            //    );

            //context.EmployeeStatus.AddOrUpdate(
            //    x => x.ID,
            //    new EmployeeStatus() { ID = 1, Abbreviation = "A", Name = "Active" },
            //    new EmployeeStatus() { ID = 2, Abbreviation = "C", Name = "Contractor" },
            //    new EmployeeStatus() { ID = 3, Abbreviation = "T", Name = "Terminated" }
            //    );

            //context.EmployeeTypes.AddOrUpdate(
            //    x => x.ID,
            //    new EmployeeType { ID = 1, Abbreviation = "FS", Name = "Full-Time Salary" },
            //    new EmployeeType { ID = 2, Abbreviation = "FH", Name = "Full-Time Hourly" },
            //    new EmployeeType { ID = 3, Abbreviation = "PS", Name = "Part-Time Salary" },
            //    new EmployeeType { ID = 4, Abbreviation = "PH", Name = "Part-Time Hourly" },
            //    new EmployeeType { ID = 5, Abbreviation = "SS", Name = "Student Salary" },
            //    new EmployeeType { ID = 6, Abbreviation = "SH", Name = "Student Hourly" }
            //    );

            //context.OverTimeStatus.AddOrUpdate(
            //    x => x.ID,
            //    new OverTimeStatus { ID = 1, Abbreviation = "E", Name = "Exempt" },
            //    new OverTimeStatus { ID = 2, Abbreviation = "O", Name = "Overtime" }
            //    );

            //context.UnionStatus.AddOrUpdate(
            //    x => x.ID,
            //    new UnionStatus { ID = 1, Abbreviation = "U", Name = "Union" },
            //    new UnionStatus { ID = 2, Abbreviation = "N", Name = "Non-Union" }
            //    );

            //context.BenefitTypes.AddOrUpdate(
            //    x => x.ID,
            //    new BenefitType { ID = 1, Name = "Allowance", Abbreviation = "A" },
            //    new BenefitType { ID = 2, Name = "Car Allowance", Abbreviation = "C" },
            //    new BenefitType { ID = 3, Name = "Dental", Abbreviation = "D" },
            //    new BenefitType { ID = 4, Name = "Inclusive", Abbreviation = "I" },
            //    new BenefitType { ID = 5, Name = "Gym", Abbreviation = "G" },
            //    new BenefitType { ID = 6, Name = "Life, AD&D, Ltd", Abbreviation = "L" },
            //    new BenefitType { ID = 7, Name = "Medical", Abbreviation = "M" },
            //    new BenefitType { ID = 8, Name = "Parking", Abbreviation = "P" },
            //    new BenefitType { ID = 9, Name = "Retirement Plan", Abbreviation = "R" },
            //    new BenefitType { ID = 10, Name = "Vision", Abbreviation = "V" },
            //    new BenefitType { ID = 11, Name = "Vacation", Abbreviation = "VA" }

            //    );

            //context.Employees.AddOrUpdate(
            //    x => x.EmployeeID,
            //    new Employee()
            //    {
            //        EmployeeID = 1,
            //        FirstName = "Kaloyan",
            //        LastName = "Radikov",
            //        Gender = Gender.M,
            //        BirthDate = DateTime.Parse("1995-04-28"),
            //        Citizenship = "Canadian",
            //        Address1 = "1392 Falgarwood Dr",
            //        City = "Oakville",
            //        ProvinceState = "ON",
            //        Country = "Canada",
            //        PostalZip = "L6H2S7",
            //        HomePhone = "9058150099",
            //        MobilePhone = "2897729098",
            //        HireDate = DateTime.Parse("2017-05-15"),
            //        YearsIndustryService = 3
            //    },
            //    new Employee()
            //    {
            //        EmployeeID = 2,
            //        FirstName = "Drew",
            //        LastName = "Mahoney",
            //        Gender = Gender.M,
            //        BirthDate = DateTime.Parse("1995-04-28"),
            //        Citizenship = "Canadian",
            //        Address1 = "1392 Falgarwood Dr",
            //        City = "Oakville",
            //        ProvinceState = "ON",
            //        Country = "Canada",
            //        PostalZip = "L6H2S7",
            //        HomePhone = "9058150099",
            //        MobilePhone = "2897729098",
            //        HireDate = DateTime.Parse("2017-05-31"),
            //        YearsIndustryService = 2
            //    }
            //    );




            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
