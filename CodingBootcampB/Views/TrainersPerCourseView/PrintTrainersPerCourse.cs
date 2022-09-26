using CodingBootcampB.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingBootcampB.Views.TrainersPerCourseView
{
    class PrintTrainersPerCourse : IPrint<TrainersPerCourse>
    {
        public void PrintHeader()
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine($"{"Courses",-18}{"Trainers"}");
            Console.BackgroundColor = ConsoleColor.Magenta;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine($"{"Title",-10}{"Firstname",-15}{"Lastname",-15}");
            Console.ResetColor();
        }

        public void Print(TrainersPerCourse spc)
        {
            Console.WriteLine($"{spc.Title,-10}{spc.FirstName,-15}{spc.LastName,-15}");
        }

        public void PrintList(List<TrainersPerCourse> trainers)
        {
            PrintHeader();
            foreach (var trainer in trainers)
            {
                Print(trainer);
            }
        }
    }
}
