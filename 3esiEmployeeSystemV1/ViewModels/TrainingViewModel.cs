using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _3esiEmployeeSystemV1.ViewModels
{
    public class TrainingViewModel
    {

        public string LastName { get; set; }

        public string FirstName { get; set; }

        public string CourseName { get; set; }

        public string TrainingType { get; set; }

        public string TrainingCategory { get; set; }

        public string OfferedBy { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public decimal Amount { get; set; }

        public string Feedback { get; set; }
    }
}