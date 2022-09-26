using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingBootcampB
{
    public interface ILearningMaterial
    {
        int ID { get; set; }
        string Title { get; set; }
    }
}
