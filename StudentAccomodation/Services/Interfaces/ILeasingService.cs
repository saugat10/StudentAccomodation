using Student_Accomodation.Models;
using StudentAccomodation.ViewModels;
using System;
using System.Collections.Generic;

namespace Student_Accomodation.Services.Interfaces
{
    public interface ILeasingService
    {
        IEnumerable<Leasing> GetAllLeasing();

        public IEnumerable<StudentLeasings> GetStudentLeasings(int Id);
        void AddLeasing(int placeNO, int studentNO, DateTime dateFrom, DateTime dateTo);
    }
}
