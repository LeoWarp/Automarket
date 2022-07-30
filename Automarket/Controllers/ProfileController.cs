using System.Threading.Tasks;
using Automarket.Domain.ViewModels.Profile;
using Automarket.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Automarket.Controllers
{
    public class ProfileController : Controller
    {
        private readonly IProfileService _profileService;

        public ProfileController(IProfileService profileService)
        {
            _profileService = profileService;
        }

        [HttpPost]
        public async Task<IActionResult> Save(ProfileViewModel model)
        {
            ModelState.Remove("UserName");
            if (ModelState.IsValid)
            {
                await _profileService.Save(model);
            }
            return RedirectToAction("Detail");
        }
        
        public async Task<IActionResult> Detail()
        {
            var userName = User.Identity.Name;
            var response = await _profileService.GetProfile(userName);
            if (response.StatusCode == Domain.Enum.StatusCode.OK)
            {
                return View(response.Data);   
            }
            return View();
        }
    }
}