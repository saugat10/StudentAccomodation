using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Student_Accomodation.Models;
using System;
using System.Collections.Generic;

namespace Student_Accomodation.Services.ADOServices.ADORoomServices
{
    public class ADORoom
    {
        string connectionString;
        private IConfiguration configuration;
        public ADORoom(IConfiguration config)
        {
            configuration = config;
            connectionString = configuration.GetConnectionString("StudentAccomodation");
        }

        public List<Room> GetAllRooms()
        {
            List<Room> returnList = new List<Room>();
            string query = "select *  from Room";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Room room = new Room();
                        room.PlaceNo = Convert.ToInt32(reader[0]);
                        room.RentPerSemester = Convert.ToInt32(reader[1]);
                        room.Occupied = Convert.ToBoolean(reader[2]);
                        room.RoomNo = Convert.ToInt32(reader[3]);
                        if (!(reader[4] is DBNull))
                        {
                            room.DoritoryNo = Convert.ToInt32(reader[4]);
                        }
                        else
                        {
                            room.DoritoryNo = -1;
                        }
                        if (!(reader[5] is DBNull))
                        {
                            room.AppartNo = Convert.ToInt32(reader[5]);
                        }
                        else
                        {
                            room.AppartNo = -1;
                        }
                        
                        returnList.Add(room);
                    }
                }
                return returnList;
            }
        }
    }
}
