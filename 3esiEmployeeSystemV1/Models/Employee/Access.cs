using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _3esiEmployeeSystemV1.Models.Employee
{
    public class Access
    {
        public int AccessID { get; set; }

    }

    public class Building
    {
        public int BuildingID { get; set; }

        [StringLength(32, ErrorMessage = "The {0} must be less than {1} characters long")]
        public string Name { get; set; }

        [StringLength(32, ErrorMessage = "The {0} must be less than {1} characters long")]
        public string Address { get; set; }

        [StringLength(32, ErrorMessage = "The {0} must be less than {1} characters long")]
        public string Company { get; set; }

        [DataType(DataType.PhoneNumber, ErrorMessage = "Provided phone number not valid")]
        [StringLength(32, ErrorMessage = "The {0} must be less than {1} characters long")]
        public string ContactNumber { get; set; }

        //------------------------------ Relationships ------------------------------//

        public virtual List<BuildingAccess> BuildingAccesses { get; set; }
    }

    public class Parking
    {
        public int ParkingID { get; set; }

        [StringLength(32, ErrorMessage = "The {0} must be less than {1} characters long")]
        public string Address { get; set; }

        [StringLength(32, ErrorMessage = "The {0} must be less than {1} characters long")]
        public string Company { get; set; }

        [DataType(DataType.PhoneNumber, ErrorMessage = "Provided phone number not valid")]
        [StringLength(32, ErrorMessage = "The {0} must be less than {1} characters long")]
        public string ContactNumber { get; set; }

        public int? SpacesAvailable { get; set; }

        //------------------------------ Relationships ------------------------------//

        public virtual List<ParkingAccess> ParkingAccesses { get; set; }
    }

    public class BuildingAccess
    {
        public int BuildingAccessID { get; set; }

        public int EmployeeID { get; set; }

        public int BuildingID { get; set; }

        [Display(Name = "Effective Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime EffectiveDate { get; set; }

        public string CardIDNumber { get; set; }

        //------------------------------ Relationships ------------------------------//

        public virtual Employee Employee { get; set; }

        public virtual Building Building { get; set; }

    }

    public class ParkingAccess
    {
        public int ParkingAccessID { get; set; }

        public int EmployeeID { get; set; }

        public int ParkingID { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime EffectiveDate { get; set; }

        public string CarModel { get; set; }

        public string PlateNumber { get; set; }

        //------------------------------ Relationships ------------------------------//

        public virtual Employee Employee { get; set; }

        public virtual Parking Parking { get; set; }

    }

}