using CarProject.DAL.Interfaces;
using CarProject.Domain.Entity;
using CarProject.Domain.Enum;
using CarProject.Domain.Response;
using CarProject.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarProject.Service.Implementaions
{
    public class CarSerivce : ICarSerivce
    {
        private readonly ICarRepository _carRepository;

        public CarSerivce(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }

        public async Task<IBaseResponse<List<Car>>> GetCars()
        {
            var baseResponse = new BaseResponse<List<Car>>();

            try
            {
                List<Car> cars = await _carRepository.Select();
                if(cars.Count == 0)
                {
                    baseResponse.Description = "Найдено 0 елементов";
                    baseResponse.StatusCode = StatusCode.OK;
                    return baseResponse;
                }
                baseResponse.Data = cars;
                baseResponse.StatusCode = StatusCode.OK;
                return baseResponse;

            }
            catch (Exception ex)
            {

                return new BaseResponse<List<Car>>()
                {
                    Description = $"[GetCars] : {ex.Message}"
                };
            }
        }
    }
}
