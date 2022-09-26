using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingBootcampB
{
    public class Student : IHuman
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public decimal TuitionFees { get; set; }

       
        public List<Course> Courses { get; set; } = new List<Course>();

        public Student()
        {

        }

        public Student(string firstName, string lastName, DateTime dateOfBirth, decimal fees)
        {
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
            TuitionFees = fees;
        }
    }
}
