using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace _3esiEmployeeSystemV1.Models.Employee
{
    public class Benefit
    {
        public int BenefitID { get; set; }

        public int EmployeeID { get; set; }

        [Required]
        [Display(Name = "Effective Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime EffectiveDate { get; set; }

        [Display(Name = "End Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? EndDate { get; set; }

        [Display(Name = "Benefit Plan")]
        [StringLength(32, ErrorMessage = "The {0} must be less than {1} characters long")]
        public string BenefitPlan { get; set; }

        public int BenefitTypeID { get; set; }

        [DataType(DataType.Currency)]
        public decimal Amount { get; set; }

        public int CurrencyID { get; set; }

        public string Comment { get; set; }

        //------------------------------ Relationships ------------------------------//

        public virtual Employee Employee { get; set; }

        public virtual BenefitType BenefitType { get; set; }

        public virtual Currency Currency { get; set; }



    }
    public class BenefitType
    {

        public int ID { get; set; }

        [Display(Name = "Benefit Type")]
        [StringLength(32, ErrorMessage = "The {0} must be less than {1} characters long")]
        public string Name { get; set; }

        [StringLength(10, ErrorMessage = "The {0} must be less than {1} characters long")]
        public string Abbreviation { get; set; }

        public virtual List<Benefit> Benefits { get; set; }

    };
}