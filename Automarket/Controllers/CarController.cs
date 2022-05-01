using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Automarket.Domain.ViewModels.Car;
using Automarket.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Automarket.Controllers
{
    public class CarController : Controller
    {
        private readonly ICarService _carService;

        public CarController(ICarService carService)
        {
            _carService = carService;
        }

        [HttpGet]
        public IActionResult GetCars()
        {
            var response = _carService.GetCars();
            if (response.StatusCode == Domain.Enum.StatusCode.OK)
            {
                return View(response.Data);   
            }
            return View("Error", $"{response.Description}");
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _carService.DeleteCar(id);
            if (response.StatusCode == Domain.Enum.StatusCode.OK)
            {
                return RedirectToAction("GetCars");
            }
            return View("Error", $"{response.Description}");
        }

        [HttpGet]
        public async Task<IActionResult> Save(int id)
        {
            if (id == 0) 
                return View();

            var response = await _carService.GetCar(id);
            if (response.StatusCode == Domain.Enum.StatusCode.OK)
            {
                return View(response.Data);
            }
            ModelState.AddModelError("", response.Description);
            return View();
        }

        // string Name, string Model, double Speed, string Description, decimal Price, string TypeCar, IFormFile Avatar
        [HttpPost]
        public async Task<IActionResult> Save(CarViewModel model)
        {
            ModelState.Remove("DateCreate");
            if (ModelState.IsValid)
            {
                if (model.Id == 0)
                {
                    byte[] imageData;
                    using (var binaryReader = new BinaryReader(model.Avatar.OpenReadStream()))
                    {
                        imageData = binaryReader.ReadBytes((int)model.Avatar.Length);
                    }
                    await _carService.Create(model, imageData);
                }
                else
                {
                    await _carService.Edit(model.Id, model);
                }
                return RedirectToAction("GetCars");   
            }
            return View();
        }
        
        public async Task<ActionResult> GetCar(int id)
        {
            var response = await _carService.GetCar(id);
            return PartialView("GetCar", response.Data);
        }
        
        [HttpPost]
        public JsonResult GetTypes()
        {
            var types = _carService.GetTypes();
            return Json(types.Data);
        }
    }
}