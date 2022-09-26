using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingBootcampB.Views.CourseView
{
    class PrintCourse : IPrint<Course>
    {
        public void PrintHeader()
        {
            Console.BackgroundColor = ConsoleColor.Magenta;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine($"{"ID",-5}{"Title",-15}{"Stream",-15}{"Type",-15}{"Starting Date",-15}{"Ending Date",-15}");
            Console.ResetColor();
        }
        public void Print(Course course)
        {
            Console.WriteLine($"{course.ID,-5}{course.Title,-15}{course.Stream,-15}{course.Type,-15}" +
                $"{course.StartingDate.ToShortDateString(),-15}{course.EndingDate.ToShortDateString(),-15}");
        }

        public void PrintList(List<Course> courses)
        {
            PrintHeader();
            foreach (var course in courses)
            {
                Print(course);
            }
        }
    }
}
