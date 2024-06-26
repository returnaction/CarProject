﻿using CarProject.DAL.Interfaces;
using CarProject.Domain.Entity;
using CarProject.Domain.Enum;
using CarProject.Domain.Response;
using CarProject.Domain.ViewModels;
using CarProject.Service.Interfaces;
using GoogleApi.Entities;
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

        public async Task<IBaseResponse<bool>> CreateCar(CarViewModel carViewModel)
        {
            var baseResponse = new BaseResponse<bool>();

            try
            {
                var car = new Car()
                {
                    Description = carViewModel.Description,
                    DateCreate = carViewModel.DateCreate,
                    Model = carViewModel.Model,
                    Price = carViewModel.Price,
                    Speed = carViewModel.Speed,
                    Name = carViewModel.Name,
                    TypeCar = (TypeCar)Convert.ToInt32(carViewModel.TypeCar)
                };

                await _carRepository.Create(car);

                baseResponse.StatusCode = StatusCode.OK;
                baseResponse.Description = "Машина создана";
                return baseResponse;
            }
            catch (Exception ex)
            {
                return new BaseResponse<bool>()
                {
                    Description = $"[CreateCar] : {ex.Message}"
                };
            }
        }

        public async Task<IBaseResponse<bool>> DeleteCar(int id)
        {
            var baseResponse = new BaseResponse<bool>();
            try
            {
                var car = await _carRepository.Get(id);
                if( car is null)
                {
                    baseResponse.StatusCode = StatusCode.OK;
                    baseResponse.Description = "Машина не найдена";
                }
                await _carRepository.Delete(car);
                baseResponse.StatusCode = StatusCode.OK;
                baseResponse.Description = "Машина удалена";
                return baseResponse;

            }
            catch (Exception ex)
            {
                return new BaseResponse<bool>()
                {
                    Description = $"[DeleteCar] : {ex.Message}"
                };
            }
        }

        public async Task<IBaseResponse<Car>> Edit(int id, CarViewModel carViewModel)
        {
            var baseResponse = new BaseResponse<Car>();

            try
            {
                var car = await _carRepository.Get(id);
                if(car is null)
                {
                    baseResponse.StatusCode = StatusCode.CarNotFound;
                    baseResponse.Description = "Машина не найдена";
                }

                car.Description = carViewModel.Description;
                car.Price = carViewModel.Price;
                car.DateCreate = carViewModel.DateCreate;
                car.Model = carViewModel.Model;
                car.Name = carViewModel.Name;
                car.TypeCar = (TypeCar)Convert.ToInt32(carViewModel.TypeCar);

                await _carRepository.Update(car);

                baseResponse.StatusCode = StatusCode.OK;
                baseResponse.Data = car;
                return baseResponse;
            }
            catch (Exception ex)
            {
                return new BaseResponse<Car>()
                {
                    Description = $"[EditCar] : {ex.Message}"
                };
            }
        }

        public async Task<IBaseResponse<CarViewModel>> GetCar(int id)
        {
            var baseResponse = new BaseResponse<CarViewModel>();

            try
            {
                var car = await _carRepository.Get(id);

                if (car is null)
                {
                    baseResponse.StatusCode = StatusCode.OK;
                    baseResponse.Description = "Машина не найдена";
                    return baseResponse;
                }

                var carViewMode = new CarViewModel()
                {
                    Id = car.Id,
                    Name = car.Name,
                    Model = car.Model,
                    Description = car.Description,
                    DateCreate = car.DateCreate,
                    TypeCar = car.TypeCar.ToString(),
                    Price = car.Price,
                    Speed = car.Speed
                };

                baseResponse.Data = carViewMode;
                baseResponse.StatusCode = StatusCode.OK;
                return baseResponse;

            }
            catch (Exception ex)
            {
                return new BaseResponse<CarViewModel>()
                {
                    Description = $"[GetCar] : {ex.Message}"
                };
            }
        }

        public async Task<IBaseResponse<Car>> GetCarByName(string name)
        {
            var baseResponse = new BaseResponse<Car>();

            try
            {
                var car = await _carRepository.GetCarByName(name);
                if(car is null)
                {
                    baseResponse.Description = "Машина не найдена";
                    baseResponse.StatusCode = StatusCode.OK;
                    return baseResponse;
                }

                baseResponse.Data = car;
                baseResponse.StatusCode = StatusCode.OK;
                return baseResponse;
            }
            catch (Exception ex)
            {
                return new BaseResponse<Car>()
                {
                    Description = $"[GetByName] : {ex.Message}"
                };
            }
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
