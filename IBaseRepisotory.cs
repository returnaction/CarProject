using System;

namespace CarProject.DAL.Interfaces
{
    public interface IBaseRepository<T>
    {
        bool Create(T entity);
        T Get(int id);
        IEnumarable<T> Select();
        bool Delete(T entity);



    }
}
  