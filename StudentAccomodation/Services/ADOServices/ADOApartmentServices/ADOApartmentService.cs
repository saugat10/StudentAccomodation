using Student_Accomodation.Models;
using Student_Accomodation.Services.Interfaces;
using System.Collections.Generic;

namespace Student_Accomodation.Services.ADOServices.ADOApartmentServices
{
    public class ADOApartmentService : IApartmentService
    {
        private ADOApartment apartmentService;

        public ADOApartmentService(ADOApartment service) {
            apartmentService = service;
        }
        public IEnumerable<Apartment> GetAllApartments()
        {
            return  apartmentService.GetAllApartments();
        }

        public IEnumerable<Room> GetVacentRooms(int id)
        {
            return apartmentService.GetVacentRooms(id);
        }
    }
}
