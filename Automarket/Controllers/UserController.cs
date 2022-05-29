using System;
using System.Threading.Tasks;
using Automarket.Domain.Enum;
using Automarket.Domain.ViewModels.User;
using Automarket.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Automarket.Controllers
{
    [Authorize(Roles = "Admin")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> Details()
        {
            var response = await _userService.GetUsers();
            if (response.StatusCode == Domain.Enum.StatusCode.OK)
            {
                return View(response.Data);   
            }
            return RedirectToAction("Index", "Home");
        }
        
        [HttpPost]
        public async Task<IActionResult> DeleteUser(long id)
        {
            var response = await _userService.Delete(id);
            return Ok(response);
        }
        
        [HttpGet]
        public async Task<ActionResult> GetUser(int id)
        {
            var response = await _userService.GetUser(id);
            return PartialView("GetUser", response.Data);
        }
        
        [HttpPost]
        public async Task<IActionResult> Save(UserViewModel model)
        {
            var z = Enum.Parse<Role>(model.Role);
            if (ModelState.IsValid)
            {
                /*return RedirectToAction("GetCars");*/   
            }

            return Ok();
        }
    }
}