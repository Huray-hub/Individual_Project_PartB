using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace IndiPro_PartB
{
    public class TrainerDb
    {
        private const string connectionString = @"Data Source=LAPTOP-SVDRNMUO\SQLEXPRESS;Initial Catalog=IndividualPartB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public List<Trainer> GetTrainers()
        {
            List<Trainer> TrainersList = new List<Trainer>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();                
                using(SqlCommand cmd = new SqlCommand("select * from Trainers", conn))
                {
                    using(SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            TrainersList.Add(new Trainer()
                            {
                                Id = (int)rdr["TrainerID"],
                                FirstName = (string)rdr["FirstName"],
                                LastName = (string)rdr["LastName"],
                                Subject = (string)rdr["Subject"]
                            });
                        }
                    }
                }
            }
            return TrainersList;
        }

        public static void AddTrainer(string FirstName, string LastName, string Subject)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("insert into Trainers(FirstName, LastName, [Subject]) values(@FirstName, @LastName, @Subject)", conn))
                {
                    cmd.Parameters.Add(new SqlParameter("FirstName", FirstName));
                    cmd.Parameters.Add(new SqlParameter("LastName", LastName));
                    cmd.Parameters.Add(new SqlParameter("Subject", Subject));
                    cmd.ExecuteNonQuery();
                }
            }
        }   
    }
}
