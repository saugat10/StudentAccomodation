using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Student_Accomodation.Models;
using Student_Accomodation.Services.Interfaces;
using System;
using System.Collections.Generic;

namespace StudentAccomodation.Pages.Leasings
{
    public class AddLeasingModel : PageModel
    {
        //[BindProperty]
        //public Leasing LeasingRoom { get; set; }

        [BindProperty] public int RoomPlaceNo { get; set; }
        [BindProperty] public Student Student { get; set; }

        [BindProperty] public DateTime DateFrom { get; set; } //= new DateTime(2022, 07, 01);
        [BindProperty] public DateTime DateTo { get; set; } //= new DateTime(2022, 12, 31);

        IStudentService studentService;

        ILeasingService leasingService;

        public AddLeasingModel(IStudentService service, ILeasingService iService) {
            studentService = service;
            leasingService = iService;
        }
        public void OnGet(int placeNo)
        {   
            Student = studentService.GetTopStudent();
            RoomPlaceNo = placeNo;
            DateFrom = new DateTime(2022, 07, 01);
            DateTo = new DateTime(2022, 12, 31);
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            leasingService.AddLeasing(RoomPlaceNo, Student.StudentNo, DateFrom, DateTo);

            //Console.WriteLine(Request.ToString());
            return RedirectToPage("GetLeasings");
        }
    }
}
