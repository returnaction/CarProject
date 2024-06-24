using CarProject.Domain.Entity;
using CarProject.Domain.Response;
using CarProject.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarProject.Service.Interfaces
{
    public interface ICarSerivce
    {
        Task<IBaseResponse<List<Car>>> GetCars();
        Task<IBaseResponse<Car>> GetCarByName(string name);
        Task<IBaseResponse<Car>> GetCar(int id);
        Task<IBaseResponse<bool>> DeleteCar(int id);
        Task<IBaseResponse<bool>> CreateCar(CarViewModel car);
        Task<IBaseResponse<Car>> Edit(int id, CarViewModel model);


    }
}
