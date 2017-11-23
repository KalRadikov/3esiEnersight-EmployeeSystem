using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace _3esiEmployeeSystemV1.Models.Employee
{
    public class Career
    {

        public int CareerID { get; set; }

        public int EmployeeID { get; set; }

        public string Title { get; set; }

        public int DepartmentID { get; set; }

        public int BudgetAreaID { get; set; }

        public string Supervisor { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Effective Date")]
        public DateTime EffectiveDate { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "End Date")]
        public DateTime? EndDate { get; set; }

        //------------------------------ Relationships ------------------------------//

        public virtual Employee Employee { get; set; }

        [Display(Name = "Department")]
        public virtual Department Department { get; set; }

        [Display(Name = "Budget Area")]
        public virtual BudgetArea BudgetArea { get; set; }
    }

    public class Department
    {
        public int ID { get; set; }

        [Display(Name = "Department Name")]
        [StringLength(32, ErrorMessage = "The {0} must be less than {1} characters long")]
        public string Name { get; set; }

        [StringLength(10, ErrorMessage = "The {0} must be less than {1} characters long")]
        public string Abbreviation { get; set; }

        public virtual List<Career> Careers { get; set; } 
    }

    public class BudgetArea
    {
        public int ID { get; set; }

        [Display(Name = "Budget Area Name")]
        [StringLength(32, ErrorMessage = "The {0} must be less than {1} characters long")]
        public string Name { get; set; }

        [StringLength(10, ErrorMessage = "The {0} must be less than {1} characters long")]
        public string Abbreviation { get; set; }

        public virtual List<Career> Careers { get; set; }
    }
}