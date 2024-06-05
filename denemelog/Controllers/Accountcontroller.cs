using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using denemelog.Models;

namespace denemelog.Controllers
{
    public class AccountController : Controller
    {
        [HttpGet]
        public IActionResult Register(string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel model, string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            if (ModelState.IsValid)
            {
               
                return RedirectToAction(nameof(HomeController.Index), "Home");
            }
            
            return View(model);
        }
    }
}