using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Student_Accomodation.Models;
using Student_Accomodation.Services.Interfaces;
using System.Collections;
using System.Collections.Generic;

namespace StudentAccomodation.Pages.Dormitories
{
    public class GetDormotoriesModel : PageModel
    {
        public IEnumerable<Dormitory> Dormotory { get; set; }

        private IDormitoryService dormitoryService;

        public GetDormotoriesModel(IDormitoryService service) {
            dormitoryService = service;
        }
        public void OnGet()
        {
            Dormotory = dormitoryService.GetAllDormitory();
        }
    }
}
