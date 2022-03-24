﻿using Student_Accomodation.Models;
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
    }
}
