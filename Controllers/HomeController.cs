using Microsoft.AspNetCore.Mvc;
using role_topMVC.ViewModels;

namespace role_topMVC.Controllers
{
    public class HomeController : AbstractController
    {
        public IActionResult Index()
        {
            
            return View(new BaseViewModel()
            {
                NomeView = "Home",
                UsuarioNome = ObterUsuarioNomeSession(),
                UsuarioEmail = ObterUsuarioSession()
            });
        }
    }
}