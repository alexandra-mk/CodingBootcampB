using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingBootcampB.Entities
{
    public class TrainersPerCourse : IPerCourse
    {
        public int TrainerID { get; set; }
        public int CourseID { get; set; }

        public string Title { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public TrainersPerCourse()
        {

        }

        public TrainersPerCourse(int trainerId, int courseId)
        {
            TrainerID = trainerId;
            CourseID = courseId;
        }
    }
}
