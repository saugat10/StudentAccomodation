using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Student_Accomodation.Models;
using System;
using System.Collections.Generic;

namespace Student_Accomodation.Services.ADOServices.ADOApartmentServices
{
    public class ADOApartment
    {
        string connectionString;
        private IConfiguration configuration;
        public ADOApartment(IConfiguration config)
        {
            configuration = config;
            connectionString = configuration.GetConnectionString("StudentAccomodation");
        }

        public List<Apartment> GetAllApartments()
        {
            List<Apartment> returnList = new List<Apartment>();
            string query = "select *  from Appartment";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Apartment apartment = new Apartment();
                        apartment.Apartment_No = Convert.ToInt32(reader[0]);
                        apartment.Address = Convert.ToString(reader[1]);
                        apartment.Types = Convert.ToChar(reader[2]);
                        returnList.Add(apartment);
                    }
                }
                return returnList;
            }
        }

        public List<Room> GetVacentRooms(int id, string type)
        {
            List<Room> returnList = new List<Room>();
            string query;
            if(type == "Apartment")
            {
                query = $"select *  from Room where Appart_No = {id} AND occupied = 0 ";
            }
            else{
                query = $"select *  from Room where Dormitory_No = {id} AND occupied = 0 ";
            }
             

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Room vacantRoom = new Room();
                        vacantRoom.PlaceNo = Convert.ToInt32(reader[0]);
                        vacantRoom.RentPerSemester = Convert.ToInt32(reader[1]);
                        vacantRoom.Occupied = Convert.ToBoolean(reader[2]);
                        vacantRoom.RoomNo  = Convert.ToInt32(reader[3]);
                        returnList.Add(vacantRoom);
                    }
                }
                return returnList;
            }
        }
    }
}
