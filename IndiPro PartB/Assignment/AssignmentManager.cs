using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndiPro_PartB.Assignments
{
    public class AssignmentManager
    {
        public static void CreateAssignment()
        {
            Console.Clear();
            Console.Write("Title: ");
            string title = Console.ReadLine();
            Console.Write("Description: ");
            string description = Console.ReadLine();
            Console.Write("Submission Date: ");
            bool result = DateTime.TryParse(Console.ReadLine(), out DateTime subDateTime);
            while (!result || subDateTime < DateTime.Now || subDateTime.DayOfWeek == DayOfWeek.Saturday || subDateTime.DayOfWeek == DayOfWeek.Sunday)
            {
                Console.Write("Wrong input!\nSubmission Date has to be set as YYYY/MM/DD, can't be in the past and has to be set between Monday and Friday \nSubmission Date: ");
                result = DateTime.TryParse(Console.ReadLine(), out subDateTime);
            }
            Console.WriteLine("Oral Mark: ");
            result = decimal.TryParse(Console.ReadLine(), out decimal oralMark);
            while (!result || oralMark < 0 || oralMark > 101)
            {
                Console.Write("Wrong input!\nOral Mark must be from 1 to 100: \nOral Mark:");
                result = decimal.TryParse(Console.ReadLine(), out oralMark);
            }
            Console.WriteLine("Total Mark: ");
            result = decimal.TryParse(Console.ReadLine(), out decimal totalMark);
            while (!result || totalMark < 0 || totalMark > 101)
            {
                Console.Write("Wrong input!\nTotal Mark must be from 1 to 100: \nTotal Mark:");
                result = decimal.TryParse(Console.ReadLine(), out totalMark);
            }

            AssignmentDb.CreateAssignment(title, description, subDateTime, oralMark, totalMark);

            Console.Clear();
            Console.WriteLine("Assignment creation successful!");
        }
    }
}
