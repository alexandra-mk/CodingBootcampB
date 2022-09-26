using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingBootcampB.Views
{
    class ApplicationPrint
    {

        public static void GetStreamOrSubject(string choice)
        {

            Console.WriteLine($"Enter number to choose {choice}:");
            Console.WriteLine("1.C# 2.Java 3.Python 4.JavaScript");
        }

        public static void GetCourseType()
        {
            Console.WriteLine("Enter number to choose type:");
            Console.WriteLine("1.Full Time 2.Part Time");
        }

        public static void InvalidChoice()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Invalid choice");
            Console.ResetColor();
        }

        public static void EnterDate(string timing)
        {
            Console.WriteLine($"Enter {timing} date:");
        }

        public static void EnterMark(string type, int max)
        {
            Console.WriteLine($"Enter {type} mark: (maximum is {max} points)");
        }

        public static void GetID(string entity)
        {
            Console.WriteLine($"Enter {entity}'s ID:");
        }

        public static void EnterDataToUpdate(string data)
        {
            Console.WriteLine($"Do you want to enter different {data}? (Y/N)");
        }

        public static void NotFound404(string entity, int id)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"{entity} with ID {id} doesn't exist.");
            Console.ResetColor();
        }

        public static void EnterData(string data)
        {
            Console.WriteLine($"Enter {data}:");
        }

        public static void EnterIDToDeleteOrUpdate(string entity, string action)
        {
            Console.WriteLine($"Enter the ID of the {entity} you want to {action}:");
        }

        public static void RegistrationNotFound404()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"The registration does not exist");
            Console.ResetColor();
        }

        public static void InvalidDate()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Invalid date, try again");
            Console.ResetColor();
        }

        public static void WeekendsAreForRest()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Date cannot be Saturday or Sunday. Enter date again.");
            Console.ResetColor();
        }

        public static void SuccessfullAction(string entity, string action, int n)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"{entity} {action} successfully.");
            Console.WriteLine($"{n} rows affected.");
            Console.ResetColor();
        }

        public static void GoodByeMessage()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("GOODBYE!");
            Console.ResetColor();
        }

        public static void EnterNumber()
        {
            Console.WriteLine("Enter a number to choose action:");
        }
    }
}
