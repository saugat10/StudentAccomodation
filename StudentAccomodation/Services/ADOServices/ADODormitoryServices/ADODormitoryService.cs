using Student_Accomodation.Models;
using Student_Accomodation.Services.Interfaces;
using System.Collections.Generic;

namespace Student_Accomodation.Services.ADOServices.ADODormitoryServices
{
    public class ADODormitoryService : IDormitoryService
    {
        private ADODormitory domService;

        public ADODormitoryService(ADODormitory service) {
            domService = service;
        }
        public IEnumerable<Dormitory> GetAllDormitory()
        {
            return domService.GetAllDormitory();
        }
    }
}
