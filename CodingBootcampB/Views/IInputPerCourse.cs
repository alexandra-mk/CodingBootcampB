using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingBootcampB.Views
{
    public interface IInputPerCourse<T>
    {
        T GetData();
        T GetDataToUpdate();
        T GetDataToDelete();
    }
}
