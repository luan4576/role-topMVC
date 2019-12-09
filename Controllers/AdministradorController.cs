using Microsoft.AspNetCore.Mvc;
using role_topMVC.Enums;
using role_topMVC.Repositories;
using role_topMVC.ViewModels;

namespace role_topMVC.Controllers
{
    public class AdministradorController : AbstractController
    {
        PacoteRepository pacoteRepository = new PacoteRepository();

        [HttpGet]

            public IActionResult DashBoard()
        {
            var tipoUsuarioSessao = uint.Parse(ObterUsuarioTipoSession());


            if(tipoUsuarioSessao.Equals( (uint) TiposUsuario.ADMINISTRADOR))
            {

            var pacotes = pacoteRepository.ObterTodos();
            DashboardViewModel dashboardViewModel = new DashboardViewModel();

            foreach (var pacote in pacotes)
            {
                switch (pacote.Status)
                {
                    case (uint) StatusPacote.REPROVADO :
                    dashboardViewModel.PacotesReprovados++;

                    break;
                    case (uint) StatusPacote.APROVADO:
                    dashboardViewModel.PacotesAprovados++;
                    break;
                    default:
                    dashboardViewModel.PacotesPendentes++;
                    dashboardViewModel.pacotes.Add(pacote);
                    break;
                }
            }

            dashboardViewModel.NomeView = "Dashboard";
            dashboardViewModel.UsuarioEmail = ObterUsuarioSession();

            return View(dashboardViewModel);
            }
            return View("Erro",new RespostaViewModel()
            {
                NomeView ="Dashboard",
                Mensagem = "so administrador"
            });
        }
    }
}