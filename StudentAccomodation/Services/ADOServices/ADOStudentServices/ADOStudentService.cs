using Student_Accomodation.Models;
using Student_Accomodation.Services.Interfaces;
using System.Collections.Generic;

namespace Student_Accomodation.Services.ADOServices.ADOStudentServices
{
    public class ADOStudentService : IStudentService
    {
        ADOStudent studentService;

        public ADOStudentService(ADOStudent service)
        {
            studentService = service;
        }
        public IEnumerable<Student> GetAllStudents(string type)
        {
            return studentService.GetAllStudents(type);
       }

        public Student GetTopStudent()
        {
            return studentService.GetTopStudent();
        }

        public Student GetStudent(int id) { 
            return studentService.GetStudent(id);
        }

        public void DeleteStudent(int id) {
            studentService.DeleteStudent(id);
        }
    }
}
