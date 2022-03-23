using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Student_Accomodation.Models;
using Student_Accomodation.Services.Interfaces;
using System.Collections.Generic;

namespace StudentAccomodation.Pages.Students
{
    public class GetStudentsModel : PageModel
    {
        public IEnumerable<Student> Students { get; set; }

        IStudentService studentService;
        public GetStudentsModel(IStudentService service)
        {
            studentService = service;
        }

        public void OnGet()
        {
            Students = studentService.GetAllStudents();
        }
    }
}
