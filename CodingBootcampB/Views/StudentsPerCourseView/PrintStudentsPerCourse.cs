using CodingBootcampB.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingBootcampB.Views.StudentsPerCourseView
{
    class PrintStudentsPerCourse : IPrint<StudentsPerCourse>
    {
        public void PrintHeader()
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine($"{"Courses",-18}{"Students"}");
            Console.BackgroundColor = ConsoleColor.Magenta;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine($"{"Title",-10}{"Firstname",-15}{"Lastname", -15}");
            Console.ResetColor();
        }

        public void Print(StudentsPerCourse spc)
        {
            Console.WriteLine($"{spc.Title,-10}{spc.FirstName,-15}{spc.LastName,-15}");
        }

        public void PrintList(List<StudentsPerCourse> students)
        {
            PrintHeader();
            foreach (var student in students)
            {
                Print(student);
            }
        }
    }
}
