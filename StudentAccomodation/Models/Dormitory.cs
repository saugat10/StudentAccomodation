using System.ComponentModel.DataAnnotations;

namespace Student_Accomodation.Models
{
    public class Dormitory
    {
        [Key]
        public int Dormitory_No { get; set; }   

        [Required]
        public string Name { get; set; }   

        [Required]
        public string Address { get; set; }
    }
}
