using IndiPro_PartB.StudentsPerCourse;
using IndiPro_PartB.AssignmentPerCourseFolder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IndiPro_PartB.TrainersPerCourseFolder;
using IndiPro_PartB.AssignmentsPerStudent;
using IndiPro_PartB.AssignmentsPerStudentFolder;

namespace IndiPro_PartB
{
    public class ShowLists
    {
        public static void ShowList<T>(List<T> list, string description)
        {
            Console.WriteLine($"   | {description} |");
            if (list.Count != 0) { foreach (var item in list) Console.WriteLine($" {item}"); }

            else Console.WriteLine($"There are no {description.ToLower()} yet\n");
        }

        public static void ShowStudentsInCourse()
        {
            Console.Clear();
            CourseDb cDb = new CourseDb();
            StudentsPerCourseDb spcDb = new StudentsPerCourseDb();
            List<Course> courses = cDb.GetCourses();

            if (courses.Count != 0)
            {
                Console.WriteLine("Please select a course by using its number on the list: \n");
                ShowList<Course>(courses, "Courses");

                bool result = Int32.TryParse(Console.ReadLine(), out int courseID);
                while (!result || (courseID < 1 || courseID > courses.Count))
                {
                    Console.Write($"Wrong input! Please select using numbers from 1 to {courses.Count} ");
                    result = Int32.TryParse(Console.ReadLine(), out courseID);
                }
                Console.Clear();

                List<StudentPerCourse> studentsPerCourse = spcDb.GetStudentsPerCourse(courseID);
                ShowList(studentsPerCourse, $"Students Per This Course");
            }
            else Console.WriteLine("There are no students or courses yet");
        }

        public static void ShowAssignmentsInCourse()
        {
            Console.Clear();
            CourseDb cDb = new CourseDb();
            AssignmentsPerCourseDb apcDb = new AssignmentsPerCourseDb();
            List<Course> courses = cDb.GetCourses();

            if (courses.Count != 0)
            {
                Console.WriteLine("Please select a course by using its number on the list: \n");
                ShowList(courses, "Courses");

                bool result = Int32.TryParse(Console.ReadLine(), out int courseID);
                while (!result || (courseID < 1 || courseID > courses.Count))
                {
                    Console.Write($"Wrong input! Please select using numbers from 1 to {courses.Count} ");
                    result = Int32.TryParse(Console.ReadLine(), out courseID);
                }
                Console.Clear();

                List<AssignmentPerCourse> studentsPerCourse = apcDb.GetAssignmentsPerCourse(courseID);
                ShowList(studentsPerCourse, $"Assignments Per This Course");
            }
            else Console.WriteLine("There are no students or courses yet");
        }

        public static void ShowTrainersInCourse()
        {
            Console.Clear();
            CourseDb cDb = new CourseDb();
            TrainersPerCourseDb tpcDb = new TrainersPerCourseDb();
            List<Course> courses = cDb.GetCourses();

            if (courses.Count != 0)
            {
                Console.WriteLine("Please select a course by using its number on the list: \n");
                ShowList(courses, "Courses");

                bool result = Int32.TryParse(Console.ReadLine(), out int courseID);
                while (!result || (courseID < 1 || courseID > courses.Count))
                {
                    Console.Write($"Wrong input! Please select using numbers from 1 to {courses.Count} ");
                    result = Int32.TryParse(Console.ReadLine(), out courseID);
                }
                Console.Clear();

                List<Trainer> trainersPerCourse = tpcDb.GetTrainersPerCourse(courseID);
                ShowList(trainersPerCourse, $"Trainers Per This Course");
            }
            else Console.WriteLine("There are no trainers or courses yet");
        }

        public static void ShowAssignmentsPerStudent()
        {
            Console.Clear();
            StudentDb sDB = new StudentDb();
            AssignmentsPerStudentDb apsDB = new AssignmentsPerStudentDb();
            List<Student> students = sDB.GetStudents();

            Console.Clear();
            if (students.Count != 0)
            {
                Console.WriteLine($"Please select a Student to see his Assignments: \n");
                ShowList(students, "Students");

                bool result = Int32.TryParse(Console.ReadLine(), out int studentID);
                while (!result || studentID < 1 || studentID > students.Count)
                {
                    Console.Write($"Wrong input! Please select using numbers from 1 to {students.Count}\n");
                    result = Int32.TryParse(Console.ReadLine(), out studentID);
                }
                Console.Clear();
                List<AssignmentPerStudent> assignmentsPerStudent = apsDB.GetAssignmentPerStudent(studentID);
                ShowList(assignmentsPerStudent, "Assignments");
            }
            else Console.WriteLine($"There are not Students or Assignments yet");
        }

        public static void ShowPendingAssignments()
        {
            AssignmentsPerStudentDb apsDB = new AssignmentsPerStudentDb();
            Console.Write("Date: ");
            bool result = DateTime.TryParse(Console.ReadLine(), out DateTime pendingDate);
            while (!result || pendingDate < DateTime.Now)
            {
                Console.Write("Wrong input!\nSubmission Date has to be set as YYYY/MM/DD and can't be in the past\nDate : ");
                result = DateTime.TryParse(Console.ReadLine(), out pendingDate);
            }
            DateTime monday = pendingDate.AddDays(-(int)pendingDate.DayOfWeek + (int)DayOfWeek.Monday + 1);
            DateTime friday = pendingDate.AddDays(-(int)pendingDate.DayOfWeek + (int)DayOfWeek.Friday + 1);
            DateTime sunday = pendingDate.AddDays(-(int)pendingDate.DayOfWeek + 7 + 1);

            List<PendingAssignmentsPerStudent> pending = apsDB.GetAssignmentPerStudent();

            ShowList(pending, $" Students and their pending Assignments' submissions for Monday {monday.ToShortDateString()} to Friday {friday.ToShortDateString()}:");

            for (int i = 0; i < pending.Count; i++)
            {
                if (pending[i].SubmissionDateTime.CompareTo(monday) >= 0 && pending[i].SubmissionDateTime.CompareTo(sunday) <= 0)
                {
                    Console.WriteLine($"{i + 1} {pending[i].FirstName} {pending[i].LastName}: {pending[i].Title} ");
                }
            }
        }
    }
}
