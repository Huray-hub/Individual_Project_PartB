using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace IndiPro_PartB.TrainersPerCourseFolder
{
    public class TrainersPerCourseDb
    {
        private const string connectionString = @"Data Source=LAPTOP-SVDRNMUO\SQLEXPRESS;Initial Catalog=IndividualPartB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public List<Trainer> GetTrainersPerCourse(int courseID)
        {
            CourseDb cDB = new CourseDb();
            List<Course> courses = cDB.GetCourses();
            List<Trainer> trainersPerCourse = new List<Trainer>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("select t.FirstName, t.LastName, t.Subject from Courses as c join TrainersPerCourse as tpc on c.CourseID = tpc.CourseID join Trainers as t on tpc.TrainerID = t.TrainerID where c.CourseID = @CourseID", conn))
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
                                trainersPerCourse.Add(new Trainer()
                                {
                                    Id = trainersPerCourse.Count + 1,                                    
                                    FirstName = (string)rdr["FirstName"],
                                    LastName = (string)rdr["LastName"],
                                    Subject = (string)rdr["Subject"]
                                });
                            }
                        }
                        else Console.WriteLine("There are no courses or trainers yet");
                    }
                }
            }
            return trainersPerCourse;
        }

        public static void AddTrainerToCourse(int TrainerID, int CourseID)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("Insert into TrainersPerCourse(TrainerID, CourseID) values (@TrainerID, @CourseID)", conn))
                {
                    cmd.Parameters.Add(new SqlParameter("TrainerID", TrainerID));
                    cmd.Parameters.Add(new SqlParameter("CourseID", CourseID));
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
