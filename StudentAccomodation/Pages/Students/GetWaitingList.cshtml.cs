using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Student_Accomodation.Models;
using Student_Accomodation.Services.Interfaces;
using System.Collections.Generic;

namespace StudentAccomodation.Pages.Students
{
    public class GetWaitingListModel : PageModel
    {
        public IEnumerable<Student> WaitingList { get; set; }

        IStudentService studentService;
        public GetWaitingListModel(IStudentService service) { 
            studentService = service;
        }
        public void OnGet(string type)
        {
            WaitingList = studentService.GetAllStudents(type);
        }
    }
}
