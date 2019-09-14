using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace IndiPro_PartB
{
    public class StudentDb
    {
        private static readonly string connectionString = @"Data Source=LAPTOP-SVDRNMUO\SQLEXPRESS;Initial Catalog=IndividualPartB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public List<Student> GetStudents()
        {
            List<Student> students = new List<Student>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {         
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("select * from Students", conn))
                {
                    using(SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        if (rdr != null)
                        {
                            while (rdr.Read())
                            {
                                students.Add(new Student()
                                {
                                    Id = (int)rdr["StudentID"],
                                    FirstName = (string)rdr["FirstName"],
                                    LastName = (string)rdr["LastName"],
                                    DateOfBirth = (DateTime)rdr["DateOfBirth"],
                                    TuitionFees = (decimal)rdr["TuitionFees"],
                                });
                            }
                        }
                        else Console.WriteLine("The are no courses yet");
                    }
                }
            }
            return students;
        }

        public static void AddStudent(string FirstName, string LastName, DateTime DateOfBirth, decimal TuitionFees)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("Insert into Students(FirstName, LastName, DateOfBirth, TuitionFees) values(@FirstName, @LastName, @DateOfBirth, @TuitionFees)", conn))
                {
                    cmd.Parameters.Add(new SqlParameter("FirstName", FirstName));                   
                    cmd.Parameters.Add(new SqlParameter("LastName", LastName));                  
                    cmd.Parameters.Add(new SqlParameter("DateOfBirth", DateOfBirth));                  
                    cmd.Parameters.Add(new SqlParameter("TuitionFees", TuitionFees));                  
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<Student> ShowStudents2plus()
        {            
            List<Student> studentsMoreThan2 = new List<Student>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("select * from Students where StudentID in (select studentID from StudentsPerCourse group by StudentID having count(StudentID) > 1)", conn))
                {
                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            studentsMoreThan2.Add(new Student()
                            {
                                Id = studentsMoreThan2.Count + 1,
                                LastName = (string)rdr["LastName"],
                                FirstName = (string)rdr["FirstName"],
                                DateOfBirth = (DateTime)rdr["DateOfBirth"],
                                TuitionFees = (decimal)rdr["TuitionFees"]
                            });
                        }
                    }
                }
            }
            return studentsMoreThan2;
        }
    }
}
