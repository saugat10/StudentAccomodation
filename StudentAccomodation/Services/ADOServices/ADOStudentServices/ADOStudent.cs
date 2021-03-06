using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Student_Accomodation.Models;
using System;
using System.Collections.Generic;

namespace Student_Accomodation.Services.ADOServices.ADOStudentServices
{
    public class ADOStudent
    {
        string connectionString;
        private IConfiguration configuration;
        public ADOStudent(IConfiguration config)
        {
            configuration = config;
            connectionString = configuration.GetConnectionString("StudentAccomodation");
        }

        public List<Student> GetAllStudents(string type)
        {
            List<Student> returnList = new List<Student>();

            string query;
            if (type == "Student") {
                query = "select *  from Student";
            } else {
                query = "select *  from Student Where Has_Room = 0 order by Registration_Date";
            }

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Student student = new Student();
                        student.StudentNo = Convert.ToInt32(reader[0]);
                        student.SName = Convert.ToString(reader[1]);
                        student.SAddress = Convert.ToString(reader[2]);
                        student.HasRoom = Convert.ToBoolean(reader[3]);
                        student.RegistrationDate = Convert.ToDateTime(reader[4]);
                        returnList.Add(student);
                    }
                }
                return returnList;
            }
        }

        public Student GetTopStudent()
        {
            
            string query = "select top 1 *  from student where Has_Room = 0 order by Registration_Date";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                Student student = new Student();
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    SqlDataReader reader = command.ExecuteReader();
                    //Leasing leasing = new Leasing();
                    //leasing.Student_No = Convert.ToInt32(reader);
                    //leasing.Place_No = placeNO;
                    //returnList.Add(leasing);
                    while (reader.Read())
                    {
                        
                        student.StudentNo = Convert.ToInt32(reader[0]);
                        student.SName = Convert.ToString(reader[1]);
                        student.SAddress = Convert.ToString(reader[2]);
                        student.HasRoom = Convert.ToBoolean(reader[3]);
                        student.RegistrationDate = Convert.ToDateTime(reader[4]);
                        
                    }
                }
                return student;
            }
        }

        public Student GetStudent(int id)
        {

            string query = $"select  *  from student where Student_No = {id}";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                Student student = new Student();
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {

                        student.StudentNo = Convert.ToInt32(reader[0]);
                        student.SName = Convert.ToString(reader[1]);
                        student.SAddress = Convert.ToString(reader[2]);
                        student.HasRoom = Convert.ToBoolean(reader[3]);
                        student.RegistrationDate = Convert.ToDateTime(reader[4]);

                    }
                }
                return student;
            }
        }

        public void DeleteStudent(int id)
        {
            UpdateRoom(id);
            DeleteLeasing(id);
            string query = $"DELETE FROM Student WHERE Student_No = {id}";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    int numberOfRowsAffected = command.ExecuteNonQuery();
                }
            }
        }

        public void UpdateRoom(int id)
        {
            string query = "UPDATE r SET Occupied = 0 " +
                "FROM room r INNER join Leasing l on r.Place_No = l.Place_No " +
                $"where l.Student_No = {id}";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    int numberOfRowsAffected = command.ExecuteNonQuery();
                }
            }
        }

        public void DeleteLeasing(int id)
        {
            string query = $"DELETE FROM Leasing Where Student_No = {id}";

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
