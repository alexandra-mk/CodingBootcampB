using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingBootcampB.Views.AssignmentView
{
    class PrintAssignment : IPrint<Assignment>
    {
        public void PrintHeader()
        {
            Console.BackgroundColor = ConsoleColor.Magenta;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine($"{"ID",-5}{"Title",-20}{"Description",-20}{"Submission Date",-20}{"Oral Mark",-12}{"Total Mark",-12}{"CourseID",-12}");
            Console.ResetColor();
        }

        public void PrintHeaderPerCourse()
        {
            Console.BackgroundColor = ConsoleColor.Magenta;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine($"{"Assignment",-20}{"Course",-20}");
            Console.ResetColor();
        }

        public void PrintHeaderPerStudentPerCourse()
        {
            Console.BackgroundColor = ConsoleColor.Magenta;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine($"{"Assignment",-20}{"Course",-10}{"Student",-20}");
            Console.ResetColor();
        }
        public void Print(Assignment assignment)
        {
            Console.WriteLine($"{assignment.ID,-5}{assignment.Title,-20}{assignment.Description,-25}" +
                $"{assignment.SubmissionDate.ToShortDateString(),-18}{assignment.OralMark,-12}{assignment.TotalMark,-12}{assignment.CourseID,-9}");
        }

        public void PrintList(List<Assignment> assignments)
        {
            PrintHeader();
            foreach (var assignment in assignments)
            {
                Print(assignment);
            }
        }

        public void PrintAssignmentsPerCourse(List<Assignment> assignments)
        {
            PrintHeaderPerCourse();
            foreach (var assignment in assignments)
            {
                Console.WriteLine($"{assignment.Title,-20}{assignment.Course.Title, -20}");
            }
        }

        public void PrintAssignmentsPerStudentPerCourse(List<Assignment> assignments)
        {
            PrintHeaderPerStudentPerCourse();
            foreach (var assignment in assignments)
            {
                foreach(var student in assignment.Course.Students)
                {
                    Console.WriteLine($"{assignment.Title,-20}{assignment.Course.Title,-10}{student.FirstName} {student.LastName}");
                }
                
            }
        }
    }
}
