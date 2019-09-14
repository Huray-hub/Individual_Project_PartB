using IndiPro_PartB.StudentsPerCourse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndiPro_PartB.AssignmentsPerStudent
{
    public class AssignmentsPerStudentManager
    {
        public static void AddAssignmentToStudent()
        {
            Console.Clear();
            AssignmentDb aDB = new AssignmentDb();
            StudentDb sDB = new StudentDb();            

            List<Assignment> assignments = aDB.GetAssignments();
            List<Student> students = sDB.GetStudents();

            if (assignments.Count != 0 && students.Count != 0)
            {
                Console.WriteLine("Select an assignment by using its number on the list: \n");
                ShowLists.ShowList(assignments, "Assignments");

                bool result = Int32.TryParse(Console.ReadLine(), out int assignmentID);
                while (!result || (assignmentID < 1 || assignmentID > assignments.Count))
                {
                    Console.Write($"Wrong input! Please select using numbers from 1 to {assignments.Count} ");
                    result = Int32.TryParse(Console.ReadLine(), out assignmentID);
                }

                Console.WriteLine("Select a student to add by using its number on the list: \n");
                ShowLists.ShowList(students, "Students");

                result = Int32.TryParse(Console.ReadLine(), out int studentID);
                while (!result || (studentID < 1 || studentID > students.Count))
                {
                    Console.Write($"Wrong input! Please select using numbers from 1 to {students.Count} ");
                    result = Int32.TryParse(Console.ReadLine(), out studentID);
                }
                Console.Clear();
                AssignmentsPerStudentDb.AddΑssignmentToStudent(assignmentID, studentID);
                Console.WriteLine("Assignment added to Student successfully!");
            }
            else Console.WriteLine("There aren no Students or Assignments yet");
        }
    }
}
