using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Student_Accomodation.Models;
using Student_Accomodation.Services.Interfaces;
using StudentAccomodation.ViewModels;
using System.Collections.Generic;

namespace StudentAccomodation.Pages.Students
{
    public class DeleteStudentModel : PageModel
    {
        [BindProperty]
        public Student Student { get; set; }
        public IEnumerable<StudentLeasings>  StudentLeasing{ get; set; }

        IStudentService studentService;
       

        public DeleteStudentModel(IStudentService service)
        {
            studentService = service;
            
        }
        public void OnGet(int id)
        {
            Student = studentService.GetStudent(id);
        }

        public void OnPost()
        {
            studentService.DeleteStudent(Student.StudentNo);
            Response.Redirect("/Students/GetStudents?type=Student");
        }
    }
}
