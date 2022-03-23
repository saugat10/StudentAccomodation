using Student_Accomodation.Models;
using System.Collections.Generic;

namespace Student_Accomodation.Services.Interfaces
{
    public interface ILeasingService
    {
        IEnumerable<Leasing> GetAllLeasing();
    }
}
