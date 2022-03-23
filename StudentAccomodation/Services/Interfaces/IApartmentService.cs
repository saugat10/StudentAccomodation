using Student_Accomodation.Models;
using System.Collections.Generic;

namespace Student_Accomodation.Services.Interfaces
{
    public interface IApartmentService
    {
        IEnumerable<Apartment> GetAllApartments();
        IEnumerable<Room> GetVacentRooms(int id, string type);
    }
}
