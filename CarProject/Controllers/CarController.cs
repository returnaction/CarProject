using CarProject.DAL.Interfaces;
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

        public async Task<IActionResult> GetCars()
        {
            var response = await  _carService.GetCars();
            return View(response);
        }
    }
}
