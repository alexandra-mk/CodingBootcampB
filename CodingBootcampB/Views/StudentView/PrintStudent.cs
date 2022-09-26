using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingBootcampB.Views.StudentView
{
    class PrintStudent : IPrint<Student>
    {
        public void PrintHeader()
        {
            Console.BackgroundColor = ConsoleColor.Magenta;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine($"{"ID",-5}{"Firstname",-15}{"Lastname",-15}{"Date of birth",-15}{"Tuition Fees",-15}");
            Console.ResetColor();
        }
        public void Print(Student student)
        {
            Console.WriteLine($"{student.ID,-5}{student.FirstName,-15}{student.LastName,-15}{student.DateOfBirth.ToShortDateString(), -15}{student.TuitionFees,-15}");
        }

        public void PrintList(List<Student> students)
        {
            PrintHeader();
            foreach(var student in students)
            {
                Print(student);
            }
        }
    }
}
