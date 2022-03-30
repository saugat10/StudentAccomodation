using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Student_Accomodation.Models;
using Student_Accomodation.Services.Interfaces;
using StudentAccomodation.ViewModels;
using System.Collections.Generic;

namespace StudentAccomodation.Pages.Students
{
    public class StudentLeasingsModel : PageModel
    {
        public IEnumerable<StudentLeasings> StudentLeasings { get; set; }

        public Student Student { get; set; }

        ILeasingService leasingStudentService;
        IStudentService studentService;
        public StudentLeasingsModel(ILeasingService service, IStudentService sservice) {
            leasingStudentService = service;
            studentService = sservice;
        }

        public void OnGet(int id)
        {
            StudentLeasings = leasingStudentService.GetStudentLeasings(id);
            Student = studentService.GetStudent(id);
        }
    }
}
