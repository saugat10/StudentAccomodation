using Student_Accomodation.Models;
using Student_Accomodation.Services.Interfaces;
using System.Collections.Generic;

namespace Student_Accomodation.Services.ADOServices.ADOLeasingServices
{
    public class ADOLeasingService : ILeasingService
    {
        ADOLeasing leasingService;

        public ADOLeasingService(ADOLeasing service) {
            leasingService = service;
        }
        public IEnumerable<Leasing> GetAllLeasing()
        {
            return leasingService.GetAllLeasing();
        }
    }
}
