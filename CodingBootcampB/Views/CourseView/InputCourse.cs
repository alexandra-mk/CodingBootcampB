using CodingBootcampB.RepositoryServices.CourseRepository;
using CodingBootcampB.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingBootcampB.Views.CourseView
{
    class InputCourse : IInput<Course, int>
    {
        public Course GetData()
        {
            string title = LearningMaterialService.GetTitle();
            string stream = LearningMaterialService.GetStream();
            string type = LearningMaterialService.GetCourseType();
            DateTime startDate = LearningMaterialService.GetStartingDate();
            DateTime endDate = LearningMaterialService.GetEndingDate(startDate);
            return new Course(title, stream, type, startDate, endDate);
            
        }

        public int GetIDToDeleteOrUpdate(string action)
        {

            bool isInt;
            int id;
            string input;
            do
            {
                ApplicationPrint.EnterIDToDeleteOrUpdate("Course", action);
                input = Console.ReadLine();
                isInt = int.TryParse(input, out id);
            } while (!isInt);

            return id;
        }

        public Course GetDataToUpdate()
        {
            int id = GetIDToDeleteOrUpdate("update");
            CourseRepository repo = new CourseRepository();
            Course course = repo.GetAll().FirstOrDefault(s => s.ID == id);
            if (course == null)
            {
                ApplicationPrint.NotFound404("course", id);
            }
            else
            {
                course.Title = LearningMaterialService.GetTitleToUpdate(course);
                course.Stream = GetStreamToUpdate(course);
                course.Type = GetTypeToUpdate(course);
                course.StartingDate = GetStartingDateToUpdate(course);
                course.EndingDate = GetEndingDateToUpdate(course);
            }
            return course;
        }

        public string GetStreamToUpdate(Course course)
        {
            ApplicationPrint.EnterDataToUpdate("stream");
            string answer = Console.ReadLine();
            if (answer.ToUpper() == "Y")
            {
                course.Stream = LearningMaterialService.GetStream();
            }
            return course.Stream;
        }

        public string GetTypeToUpdate(Course course)
        {
            ApplicationPrint.EnterDataToUpdate("type");
            string answer = Console.ReadLine();
            if (answer.ToUpper() == "Y")
            {
                course.Type = LearningMaterialService.GetCourseType();
            }
            return course.Type;
        }

        public DateTime GetStartingDateToUpdate(Course course)
        {
            ApplicationPrint.EnterDataToUpdate("starting date");
            string answer = Console.ReadLine();
            if (answer.ToUpper() == "Y")
            {
                course.StartingDate = LearningMaterialService.GetStartingDate();
            }
            return course.StartingDate;
        }

        public DateTime GetEndingDateToUpdate(Course course)
        {
            ApplicationPrint.EnterDataToUpdate("ending date");
            string answer = Console.ReadLine();
            if (answer.ToUpper() == "Y")
            {
                course.EndingDate = LearningMaterialService.GetEndingDate(course.StartingDate);
            }
            return course.EndingDate;
        }
    }
}
