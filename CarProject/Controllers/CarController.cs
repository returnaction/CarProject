﻿using CarProject.DAL.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CarProject.Controllers
{
    public class CarController : Controller
    {
        private readonly ICarRepository _carRepository;

        public CarController(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }

        public async Task<IActionResult> GetCars()
        {
            var responce = await  _carRepository.Select();
            return View(responce);
        }
    }
}
