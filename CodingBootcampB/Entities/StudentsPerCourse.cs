using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingBootcampB.Entities
{
    public class StudentsPerCourse : IPerCourse
    {
        public int StudentID { get; set; }
        public int CourseID { get; set; }

        public string Title { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public StudentsPerCourse()
        {
                
        }

        public StudentsPerCourse(int studentId, int courseId)
        {
            StudentID = studentId;
            CourseID = courseId;
        }
    }
}
