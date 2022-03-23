using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Student_Accomodation.Models;
using Student_Accomodation.Services.Interfaces;
using System.Collections.Generic;

namespace StudentAccomodation.Pages.Rooms
{
    public class GetRoomsModel : PageModel
    {
        public IEnumerable<Room> Rooms { get; set; }

        IRoomService roomService;

        public GetRoomsModel(IRoomService service)
        {
            roomService = service;
        }
        public void OnGet()
        {
            Rooms = roomService.GetAllRooms();
        }
    }
}
