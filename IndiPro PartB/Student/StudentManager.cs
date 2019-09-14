using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndiPro_PartB.Students
{
    public class StudentManager
    {
        public static void AddStudent()
        {
            Console.Clear();
            Console.Write("First name: ");
            string firstName = Console.ReadLine();
            Console.Write("Last name: ");
            string lastName = Console.ReadLine();
            Console.Write("Date of birth: ");
            bool result = DateTime.TryParse(Console.ReadLine(), out DateTime dateOfBirth);
            while (!result || dateOfBirth > DateTime.Now)
            {
                Console.Write("Wrong input!\nDate of birth has to be set as YYYY/MM/DD and can't be a future date \nDate of Birth: ");
                result = DateTime.TryParse(Console.ReadLine(), out dateOfBirth);
            }
            Console.Write("Tuition Fees: ");
            result = decimal.TryParse(Console.ReadLine(), out decimal tuitionFees);
            while (!result || tuitionFees < 0)
            {
                Console.Write("Wrong input!\n Tuition fees can't be a negative number \nTuition Fees: ");
                result = decimal.TryParse(Console.ReadLine(), out tuitionFees);
            }
            StudentDb.AddStudent(firstName, lastName, dateOfBirth, tuitionFees);
            Console.Clear();

            Console.WriteLine("Student added successfully!\n");
        }
    }
}
