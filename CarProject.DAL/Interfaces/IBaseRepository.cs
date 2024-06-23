using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarProject.DAL.Interfaces
{
    public interface IBaseRepository<T>
    {
        T Get(T entity);
        IEnumerable<T> Select();
        bool Delete();
        bool Create();
    }
}
