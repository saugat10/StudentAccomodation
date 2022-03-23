using Student_Accomodation.Models;
using Student_Accomodation.Services.Interfaces;
using System.Collections.Generic;

namespace Student_Accomodation.Services.ADOServices.ADORoomServices
{
    public class ADORoomService : IRoomService
    {
        ADORoom roomService;

        public ADORoomService(ADORoom service) { 
            roomService = service; 
        }

        public IEnumerable<Room> GetAllRooms()
        {
            return roomService.GetAllRooms();
        }
    }
}
