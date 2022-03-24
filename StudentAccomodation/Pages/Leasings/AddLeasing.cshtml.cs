using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Student_Accomodation.Models;
using Student_Accomodation.Services.Interfaces;
using System.Collections.Generic;

namespace StudentAccomodation.Pages.Leasings
{
    public class AddLeasingModel : PageModel
    {
        [BindProperty]
        public Leasing LeasingRoom { get; set; }
        public IEnumerable<Leasing> Leasing { get; set; }

        ILeasingService leasingSerice;

        public AddLeasingModel(ILeasingService service) { 
            leasingSerice = service;
        }
        public void OnGet(int placeNo)
        {
            Leasing = leasingSerice.GetWaitingStudent(placeNo);
        }
    }
}
