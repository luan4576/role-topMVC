using Microsoft.AspNetCore.Mvc;
using role_topMVC.ViewModels;

namespace role_topMVC.Controllers
{
    public class GaleriaController : AbstractController
    {
         public IActionResult Fotos () {
            return View (new BaseViewModel()
            {
                NomeView = "Galeria",
                UsuarioEmail = ObterUsuarioSession(),
                UsuarioNome = ObterUsuarioNomeSession()
            });
        }
    }
}