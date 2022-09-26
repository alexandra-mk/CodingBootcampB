using CodingBootcampB.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodingBootcampB.Enums;
using CodingBootcampB.Services;

namespace CodingBootcampB
{
    class SchoolApplication
    {
       
        public static void Start()
        {
            StudentService studentService = new StudentService();
            TrainerService trainerService = new TrainerService();
            CourseService courseService = new CourseService();
            AssignmentService assignmentService = new AssignmentService();
            StudentsPerCourseService studentsPerCourseService = new StudentsPerCourseService();
            TrainersPerCourseService trainersPerCourseService = new TrainersPerCourseService();
            int input;
            do
            {
                ViewMenu.PrintMenu();
                input = GetNumberToChoose(); 
                Choice choice = (Choice)input;
                Console.Clear();
                switch (choice)
                {
                    case Choice.ReadStudent: studentService.ReadingService(); break;
                    case Choice.ReadTrainer: trainerService.ReadingService(); break;
                    case Choice.ReadCourse: courseService.ReadingService(); break;
                    case Choice.ReadAssignment: assignmentService.ReadingService(); break;
                    case Choice.ReadStudentPerCourse: studentsPerCourseService.ReadingService(); break;
                    case Choice.ReadTrainerPerCourse: trainersPerCourseService.ReadingService(); break;
                    case Choice.ReadStudentMoreThanOneCourse: studentService.ReadingMoreCoursesService(); break;
                    case Choice.ReadAssignmentPerCourse: assignmentService.ReadingAssignmentsPerCourseService(); break;
                    case Choice.ReadAssignmentPerStudentPerCourse: assignmentService.ReadingAssignmentsPerStudentsPerCourseService(); break;
                    case Choice.AddStudent: studentService.CreatingService(); break;
                    case Choice.AddTrainer: trainerService.CreatingService(); break;
                    case Choice.AddCourse: courseService.CreatingService(); break;
                    case Choice.AddAssignment: assignmentService.CreatingService(); break;
                    case Choice.AddStudentsToCourses: studentsPerCourseService.CreatingService(); break;
                    case Choice.AddTrainersToCourses: trainersPerCourseService.CreatingService(); break;
                    case Choice.UpdateStudent: studentService.UpdatingService(); break;
                    case Choice.UpdateTrainer: trainerService.UpdatingService(); break;
                    case Choice.UpdateCourse: courseService.UpdatingService(); break;
                    case Choice.UpdateAssignment: assignmentService.UpdatingService(); break;
                    case Choice.UpdateStudentsPerCourse: studentsPerCourseService.UpdatingService(); break;
                    case Choice.UpdateTrainersPerCourse: trainersPerCourseService.UpdatingService(); break;
                    case Choice.DeleteStudent: studentService.DeletingService(); break;
                    case Choice.DeleteTrainer: trainerService.DeletingService(); break;
                    case Choice.DeleteCourse: courseService.DeletingService(); break;
                    case Choice.DeleteAssignment: assignmentService.DeletingService(); break;
                    case Choice.DeleteStudentsPerCourse: studentsPerCourseService.DeletingService(); break;
                    case Choice.DeleteTrainersPerCourse: trainersPerCourseService.DeletingService(); break;
                    case Choice.Exit: ApplicationPrint.GoodByeMessage(); break;
                    default: ApplicationPrint.InvalidChoice(); break;
                }
                
            } while (input != 0);
            
        }

        public static int GetNumberToChoose()
        {
            bool isInt;
            string input;
            int a;
            do
            {
                ApplicationPrint.EnterNumber();
                input = Console.ReadLine();
                isInt = int.TryParse(input, out a);
            } while (!isInt);
            return a;
        }
    }
}
