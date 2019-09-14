using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndiPro_PartB.Courses
{
    public class CourseManager
    {
        public static void CreateCourse()
        {
            Console.Clear();
            Console.Write("Title: ");
            string title = Console.ReadLine();
            Console.Write("Stream: 1) Java 2) C#: ");
            bool result = Int32.TryParse(Console.ReadLine(), out int x);
            while (!result || (x != 1 && x != 2))
            {
                Console.Write("Wrong input! Please select using number 1 or 2\nStream: 1) Java 2) C#: ");
                result = Int32.TryParse(Console.ReadLine(), out x);
            }
            Stream streamID = (Stream)x;
            Console.Write("Type: 1) Part Time 2) Full Time: ");
            result = Int32.TryParse(Console.ReadLine(), out x);
            while (!result || (x != 1 && x != 2))
            {
                Console.Write("Wrong input! Please select using number 1 or 2\nType: 1) Part Time 2) Full Time: ");
                result = Int32.TryParse(Console.ReadLine(), out x);
            }
            Type typeID = (Type)x;
            Console.Write("Starting Date: ");
            result = DateTime.TryParse(Console.ReadLine(), out DateTime startDate);
            while (!result || startDate < DateTime.Now)
            {
                Console.Write("Wrong input!\nStarting date has to be set as YYYY/MM/DD and cant be a past date\nStarting Date: ");
                result = DateTime.TryParse(Console.ReadLine(), out startDate);
            }
            Console.Write("Ending Date: ");
            result = DateTime.TryParse(Console.ReadLine(), out DateTime endDate);
            while (!result || endDate < startDate)
            {
                Console.Write("Wrong input!\nEnding date has to be set as YYYY/MM/DD and cant be earlier date than Starting date\nEnding Date: ");
                result = DateTime.TryParse(Console.ReadLine(), out endDate);
            }
            CourseDb.CreateCourse(title, streamID, typeID, startDate, endDate);

            Console.WriteLine("Course creation successful!\n");
            Console.Clear();
        }
    }
}
