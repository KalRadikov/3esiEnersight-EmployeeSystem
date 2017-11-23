using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using _3esiEmployeeSystemV1.Models.Employee;

namespace _3esiEmployeeSystemV1.Models
{
    public class EmployeeDBContext : DbContext
    {
        public EmployeeDBContext() : base("EmployeeDBContext")
        {
            this.Configuration.LazyLoadingEnabled = true;
        }
        public System.Data.Entity.DbSet<_3esiEmployeeSystemV1.Models.Employee.Employee> Employees { get; set; }

        public System.Data.Entity.DbSet<_3esiEmployeeSystemV1.Models.Employee.BudgetArea> BudgetAreas { get; set; }

        public System.Data.Entity.DbSet<_3esiEmployeeSystemV1.Models.Employee.Department> Departments { get; set; }

        public System.Data.Entity.DbSet<_3esiEmployeeSystemV1.Models.Employee.HeritageCompany> HeritageCompanies { get; set; }

        public System.Data.Entity.DbSet<_3esiEmployeeSystemV1.Models.Employee.LegalCompany> LegalCompanies { get; set; }

        public System.Data.Entity.DbSet<_3esiEmployeeSystemV1.Models.Employee.Career> Careers { get; set; }

        public System.Data.Entity.DbSet<_3esiEmployeeSystemV1.Models.Employee.Status> Status { get; set; }

        public System.Data.Entity.DbSet<_3esiEmployeeSystemV1.Models.Employee.Benefit> Benefits { get; set; }

        public System.Data.Entity.DbSet<_3esiEmployeeSystemV1.Models.Employee.TrainingCategory> TrainingCategories { get; set; }

        public System.Data.Entity.DbSet<_3esiEmployeeSystemV1.Models.Employee.TrainingType> TrainingTypes { get; set; }

        public System.Data.Entity.DbSet<_3esiEmployeeSystemV1.Models.Employee.Compensation> Compensations { get; set; }

        public System.Data.Entity.DbSet<_3esiEmployeeSystemV1.Models.Employee.Training> Trainings { get; set; }

        public System.Data.Entity.DbSet<_3esiEmployeeSystemV1.Models.Employee.Parking> Parkings { get; set; }

        public System.Data.Entity.DbSet<_3esiEmployeeSystemV1.Models.Employee.ParkingAccess> ParkingAccesses { get; set; }

        public System.Data.Entity.DbSet<_3esiEmployeeSystemV1.Models.Employee.Building> Buildings { get; set; }

        public System.Data.Entity.DbSet<_3esiEmployeeSystemV1.Models.Employee.BuildingAccess> BuildingAccesses { get; set; }

        public System.Data.Entity.DbSet<_3esiEmployeeSystemV1.Models.Employee.CompensationType> CompensationTypes { get; set; }

        public System.Data.Entity.DbSet<_3esiEmployeeSystemV1.Models.Employee.Currency> Currencies { get; set; }

        public System.Data.Entity.DbSet<_3esiEmployeeSystemV1.Models.Employee.EmployeeStatus> EmployeeStatus { get; set; }

        public System.Data.Entity.DbSet<_3esiEmployeeSystemV1.Models.Employee.EmployeeType> EmployeeTypes { get; set; }

        public System.Data.Entity.DbSet<_3esiEmployeeSystemV1.Models.Employee.OverTimeStatus> OverTimeStatus { get; set; }

        public System.Data.Entity.DbSet<_3esiEmployeeSystemV1.Models.Employee.UnionStatus> UnionStatus { get; set; }

        public System.Data.Entity.DbSet<_3esiEmployeeSystemV1.Models.Employee.BenefitType> BenefitTypes { get; set; }

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<EmployeeInfo>()
        //        .HasKey(t => t.EmployeeID);

        //    modelBuilder.Entity<Employee.Employee>();
        //    modelBuilder.Entity<EmployeeInfo>()
        //        .HasRequired(e => e.Employee)
        //        .WithOptional(p => p.EmployeeInfo);
        //}
    }
}