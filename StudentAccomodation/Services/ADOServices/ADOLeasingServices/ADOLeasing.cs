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

        public List<Leasing> GetWaitingStudent(int placeNO) {
            List<Leasing> returnList = new List<Leasing>();
            string query = "select top 1 Student_No  from student order by Registration_Date";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    SqlDataReader reader = command.ExecuteReader();
                    Leasing leasing = new Leasing();
                    leasing.Student_No = Convert.ToInt32(reader[0]);
                    leasing.Place_No = placeNO;
                    returnList.Add(leasing);
                    //while (reader.Read())
                    //{
                    //    Leasing leasing = new Leasing();
                    //    leasing.Leasing_No = Convert.ToInt32(reader[0]);
                    //    leasing.Student_No = Convert.ToInt32(reader[1]);
                    //    leasing.Place_No = Convert.ToInt32(reader[2]);
                    //    leasing.Date_From = Convert.ToDateTime(reader[3]);
                    //    leasing.Date_To = Convert.ToDateTime(reader[4]);
                    //    returnList.Add(leasing);
                    //}
                }
                return returnList;
            }
        }
    }
}
