using Microsoft.AspNetCore.Mvc;

namespace FastFood.Controllers
{
    public class ContactController:Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
