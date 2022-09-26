using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingBootcampB
{
    public interface IPerCourse
    {
        int CourseID { get; set; }
        string Title { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
    }
}
