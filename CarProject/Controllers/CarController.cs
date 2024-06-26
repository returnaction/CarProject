﻿using CarProject.DAL.Interfaces;
using CarProject.Domain.ViewModels;
using CarProject.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CarProject.Controllers
{
    public class CarController : Controller
    {
        private readonly ICarSerivce _carService;

        public CarController(ICarSerivce carService)
        {
            _carService = carService;
        }

        public async Task<IActionResult> GetCar(int id)
        {
            var response = await _carService.GetCar(id);
            return View(response);
        }

        public async Task<IActionResult> GetByName(string name)
        {
            var response = await _carService.GetCarByName(name);
            return View(response);
        }

        public async Task<IActionResult> GetCars()
        {
            var response = await _carService.GetCars();
            return View(response);
        }

        public async Task<IActionResult> DeleteCar(int id)
        {
            var response = await _carService.DeleteCar(id);
            return RedirectToAction("GetCars");

            
        }

        public async Task<IActionResult> CreateCar(CarViewModel carViewModel)
        {
            var response = await _carService.CreateCar(carViewModel);
            return View(response);
        }

        [HttpGet]
        public async Task<IActionResult> Save(int id)
        {
            if (id == 0)
                return View(new CarViewModel());

            var response = await _carService.GetCar(id);
            return View(response.Data);
        }


        [HttpPost]
        public async Task<IActionResult> Save(CarViewModel carViewModel)
        {
            if (ModelState.IsValid)
            {
                if (carViewModel.Id == 0)
                {
                    await _carService.CreateCar(carViewModel);
                }
                else
                {
                    await _carService.Edit(carViewModel.Id, carViewModel);
                }
            }

            return RedirectToAction("GetCars");
        }
    }
}
