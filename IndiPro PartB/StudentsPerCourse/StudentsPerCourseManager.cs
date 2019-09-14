using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndiPro_PartB.StudentsPerCourse
{
    public class StudentsPerCourseManager
    {
        public static void AddStudentInCourse()
        {           
            Console.Clear();
            StudentDb sDB = new StudentDb();
            CourseDb cDB = new CourseDb();

            List<Course> courses = cDB.GetCourses();
            List<Student> students = sDB.GetStudents();

            if (courses.Count != 0 && students.Count !=0)
            {                                                  
                Console.WriteLine("Select a student to add by using its number on the list: \n");
                ShowLists.ShowList(students, "Students");

                bool result = Int32.TryParse(Console.ReadLine(), out int studentID);
                while (!result || (studentID < 1 || studentID > students.Count))
                {
                    Console.Write($"Wrong input! Please select using numbers from 1 to {students.Count} ");
                    result = Int32.TryParse(Console.ReadLine(), out studentID);
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
                StudentsPerCourseDb.AddStudentToCourse(studentID, courseID);
                Console.WriteLine("Student enrolled to course successfully!");
            }
            else Console.WriteLine("There aren no Students or Courses yet");          
        }
    }
}
