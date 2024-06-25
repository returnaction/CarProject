using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarProject.DAL.Interfaces
{
    public interface IBaseRepository<T>
    {
        Task<T> Get(int id);
        Task<List<T>> Select();
        Task<bool> Delete(T entity);
        Task<bool> Create(T entity);
        Task<T> Update(T entity);
    }
}
