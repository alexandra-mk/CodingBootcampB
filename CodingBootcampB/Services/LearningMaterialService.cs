using CodingBootcampB.Enums;
using CodingBootcampB.RepositoryServices.CourseRepository;
using CodingBootcampB.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingBootcampB.Services
{
    class LearningMaterialService
    {
        public static string GetTitle()
        {
            string title;
            do
            {
                ApplicationPrint.EnterData("title (has to be of 3 characters or longer)");
                title = Console.ReadLine();

            } while (title.Length < 3);


            title = char.ToUpper(title[0]) + title.Substring(1).ToLower();
            return title;
        }

        public static string GetDescription()
        {
            string description;
            do
            {
                ApplicationPrint.EnterData("description");
                description = Console.ReadLine();

            } while (description.Length < 4);

            description = char.ToUpper(description[0]) + description.Substring(1).ToLower();
            return description;
        }

        public static string GetStream()
        {
            string stream = "";
            bool isInt;
            int number;
            do
            {
                ApplicationPrint.GetStreamOrSubject("stream");
                string answer = Console.ReadLine();
                isInt = int.TryParse(answer, out number);
                switch (number)
                {
                    case 1: stream = StreamSubject.CS.ToString().Replace("S", "#"); break;
                    case 2: stream = StreamSubject.Java.ToString(); break;
                    case 3: stream = StreamSubject.Python.ToString(); break;
                    case 4: stream = StreamSubject.JavaScript.ToString(); break;
                    default: ApplicationPrint.InvalidChoice(); break;

                }
            } while (!isInt || number < 1 || number > 4);

            return stream;
        }

        public static string GetCourseType()
        {
            string type = "";
            bool isInt;
            int number;
            do
            {
                ApplicationPrint.GetCourseType();
                string answer = Console.ReadLine();
                isInt = int.TryParse(answer, out number);
                switch (number)
                {
                    case 1: type = CourseType.Full_Time.ToString().Replace("_", " "); break;
                    case 2: type = CourseType.Part_Time.ToString().Replace("_", " "); break;
                    default: ApplicationPrint.InvalidChoice(); break;
                        
                }
            } while (!isInt || number < 1 || number > 2);

           
            return type;
        }

        public static DateTime GetStartingDate()
        {
            bool isDateTime;
            string input;
            DateTime startDate;
            do
            {

                ApplicationPrint.EnterDate("starting");
                input = Console.ReadLine();
                isDateTime = DateTime.TryParse(input, out startDate);
            } while (!isDateTime || !DateValidation(startDate) || !IsDateThisYear(startDate));



            return startDate;
        }

        public static DateTime GetEndingDate(DateTime date)
        {
            bool isDateTime;
            string input;
            DateTime endDate;

            do
            {
                ApplicationPrint.EnterDate("ending");
                input = Console.ReadLine();
                isDateTime = DateTime.TryParse(input, out endDate);
            } while (!isDateTime || !DateValidation(endDate) || endDate < date);

            return endDate;
        }

        public static bool DateValidation(DateTime date)
        {
            if (date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday)
            {
                ApplicationPrint.WeekendsAreForRest();
                return false;
            }
            return true;
        }

        public static bool IsDateThisYear(DateTime date)
        {
            if (date > new DateTime(2023, 12, 31) || date < new DateTime(2022, 1, 1))
            {
                ApplicationPrint.InvalidDate();
                return false;
            }
            return true;
        }

        public static DateTime GetSubmissionDate()
        {
            bool isDateTime;
            string input;
            DateTime subDate;

            do
            {
                ApplicationPrint.EnterDate("submission");
                input = Console.ReadLine();
                isDateTime = DateTime.TryParse(input, out subDate);
            } while (!isDateTime || !DateValidation(subDate) || !IsDateThisYear(subDate));

            return subDate;
        }

        public static int GetTotalMark()
        {
            bool isInt;
            int mark;
            string input;
            do
            {
                ApplicationPrint.EnterMark("total", 100);
                input = Console.ReadLine();
                isInt = int.TryParse(input, out mark);
            } while (!isInt || mark < 20 || mark > 100);

            return mark;
        }
        public static int GetOralMark()
        {
            bool isInt;
            int mark;
            string input;
            do
            {
                ApplicationPrint.EnterMark("oral", 50);
                input = Console.ReadLine();
                isInt = int.TryParse(input, out mark);
            } while (!isInt || mark < 1 || mark > 50);

            return mark;
        }

        public static int GetCourseID()
        {
            bool isInt;
            int id;
            string input;
            do
            {
                ApplicationPrint.GetID("course");
                input = Console.ReadLine();
                isInt = int.TryParse(input, out id);
            } while (!isInt || id < 1 || !CourseExists(id));

            return id;
        }

        public static bool CourseExists(int id)
        {
            CourseRepository repo = new CourseRepository();
            Course course = repo.GetAll().FirstOrDefault(s => s.ID == id);
            if (course == null)
            {
                ApplicationPrint.NotFound404("Course", id);
                return false;
            }
            return true;
        }

        public static string GetTitleToUpdate(ILearningMaterial material)
        {

            ApplicationPrint.EnterDataToUpdate("title");
            string answer = Console.ReadLine();
            if (answer.ToUpper() == "Y")
            {
                material.Title = GetTitle();
            }
            return material.Title;
        }

    }
}
