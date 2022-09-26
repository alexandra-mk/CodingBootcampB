using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingBootcampB
{
    public class Assignment : ILearningMaterial
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime SubmissionDate { get; set; }
        public int OralMark { get; set; }
        public int TotalMark { get; set; }
        public Course Course { get; set; }
        // foreign key
        public int CourseID { get; set; }
        

        public Assignment()
        {

        }
        public Assignment(string title, string description, DateTime submission, int oralMark, int totalMark, int courseId)
        {
            Title = title;
            Description = description;
            SubmissionDate = submission;
            OralMark = oralMark;
            TotalMark = totalMark;
            CourseID = courseId;
        }

      
    }
}
