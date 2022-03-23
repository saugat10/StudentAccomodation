using System;
using System.ComponentModel.DataAnnotations;

namespace Student_Accomodation.Models
{
    public class Apartment
    {
        [Key]
        public int Apartment_No { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public char Types { get; set; }
    }

}
