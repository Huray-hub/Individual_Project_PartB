using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndiPro_PartB.Trainers
{
    public class TrainerManager
    {
        public static void AddTrainer()
        {
            Console.Clear();
            Console.Write("First Name: ");
            string firstName = Console.ReadLine();
            Console.Write("Last Name: ");
            string lastName = Console.ReadLine();
            Console.Write("Subject: ");
            string subject = Console.ReadLine();

            TrainerDb.AddTrainer(firstName, lastName, subject);

            Console.Clear();
            Console.WriteLine("Trainer added sucessfully!\n");
        }
    }
}
