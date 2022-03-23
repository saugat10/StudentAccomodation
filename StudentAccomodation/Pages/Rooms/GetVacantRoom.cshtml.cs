using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Student_Accomodation.Models;
using Student_Accomodation.Services.Interfaces;
using System.Collections.Generic;

namespace StudentAccomodation.Pages.Rooms
{
    public class GetVacantRoomModel : PageModel
    {
        public IEnumerable<Room> VacantRoom { get; set; }

        IApartmentService apartmentSerivce;

        public GetVacantRoomModel(IApartmentService service) {
            apartmentSerivce = service;
        }
        public void OnGet(int id)
        {
            VacantRoom = apartmentSerivce.GetVacentRooms(id);
        }
    }
}
