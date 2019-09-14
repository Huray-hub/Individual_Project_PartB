using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace IndiPro_PartB
{
    public class CourseDb
    {
        private static readonly string connectionString = @"Data Source=LAPTOP-SVDRNMUO\SQLEXPRESS;Initial Catalog=IndividualPartB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public List<Course> GetCourses()
        {
            List<Course> courses = new List<Course>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("select * from Courses", conn))
                {
                    conn.Open();
                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            courses.Add(new Course()
                            {
                                Id = (int)rdr["CourseID"],
                                Title = (string)rdr["Title"],
                                Stream = (Stream)(int)rdr["StreamID"],
                                Type = (Type)(int)rdr["TypeID"],
                                StartDate = (DateTime)rdr["StartingDate"],
                                EndDate = (DateTime)rdr["EndingDate"]
                            });
                        }
                    }
                }
            }
            return courses;
        }

        public static void CreateCourse(string Title, Stream StreamID, Type TypeID, DateTime StartingDate, DateTime EndingDate)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("Insert into Courses(Title, StreamID, TypeID, StartingDate, EndingDate) values (@Title, @StreamID, @TypeID, @StartingDate, @EndingDate)", conn))
                {
                    cmd.Parameters.Add(new SqlParameter("Title", Title));
                    cmd.Parameters.Add(new SqlParameter("StreamID", StreamID));
                    cmd.Parameters.Add(new SqlParameter("TypeID", TypeID));
                    cmd.Parameters.Add(new SqlParameter("StartingDate", StartingDate));
                    cmd.Parameters.Add(new SqlParameter("EndingDate", EndingDate));
                    cmd.ExecuteNonQuery();
                }
            }
        }       
    }
}


