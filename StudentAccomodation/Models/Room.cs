using System.ComponentModel.DataAnnotations;

namespace Student_Accomodation.Models
{
    public class Room
    {
        [Key]
        public int PlaceNo { get; set; }
        public int RentPerSemester { get; set; }
        public bool Occupied { get; set; }
        public int RoomNo { get; set; }
        public int DoritoryNo { get; set; }
        public int AppartNo { get; set; }
    }
}
