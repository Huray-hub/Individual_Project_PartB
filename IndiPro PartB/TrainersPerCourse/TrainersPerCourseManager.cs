using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndiPro_PartB.TrainersPerCourseFolder
{
    public class TrainersPerCourseManager
    {
        public static void AddTrainerInCourse()
        {
            Console.Clear();
            TrainerDb tDB = new TrainerDb();
            CourseDb cDB = new CourseDb();

            List<Course> courses = cDB.GetCourses();
            List<Trainer> trainers = tDB.GetTrainers();

            if (courses.Count != 0 && trainers.Count != 0)
            {
                Console.WriteLine("Select a trainer to add by using its number on the list: \n");
                ShowLists.ShowList(trainers, "Trainers");

                bool result = Int32.TryParse(Console.ReadLine(), out int trainerID);
                while (!result || (trainerID < 1 || trainerID > trainers.Count))
                {
                    Console.Write($"Wrong input! Please select using numbers from 1 to {trainers.Count} ");
                    result = Int32.TryParse(Console.ReadLine(), out trainerID);
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
                TrainersPerCourseDb.AddTrainerToCourse(trainerID, courseID);
                Console.WriteLine("Trainer added to course successfully!");
            }
            else Console.WriteLine("There aren no Trainers or Courses yet");
        }
    }
}
