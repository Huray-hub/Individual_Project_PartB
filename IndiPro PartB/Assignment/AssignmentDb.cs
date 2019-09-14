using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace IndiPro_PartB
{
    public class AssignmentDb
    {
        private const string connectionString = @"Data Source=LAPTOP-SVDRNMUO\SQLEXPRESS;Initial Catalog=IndividualPartB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public List<Assignment> GetAssignments()
        {
            List<Assignment> assignments = new List<Assignment>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("select * from Assignments", conn))
                {
                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            assignments.Add(new Assignment()
                            {
                                Id = (int)rdr["AssignmentID"],
                                Title = (string)rdr["Title"],
                                SubDateTime = (DateTime)rdr["SubmissionDateTime"],
                                OralMark = (decimal)rdr["OralMark"],
                                TotalMark = (decimal)rdr["TotalMark"]
                            });
                        }
                    }
                }
            }
            return assignments;
        }

        public static void CreateAssignment(string Title, string Description, DateTime SubmissionDateTime, decimal OralMark, decimal TotalMark)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("insert into Assignments(Title, Description, SubmissionDateTime, OralMark, TotalMark) values(@Title, @Description, @SubmissionDateTime, @OralMark, @TotalMark)", conn))
                {
                    cmd.Parameters.Add(new SqlParameter("Title", Title));
                    cmd.Parameters.Add(new SqlParameter("Description", Description));
                    cmd.Parameters.Add(new SqlParameter("SubmissionDateTime", SubmissionDateTime));
                    cmd.Parameters.Add(new SqlParameter("OralMark", OralMark));
                    cmd.Parameters.Add(new SqlParameter("TotalMark", TotalMark));
                    cmd.ExecuteNonQuery();
                }
            }
        }        
    }
}
