using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Student_Accomodation.Models;
using System;
using System.Collections.Generic;

namespace Student_Accomodation.Services.ADOServices.ADOLeasingServices
{
    public class ADOLeasing
    {
        string connectionString;
        private IConfiguration configuration;
        public ADOLeasing(IConfiguration config)
        {
            configuration = config;
            connectionString = configuration.GetConnectionString("StudentAccomodation");
        }

        public List<Leasing> GetAllLeasing()
        {
            List<Leasing> returnList = new List<Leasing>();
            string query = "select *  from Leasing";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Leasing leasing = new Leasing();
                        leasing.Leasing_No = Convert.ToInt32(reader[0]);
                        leasing.Student_No = Convert.ToInt32(reader[1]);
                        leasing.Place_No = Convert.ToInt32(reader[2]);
                        leasing.Date_From = Convert.ToDateTime(reader[3]);
                        leasing.Date_To = Convert.ToDateTime(reader[4]);
                        returnList.Add(leasing);
                    }
                }
                return returnList;
            }
        }

        public void AddLeasing(int placeNO, int studentNO, DateTime dateFrom, DateTime dateTo)
        {
            string query = $"Insert into Leasing(Student_No, Place_No, Date_From, Date_To) Values({studentNO},{placeNO}, {dateFrom}, {dateTo})";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    int numberOfRowsAffected = command.ExecuteNonQuery();
                }
            }
        }
    }
}
