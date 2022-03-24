using Student_Accomodation.Models;
using System;
using System.Collections.Generic;

namespace Student_Accomodation.Services.Interfaces
{
    public interface ILeasingService
    {
        IEnumerable<Leasing> GetAllLeasing();
      

        void AddLeasing(int placeNO, int studentNO, DateTime dateFrom, DateTime dateTo);
    }
}
