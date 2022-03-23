using Student_Accomodation.Models;
using System.Collections.Generic;

namespace Student_Accomodation.Services.Interfaces
{
    public interface IStudentService
    {
        IEnumerable<Student> GetAllStudents(string type);
        
    }
}
