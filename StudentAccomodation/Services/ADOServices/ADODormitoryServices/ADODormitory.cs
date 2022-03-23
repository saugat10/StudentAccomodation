using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Student_Accomodation.Models;
using System;
using System.Collections.Generic;

namespace Student_Accomodation.Services.ADOServices.ADODormitoryServices
{
    public class ADODormitory
    {
        string connectionString;
        private IConfiguration configuration;
        public ADODormitory(IConfiguration config)
        {
            configuration = config;
            connectionString = configuration.GetConnectionString("StudentAccomodation");
        }

        public List<Dormitory> GetAllDormitory()
        {
            List<Dormitory> returnList = new List<Dormitory>();
            string query = "select *  from Dormitory";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Dormitory dormitory = new Dormitory();
                        dormitory.Dormitory_No = Convert.ToInt32(reader[0]);
                        dormitory.Name = Convert.ToString(reader[1]);
                        dormitory.Address = Convert.ToString(reader[2]);
                        returnList.Add(dormitory);
                    }
                }
                return returnList;
            }
        }
    }
}
