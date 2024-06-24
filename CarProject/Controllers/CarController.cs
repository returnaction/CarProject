using CarProject.DAL.Interfaces;
using CarProject.Domain.ViewModels;
using CarProject.Service.Interfaces;
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
            var response = await  _carService.GetCars();
            return View(response);
        }

        public async Task<IActionResult> DeleteCar(int id)
        {
            var response = await _carService.DeleteCar(id);
            return View(response);
        }

        public async Task<IActionResult> CreateCar(CarViewModel carViewModel)
        {
            var response = await _carService.CreateCar(carViewModel);
            return View(response);
        }
    }
}
