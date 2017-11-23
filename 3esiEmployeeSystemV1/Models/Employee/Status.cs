using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _3esiEmployeeSystemV1.Models.Employee
{
    public class Status
    {
        public int StatusID { get; set; }

        [Display(Name = "Employee")]
        public int EmployeeID { get; set; }

        [Display(Name = "Effective Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime EffectiveDate { get; set; }

        [Display(Name = "End Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? EndDate { get; set; }

        [Display(Name = "Heritage Company")]
        public int HeritageCompanyID { get; set; }

        [Display(Name = "Legal Company")]
        public int LegalCompanyID { get; set; }

        [Display(Name = "Status")]
        public int EmployeeStatusID { get; set; }

        [Display(Name = "Employee Type")]
        public int EmployeeTypeID { get; set; }

        [Display(Name = "% Full Time")]
        public double PercentFullTime { get; set; }

        [Display(Name = "Over-Time Status")]
        public int OverTimeStatusID { get; set; }

        [Display(Name = "Union Status")]
        public int UnionStatusID { get; set; }


        [Display(Name = "Payroll Number")]
        [RegularExpression("^[a-zA-Z0-9]*$", ErrorMessage = "Only Letters and Numbers allowed.")]
        [StringLength(32, ErrorMessage = "The {0} must be less than {1} characters long")]
        public string PayRollNumber { get; set; }

        //------------------------------ Relationships ------------------------------//

        public virtual Employee Employee { get; set; }

        public virtual HeritageCompany HeritageCompany { get; set; }

        public virtual LegalCompany LegalCompany { get; set; }

        public virtual EmployeeStatus EmployeeStatus { get; set; }

        public virtual EmployeeType EmployeeType { get; set; }

        public virtual OverTimeStatus OverTimeStatus { get; set; }

        public virtual UnionStatus UnionStatus { get; set; }
    }

    public class HeritageCompany
    {
        public int ID { get; set; }

        [Display(Name = "Heritage Company")]
        [StringLength(32, ErrorMessage = "The {0} must be less than {1} characters long")]
        public string Name { get; set; }

        [StringLength(10, ErrorMessage = "The {0} must be less than {1} characters long")]
        public string Abbreviation { get; set; }

        public virtual List<Status> Statuses { get; set; }


    }

    public class LegalCompany
    {
        public int ID { get; set; }

        [Display(Name = "Legal Company")]
        [StringLength(32, ErrorMessage = "The {0} must be less than {1} characters long")]
        public string Name { get; set; }

        [StringLength(10, ErrorMessage = "The {0} must be less than {1} characters long")]
        public string Abbreviation { get; set; }

        public virtual List<Status> Statuses { get; set; }


    }

    public class EmployeeStatus
    {

        public int ID { get; set; }

        [Display(Name = "Employee Status")]
        [StringLength(32, ErrorMessage = "The {0} must be less than {1} characters long")]
        public string Name { get; set; }

        [StringLength(10, ErrorMessage = "The {0} must be less than {1} characters long")]
        public string Abbreviation { get; set; }

        public virtual List<Status> Status { get; set; }


    };
    public class EmployeeType
    {
        public int ID { get; set; }

        [Display(Name = "Employee Type")]
        [StringLength(32, ErrorMessage = "The {0} must be less than {1} characters long")]
        public string Name { get; set; }

        [StringLength(10, ErrorMessage = "The {0} must be less than {1} characters long")]
        public string Abbreviation { get; set; }

        public virtual List<Status> Status { get; set; }


    };

    public class OverTimeStatus
    {
        public int ID { get; set; }

        [Display(Name = "Over-Time Status")]
        [StringLength(32, ErrorMessage = "The {0} must be less than {1} characters long")]
        public string Name { get; set; }

        [StringLength(10, ErrorMessage = "The {0} must be less than {1} characters long")]
        public string Abbreviation { get; set; }

        public virtual List<Status> Status { get; set; }

    };

    public class UnionStatus
    {
        public int ID { get; set; }

        [Display(Name = "Union Status")]
        [StringLength(32, ErrorMessage = "The {0} must be less than {1} characters long")]
        public string Name { get; set; }

        [StringLength(10, ErrorMessage = "The {0} must be less than {1} characters long")]
        public string Abbreviation { get; set; }

        public virtual List<Status> Status { get; set; }

    };
}