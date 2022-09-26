using CodingBootcampB.RepositoryServices.StudentRepository;
using CodingBootcampB.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingBootcampB.Views.StudentView
{
    class InputStudent : IInput<Student, int>
    {
        public Student GetData()
        {
            string firstname = HumanService.GetFirstName();
            string lastname = HumanService.GetLastName();
            DateTime birthdate = HumanService.GetDateOfBirth();
            decimal fees = HumanService.GetTuitionFees();
            return new Student(firstname, lastname, birthdate, fees);
        }

        public int GetIDToDeleteOrUpdate(string action)
        {
            
            bool isInt;
            int id;
            string input;
            do
            {
                ApplicationPrint.EnterIDToDeleteOrUpdate("student", action);
                input = Console.ReadLine();
                isInt = int.TryParse(input, out id);
            } while (!isInt);

            return id;
        }

        public Student GetDataToUpdate()
        {

            int id = GetIDToDeleteOrUpdate("update");
            StudentRepository repo = new StudentRepository();
            Student student = repo.GetAll().FirstOrDefault(s => s.ID == id);
            if (student == null)
            {
                ApplicationPrint.NotFound404("Student", id);
            }
            else
            {
                student.FirstName = HumanService.GetFirstNameToUpdate(student);
                student.LastName = HumanService.GetLastNameToUpdate(student);
                student.DateOfBirth = GetBirthDateToUpdate(student);
                student.TuitionFees = GetTuitionFeesToUpdate(student);
            }
            return student;
        }

        public DateTime GetBirthDateToUpdate(Student student)
        {
            ApplicationPrint.EnterDataToUpdate("date of birth");
            string answer = Console.ReadLine();
            if (answer.ToUpper() == "Y")
            {
                student.DateOfBirth = HumanService.GetDateOfBirth();
                
            }
            return student.DateOfBirth;
        }

        public decimal GetTuitionFeesToUpdate(Student student)
        {
            ApplicationPrint.EnterDataToUpdate("tuition fees");
            string answer = Console.ReadLine();
            if (answer.ToUpper() == "Y")
            {
                student.TuitionFees = HumanService.GetTuitionFees();
            }
            return student.TuitionFees;
        }
    }
}
