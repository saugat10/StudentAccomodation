using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Student_Accomodation.Models;
using Student_Accomodation.Services.Interfaces;
using System.Collections.Generic;

namespace StudentAccomodation.Pages.Leasings
{
    public class GetLeasingsModel : PageModel
    {
        public IEnumerable<Leasing> Leasings {get; set;}

        ILeasingService leasingService;

        public GetLeasingsModel(ILeasingService service) { 
            this.leasingService = service;
        }
        public void OnGet()
        {
            Leasings = leasingService.GetAllLeasing();
        }
    }
}
