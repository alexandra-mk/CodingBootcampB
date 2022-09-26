using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingBootcampB
{
    public class Course : ILearningMaterial
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Stream { get; set; }
        public string Type { get; set; }

        public DateTime StartingDate { get; set; }
        public DateTime EndingDate { get; set; }

        // Navigation properties
        public List<Student> Students { get; set; } = new List<Student>();
        public List<Trainer> Trainers { get; set; } = new List<Trainer>();
        public List<Assignment> Assignments { get; set; } = new List<Assignment>();
        public Course()
        {

        }
        public Course(string title, string stream, string type, DateTime start, DateTime end)
        {
            Title = title;
            Stream = stream;
            Type = type;
            StartingDate = start;
            EndingDate = end;
        }
    }
}
