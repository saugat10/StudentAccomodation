using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using Student_Accomodation.Models;
using Student_Accomodation.Services.Interfaces;

namespace Student_Accomodation.Pages.Apartments
{
    public class GetApartmentsModel : PageModel
    {
        public IEnumerable<Apartment> Apartments { get; set; }

        private IApartmentService apartmentService;

        public GetApartmentsModel(IApartmentService service) { 
            apartmentService = service;
        }
        public void OnGet()
        {
            Apartments = apartmentService.GetAllApartments();
        }
    }
}
