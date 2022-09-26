using CodingBootcampB.Enums;
using CodingBootcampB.RepositoryServices.StudentRepository;
using CodingBootcampB.RepositoryServices.TrainerRepository;
using CodingBootcampB.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingBootcampB.Services
{
    class HumanService
    {
        public static string GetFirstName()
        {
            ApplicationPrint.EnterData("firstname");
            string firstname = Console.ReadLine();
            firstname = char.ToUpper(firstname[0]) + firstname.Substring(1).ToLower();
            return firstname;
        }

        public static string GetLastName()
        {
            ApplicationPrint.EnterData("lastname");
            string lastname = Console.ReadLine();
            lastname = char.ToUpper(lastname[0]) + lastname.Substring(1).ToLower();
            return lastname;
        }


        public static DateTime GetDateOfBirth()
        {
            bool isDateTime;
            string input;
            DateTime birthDate;
            do
            {
                ApplicationPrint.EnterData("date of birth");
                input = Console.ReadLine();
                isDateTime = DateTime.TryParse(input, out birthDate);
            } while (!isDateTime);

            return birthDate;
        }

        
        public static decimal GetTuitionFees()
        {
            bool isDecimal = true;
            string input;
            decimal fees = 0;
            
            do
            {
                ApplicationPrint.EnterData("tuition fees (should be between 1000 and 3000)");
                input = Console.ReadLine();
                isDecimal = decimal.TryParse(input, out fees);

            } while (!isDecimal || fees < 1000 || fees > 3000);

            return fees;
        }

        
        public static string GetSubject()
        {
            string subject = "";
            bool isInt;
            int number;
            do
            {
                ApplicationPrint.GetStreamOrSubject("subject");
                string answer = Console.ReadLine();
                isInt = int.TryParse(answer, out number);
                switch (number)
                {
                    case 1: subject = StreamSubject.CS.ToString().Replace("S", "#"); break;
                    case 2: subject = StreamSubject.Java.ToString(); break;
                    case 3: subject = StreamSubject.Python.ToString(); break;
                    case 4: subject = StreamSubject.JavaScript.ToString(); break;
                    default: ApplicationPrint.InvalidChoice(); break;

                }
            } while (!isInt || number < 1 || number > 4);
           
            return subject;
        }


        public static string GetFirstNameToUpdate(IHuman human)
        {

            ApplicationPrint.EnterDataToUpdate("firstname");
            string answer = Console.ReadLine();
            if (answer.ToUpper() == "Y")
            {
                human.FirstName = GetFirstName();
            }
            return human.FirstName;
        }

        public static string GetLastNameToUpdate(IHuman human)
        {
            ApplicationPrint.EnterDataToUpdate("lastname");
            string answer = Console.ReadLine();
            if (answer.ToUpper() == "Y")
            {
                human.LastName = GetLastName();

            }
            return human.LastName;
        }

        public static int GetTrainerID()
        {
            bool isInt;
            int id;
            string input;
            do
            {
                ApplicationPrint.GetID("trainer");
                input = Console.ReadLine();
                isInt = int.TryParse(input, out id);
            } while (!isInt || id < 1 || !TrainerExists(id));

            return id;
        }

        public static bool TrainerExists(int id)
        {
            TrainerRepository repo = new TrainerRepository();
            Trainer trainer = repo.GetAll().FirstOrDefault(s => s.ID == id);
            if (trainer == null)
            {
                ApplicationPrint.NotFound404("Trainer", id);
                return false;
            }
            return true;
        }

        public static int GetStudentID()
        {
            bool isInt;
            int id;
            string input;
            do
            {
                ApplicationPrint.GetID("student");
                input = Console.ReadLine();
                isInt = int.TryParse(input, out id);
            } while (!isInt || id < 1 || !StudentExists(id));

            return id;
        }

        public static bool StudentExists(int id)
        {
            StudentRepository repo = new StudentRepository();
            Student student = repo.GetAll().FirstOrDefault(s => s.ID == id);
            if (student == null)
            {
                ApplicationPrint.NotFound404("Student", id);
                return false;
            }
            return true;
        }
    }

   
}
