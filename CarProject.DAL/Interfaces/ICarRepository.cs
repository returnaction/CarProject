using CarProject.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarProject.DAL.Interfaces
{
    public interface ICarRepository : IBaseRepository<Car>
    {
        Task<Car> GetCarByName(string name);
    }
}
