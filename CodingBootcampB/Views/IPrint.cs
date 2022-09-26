using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingBootcampB.Views
{
    public interface IPrint<T>
    {
        void PrintHeader();
        void Print(T t);
        void PrintList(List<T> t);
    }
}
