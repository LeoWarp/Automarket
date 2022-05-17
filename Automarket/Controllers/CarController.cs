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

        public IActionResult Compare() => PartialView();
        
        [HttpGet]
        public async Task<IActionResult> Save(int id)
        {
            if (id == 0) 
                return PartialView();

            var response = await _carService.GetCar(id);
            if (response.StatusCode == Domain.Enum.StatusCode.OK)
            {
                return PartialView(response.Data);
            }
            ModelState.AddModelError("", response.Description);
            return PartialView();
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
        
        
        [HttpGet]
        public async Task<ActionResult> GetCar(int id, bool isJson)
        {
            var response = await _carService.GetCar(id);
            if (isJson)
            {
                return Json(response.Data);
            }
            return PartialView("GetCar", response.Data);
        }
        
        [HttpPost]
        public async Task<IActionResult> GetCar(string term, int page = 1, int pageSize = 5)
        {
            var response = await _carService.GetCar(term);
            return Json(response.Data);
        }
        
        [HttpPost]
        public JsonResult GetTypes()
        {
            var types = _carService.GetTypes();
            return Json(types.Data);
        }
    }
}