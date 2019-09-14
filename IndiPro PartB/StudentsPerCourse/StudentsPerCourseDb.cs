using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace IndiPro_PartB.StudentsPerCourse
{
    public class StudentsPerCourseDb
    {
        private const string connectionString = @"Data Source=LAPTOP-SVDRNMUO\SQLEXPRESS;Initial Catalog=IndividualPartB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public List<StudentPerCourse> GetStudentsPerCourse(int courseID)
        {
            CourseDb cDB = new CourseDb();
            List<Course> courses = cDB.GetCourses();
            List<StudentPerCourse> studentsPerCourse = new List<StudentPerCourse>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("select c.Title, s.FirstName, s.LastName from Courses as c join StudentsPerCourse as spc on c.CourseID = spc.CourseID join Students as s on spc.StudentID = s.StudentID where c.CourseID = @CourseID", conn))
                {
                    cmd.Parameters.Add(new SqlParameter("CourseID", courseID));
                    cmd.ExecuteNonQuery();
                    using(SqlDataReader rdr = cmd.ExecuteReader())
                    {                       
                        if (rdr != null)
                        {
                            Console.WriteLine($"    |{courses[courseID-1].Title}|");
                            while (rdr.Read())
                            {                            
                                studentsPerCourse.Add(new StudentPerCourse() {
                                    Id = studentsPerCourse.Count + 1,
                                    Title = (string)rdr["Title"],
                                    FirstName = (string)rdr["FirstName"],
                                    LastName = (string)rdr["LastName"]
                                });                                
                            }
                        }
                        else Console.WriteLine("There are no courses or students yet");
                    }
                }
            }
            return studentsPerCourse;            
        }

        public static void AddStudentToCourse(int StudentID, int CourseID)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using(SqlCommand cmd = new SqlCommand("Insert into StudentsPerCourse(StudentID, CourseID) values (@StudentID, @CourseID)", conn))
                {
                    cmd.Parameters.Add(new SqlParameter("StudentID", StudentID));
                    cmd.Parameters.Add(new SqlParameter("CourseID", CourseID));
                    cmd.ExecuteNonQuery();
                }
            }
        }       
    }
}

