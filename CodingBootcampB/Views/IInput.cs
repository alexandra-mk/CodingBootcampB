using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingBootcampB.Views
{
    public interface IInput<T1, T2>
    {
        T1 GetData();
        T1 GetDataToUpdate();
        T2 GetIDToDeleteOrUpdate(string s);
        
    }
}
