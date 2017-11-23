using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace _3esiEmployeeSystemV1.Models.Employee
{
    public class Compensation
    {
        public int CompensationID { get; set; }

        [Display(Name = "Employee")]
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

        [Display(Name = "Type")]
        public int CompensationTypeID { get; set; }

        [DataType(DataType.Currency)]
        public decimal Amount { get; set; }

        public int CurrencyID { get; set; }

        [Display(Name = "Exchange Rate")]
        public double ExchangeRate { get; set; }

        [Display(Name = "Comment")]
        public string CompensationComment { get; set; }


        //------------------------------ Relationships ------------------------------//

        public virtual Employee Employee { get; set; }

        public virtual CompensationType CompensationType { get; set; }

        public virtual Currency Currency { get; set; }
    }


    public class CompensationType
    {
        public int ID { get; set; }

        [Display(Name = "Type")]
        [StringLength(32, ErrorMessage = "The {0} must be less than {1} characters long")]
        public string Name { get; set; }

        [StringLength(10, ErrorMessage = "The {0} must be less than {1} characters long")]
        public string Abbreviation { get; set; }

        public virtual List<Compensation> Compensations { get; set; }
    }


    public class Currency
    {
        public int ID { get; set; }

        [Display(Name = "Currency")]
        [StringLength(32, ErrorMessage = "The {0} must be less than {1} characters long")]
        public string Name { get; set; }

        [StringLength(10, ErrorMessage = "The {0} must be less than {1} characters long")]
        public string Abbreviation { get; set; }

        public virtual List<Compensation> Compensations { get; set; }

    }

}