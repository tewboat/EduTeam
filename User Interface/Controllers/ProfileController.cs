using Microsoft.AspNetCore.Mvc;

namespace User_Interface.Controllers
{
    public class ProfileController : Controller
    {
        public IActionResult Profile()
        {
            return View();
        }
    }
}