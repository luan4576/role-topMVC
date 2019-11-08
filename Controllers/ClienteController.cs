using Microsoft.AspNetCore.Mvc;

namespace role_topMVC.Controllers
{
    public class ClienteController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }
    }
}