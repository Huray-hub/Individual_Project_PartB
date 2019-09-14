using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace IndiPro_PartB.AssignmentPerCourseFolder
{
    public class AssignmentsPerCourseDb
    {
        private const string connectionString = @"Data Source=LAPTOP-SVDRNMUO\SQLEXPRESS;Initial Catalog=IndividualPartB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public List<AssignmentPerCourse> GetAssignmentsPerCourse(int courseID)
        {
            CourseDb cDB = new CourseDb();
            List<Course> courses = cDB.GetCourses();
            List<AssignmentPerCourse> assignmentsPerCourse = new List<AssignmentPerCourse>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("select a.Title from Courses as c join Assignments as a on c.CourseID = a.CourseID where c.CourseID = @CourseID", conn))
                {
                    cmd.Parameters.Add(new SqlParameter("CourseID", courseID));
                    cmd.ExecuteNonQuery();
                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        if (rdr != null)
                        {
                            Console.WriteLine($"    |{courses[courseID - 1].Title}|");
                            while (rdr.Read())
                            {
                                assignmentsPerCourse.Add(new AssignmentPerCourse()
                                {
                                    Id = assignmentsPerCourse.Count + 1,
                                    Title = (string)rdr["Title"],
                                    
                                });
                            }
                        }
                        else Console.WriteLine("There are no courses or assignments yet");
                    }
                }
            }
            return assignmentsPerCourse;
        }

        public static void AddAssignmentToCourse(int AssignmentID, int CourseID)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("Update Assignments set CourseID = @CourseID where AssignmentID = @AssignmentId", conn))
                {
                    cmd.Parameters.Add(new SqlParameter("AssignmentID", AssignmentID));
                    cmd.Parameters.Add(new SqlParameter("CourseID", CourseID));
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
