using System;
using System.ComponentModel.DataAnnotations;

namespace Student_Accomodation.Models
{
    public class Student
    {
        [Key]
        public int StudentNo { get; set; }
        public string SName { get; set; }
        public string SAddress { get; set; }
        public bool HasRoom { get; set; }
        public DateTime RegistrationDate { get; set;}
    }
}
