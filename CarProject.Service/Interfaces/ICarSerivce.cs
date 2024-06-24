using CarProject.Domain.Entity;
using CarProject.Domain.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarProject.Service.Interfaces
{
    public interface ICarSerivce
    {
        Task<IBaseResponse<IEnumerable<Car>>> GetCars();
    }
}
