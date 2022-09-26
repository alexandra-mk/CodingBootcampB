using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingBootcampB.RepositoryServices
{
    public interface IRepository<T1, T2>
    {
        List<T1> GetAll();
        void Add(T1 t);
        void Update(T1 t);
        void Delete(T2 t);
    }
}
