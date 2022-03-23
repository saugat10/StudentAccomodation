using Student_Accomodation.Models;
using System.Collections.Generic;

namespace Student_Accomodation.Services.Interfaces
{
    public interface IRoomService
    {
        IEnumerable<Room> GetAllRooms();
    }
}
