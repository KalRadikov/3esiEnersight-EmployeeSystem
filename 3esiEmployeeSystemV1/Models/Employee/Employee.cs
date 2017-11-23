using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace _3esiEmployeeSystemV1.Models.Employee
{
    public class Employee
    {
        public int EmployeeID { get; set; }

        public string FullName
        {
            get { return LastName + ", " + FirstName; }
        }

        [Required]
        [StringLength(32, ErrorMessage = "The {0} must be less than {1} characters long")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [StringLength(32, ErrorMessage = "The {0} must be less than {1} characters long")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Middle Name")]
        [StringLength(32, ErrorMessage = "The {0} must be less than {1} characters long")]
        public string MiddleName { get; set; }

        [Required]
        public Gender Gender { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime BirthDate { get; set; }

        [StringLength(32, ErrorMessage = "The {0} must be less than {1} characters long")]
        public string Citizenship { get; set; }

        [Required(ErrorMessage = "Address is required.")]
        [Display(Name = "Address 1")]
        [StringLength(32, ErrorMessage = "The {0} must be less than {1} characters long")]
        public string Address1 { get; set; }


        [Display(Name = "Address 2")]
        [StringLength(32, ErrorMessage = "The {0} must be less than {1} characters long")]
        public string Address2 { get; set; }

        [Required]
        [StringLength(32, ErrorMessage = "The {0} must be less than {1} characters long")]
        public string City { get; set; }

        [Display(Name = "Province/State")]
        [StringLength(32, ErrorMessage = "The {0} must be less than {1} characters long")]
        public string ProvinceState { get; set; }

        [Required]
        [StringLength(32, ErrorMessage = "The {0} must be less than {1} characters long")]
        public string Country { get; set; }

        [DataType(DataType.PostalCode)]
        [Display(Name = "Postal/Zip Code")]
        [StringLength(32, ErrorMessage = "The {0} must be less than {1} characters long")]
        public string PostalZip { get; set; }

        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Home Phone")]
        [StringLength(32, ErrorMessage = "The {0} must be less than {1} characters long")]
        public string HomePhone { get; set; }

        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Mobile Phone")]
        [StringLength(32, ErrorMessage = "The {0} must be less than {1} characters long")]
        public string MobilePhone { get; set; }

        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Office Phone")]
        [StringLength(32, ErrorMessage = "The {0} must be less than {1} characters long")]
        public string OfficePhone { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Hire Date")]
        public DateTime HireDate { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Contract End Date")]
        public DateTime? ContractEndDate { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Termination Date")]
        public DateTime? TerminationDate { get; set; }

        [Display(Name = "Emergency Contact Name")]
        [StringLength(32, ErrorMessage = "The {0} must be less than {1} characters long")]
        public string EmergencyContactName { get; set; }

        [Display(Name = "Emergency Contact Relationship")]
        [StringLength(32, ErrorMessage = "The {0} must be less than {1} characters long")]
        public string EmergencyContactRelationship { get; set; }

        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Emergency Contact Number")]
        [StringLength(32, ErrorMessage = "The {0} must be less than {1} characters long")]
        public string EmergencyContactNumber { get; set; }

        [Display(Name = "Years of Industry Service")]
        public int? YearsIndustryService { get; set; }

       
        //------------------------------ Relationships ------------------------------//

        public virtual List<Career> Careers { get; set; }

        public virtual List<Status> EmployeeStatus { get; set; }

        public virtual List<Benefit> Benefits { get; set; }

        public virtual  List<Training> Trainings { get; set; }

        public virtual List<Compensation> Compensations { get; set; }

        public virtual List<Access> Access { get; set; }

        public virtual List<ParkingAccess> ParkingAccesses { get; set; }

        public virtual List<BuildingAccess> BuildingAccesses { get; set; }


    }
    public enum Gender
    {
        [Display(Name = "Male")]
        M,
        [Display(Name = "Female")]
        F,
        [Display(Name = "Non-identified")]
        N
    }
}
