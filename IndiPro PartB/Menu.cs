using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using IndiPro_PartB.Students;
using IndiPro_PartB.Trainers;
using IndiPro_PartB.Courses;
using IndiPro_PartB.Assignments;
using IndiPro_PartB.StudentsPerCourse;
using IndiPro_PartB.AssignmentPerCourseFolder;
using IndiPro_PartB.TrainersPerCourseFolder;
using IndiPro_PartB.AssignmentsPerStudent;

namespace IndiPro_PartB
{
    public class Menu
    {
        static StudentDb sDB = new StudentDb();
        static TrainerDb tDB = new TrainerDb();
        static CourseDb cDB = new CourseDb();
        static AssignmentDb aDB = new AssignmentDb();
        static StudentsPerCourseDb spcDB = new StudentsPerCourseDb();
        static AssignmentsPerCourseDb apcDB = new AssignmentsPerCourseDb();
        static AssignmentsPerStudentDb apsDB = new AssignmentsPerStudentDb();

        public  static void MainMenu()
        {          
            while (true)
            {
                Console.WriteLine("   | School Menu |\n  1. Students\n  2. Courses\n  3. Assignments\n  4. Trainers\n  0. Exit");                               
                bool result = Int32.TryParse(Console.ReadLine(), out int choice);
                while (!result || (choice < 0 && choice > 5))
                {
                    Console.Write("Wrong input! Please select from number 0 to 4\n");
                    result = Int32.TryParse(Console.ReadLine(), out choice);
                }
                Console.Clear();
                switch (choice)
                {
                    case 1:
                        StudentsMenu();
                        break;
                    case 2:
                        CoursesMenu();
                        break;
                    case 3:
                        AssignmentsMenu();
                        break;
                    case 4:
                        TrainersMenu();
                        break;
                    case 0:
                        Environment.Exit(0);
                        break;
                }
            }
        }

        public static void StudentsMenu()
        {
            Console.WriteLine("  1. All Students\n  2. All Students enrolled to more than one Courses\n  3. Add a Student to a Course\n  4. Add a new Student\n  5. Go back");
            bool result = Int32.TryParse(Console.ReadLine(), out int choice);
            while (!result || (choice < 1 && choice > 6))
            {
                Console.Write("Wrong input! Please select from number 1 to 6\n");
                result = Int32.TryParse(Console.ReadLine(), out choice);
            }
            Console.Clear();

            switch (choice)
            {
                case 1:
                    List<Student> students = sDB.GetStudents();                    
                    ShowLists.ShowList(students, "Students");
                    break;
                case 2:
                    List<Student> studentIn2Plus = sDB.ShowStudents2plus();
                    ShowLists.ShowList(studentIn2Plus, "Students enrolled in more than on Courses");
                    break;
                case 3:
                    StudentsPerCourseManager.AddStudentInCourse();
                    break;
                case 4:
                    StudentManager.AddStudent();
                    break;
            }
        }

        public static void CoursesMenu()
        {
            Console.WriteLine("  1. All Courses\n  2. Students per course\n  3. Assignments per Course\n  4. Trainers per Course\n  5. Create a new Course\n  6. Go back");
            bool result = Int32.TryParse(Console.ReadLine(), out int choice);
            while (!result || (choice < 1 && choice > 6))
            {
                Console.Write("Wrong input! Please select from number 1 to 6\n");
                result = Int32.TryParse(Console.ReadLine(), out choice);
            }
            Console.Clear();

            switch (choice)
            {
                case 1:
                    List<Course> courses = cDB.GetCourses();
                    ShowLists.ShowList(courses, "Courses");
                    break;
                case 2:
                    ShowLists.ShowStudentsInCourse();                    
                    break;
                case 3:
                    ShowLists.ShowAssignmentsInCourse();
                    break;
                case 4:
                    ShowLists.ShowTrainersInCourse();
                    break;
                case 5:
                    CourseManager.CreateCourse();
                    break;
               
            }
        }

        public static void AssignmentsMenu()
        {
            Console.WriteLine("  1. All Assignments\n  2. Assignments per Student\n  3. Current student's pending Assignments' submisions for a specific week\n  4. Add an Assignment to a Course\n  5. Add an Assignment to a Student\n  6. Create a new Assignment\n  7. Go back");
            bool result = Int32.TryParse(Console.ReadLine(), out int choice);
            while (!result || (choice < 1 && choice > 7))
            {
                Console.Write("Wrong input! Please select from number 1 to 7\n");
                result = Int32.TryParse(Console.ReadLine(), out choice);
            }
            Console.Clear();

            switch (choice)
            {
                case 1:
                    List<Assignment> assignments = aDB.GetAssignments();
                    ShowLists.ShowList(assignments, "Assignments");
                    break;
                case 2:
                    ShowLists.ShowAssignmentsPerStudent();
                    break;
                case 3:
                    ShowLists.ShowPendingAssignments();
                    break;
                case 4:
                    AssignmentsPerCourseManager.AddAssignmentInCourse();
                    break;
                case 5:
                    AssignmentsPerStudentManager.AddAssignmentToStudent();
                    break;
                case 6:
                    AssignmentManager.CreateAssignment();
                    break;                             
            }
        }

        public static void TrainersMenu()
        {
            Console.WriteLine("  1. All Trainers\n  2. Add a Trainer to a Course\n  3. Add a new Trainer\n  4. Go back");
            bool result = Int32.TryParse(Console.ReadLine(), out int choice);
            while (!result || (choice < 1 && choice > 4))
            {
                Console.Write("Wrong input! Please select from number 1 to 4\n");
                result = Int32.TryParse(Console.ReadLine(), out choice);
            }
            Console.Clear();

            switch (choice)
            {
                case 1:
                    List<Trainer> trainers = tDB.GetTrainers();
                    ShowLists.ShowList(trainers, "Trainers");
                    break;
                case 2:
                    TrainersPerCourseManager.AddTrainerInCourse();
                    break;                
                case 3:
                    TrainerManager.AddTrainer();
                    break;
            }
        }
    }
}
