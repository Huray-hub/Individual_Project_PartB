using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndiPro_PartB.AssignmentPerCourseFolder
{
    public class AssignmentsPerCourseManager
    {
        public static void AddAssignmentInCourse()
        {
            Console.Clear();
            AssignmentDb aDB = new AssignmentDb();
            CourseDb cDB = new CourseDb();

            List<Course> courses = cDB.GetCourses();
            List<Assignment> assignments = aDB.GetAssignments();

            if (courses.Count != 0 && assignments.Count != 0)
            {
                Console.WriteLine("Select an assignment to add by using its number on the list: \n");
                ShowLists.ShowList(assignments, "Students");

                bool result = Int32.TryParse(Console.ReadLine(), out int assignmentID);
                while (!result || (assignmentID < 1 || assignmentID > assignments.Count))
                {
                    Console.Write($"Wrong input! Please select using numbers from 1 to {assignments.Count} ");
                    result = Int32.TryParse(Console.ReadLine(), out assignmentID);
                }
                Console.Clear();

                Console.WriteLine("Select a course by using its number on the list: \n");
                ShowLists.ShowList(courses, "Courses");

                result = Int32.TryParse(Console.ReadLine(), out int courseID);
                while (!result || (courseID < 1 || courseID > courses.Count))
                {
                    Console.Write($"Wrong input! Please select using numbers from 1 to {courses.Count} ");
                    result = Int32.TryParse(Console.ReadLine(), out courseID);
                }
                Console.Clear();
                AssignmentsPerCourseDb.AddAssignmentToCourse(assignmentID, courseID);

                Console.WriteLine("Assignment added successfully to Course!");
            }
            else Console.WriteLine("There aren't neither Students nor Courses yet");
        }
    }
}
