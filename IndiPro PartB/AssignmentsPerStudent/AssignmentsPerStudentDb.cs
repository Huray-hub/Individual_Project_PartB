using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using IndiPro_PartB.AssignmentsPerStudentFolder;

namespace IndiPro_PartB.AssignmentsPerStudent
{
    public class AssignmentsPerStudentDb
    {
        private const string connectionString = @"Data Source=LAPTOP-SVDRNMUO\SQLEXPRESS;Initial Catalog=IndividualPartB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        public List<AssignmentPerStudent> GetAssignmentPerStudent(int studentID)
        {
            StudentDb sDB = new StudentDb();
            List<Student> students = sDB.GetStudents();
            List<AssignmentPerStudent> assignmentsPerStudent = new List<AssignmentPerStudent>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("select a.Title, a.SubmissionDateTime, aps.PersonalOralMark as OralMark, aps.PersonalTotalMark as TotalMark from Courses as c join Assignments as a on c.CourseID = a.CourseID join StudentsPerCourse as spc on spc.CourseID = c.CourseID join Students as s on s.StudentID = spc.StudentID join AssignmentsPerStudent as aps on s.StudentID = aps.StudentID where s.StudentID = @StudentID", conn))
                {
                    cmd.Parameters.Add(new SqlParameter("StudentID", studentID));
                    cmd.ExecuteNonQuery();
                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        if (rdr != null)
                        {
                            Console.WriteLine($"    |{students[studentID - 1].LastName} {students[studentID - 1].FirstName}|");
                            while (rdr.Read())
                            {                              
                                assignmentsPerStudent.Add(new AssignmentPerStudent()
                                {
                                    Id = assignmentsPerStudent.Count + 1,
                                    Title = (string)rdr["Title"],
                                    SubmissionDateTime = (DateTime)rdr["SubmissionDateTime"],
                                    OralMark = (decimal)rdr["OralMark"],
                                    TotalMark = (decimal)rdr["TotalMark"]
                                });
                            }
                        }
                        else Console.WriteLine("There are no assignments or students yet");
                    }
                }
            }
            return assignmentsPerStudent;
        }

        public static void AddΑssignmentToStudent(int AssignmentID, int StudentID)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("Insert into AssignmentsPerStudent(AssignmentID, StudentID) values (@AssignmentID, @StudentID)", conn))
                {
                    cmd.Parameters.Add(new SqlParameter("AssignmentID", AssignmentID));
                    cmd.Parameters.Add(new SqlParameter("StudentID", StudentID));
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<PendingAssignmentsPerStudent> GetAssignmentPerStudent()
        {                       
            List<PendingAssignmentsPerStudent> pendingAssignmentsPerStudent = new List<PendingAssignmentsPerStudent>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("select distinct a.Title, a.SubmissionDateTime, s.LastName, s.FirstName from Courses as c join Assignments as a on c.CourseID = a.CourseID join StudentsPerCourse as spc on spc.CourseID = c.CourseID join Students as s on s.StudentID = spc.StudentID join AssignmentsPerStudent as aps on s.StudentID = aps.StudentID ", conn))
                {                    
                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        if (rdr != null)
                        {                            
                            while (rdr.Read())
                            {
                                pendingAssignmentsPerStudent.Add(new PendingAssignmentsPerStudent()
                                {
                                    Id = pendingAssignmentsPerStudent.Count + 1,
                                    LastName = (string)rdr["LastName"],
                                    FirstName =(string)rdr["FirstName"],
                                    Title = (string)rdr["Title"],
                                    SubmissionDateTime = (DateTime)rdr["SubmissionDateTime"]                                   
                                });
                            }
                        }
                        else Console.WriteLine("There are no assignments or students yet");
                    }
                }
            }
            return pendingAssignmentsPerStudent;
        }       
    }
}
