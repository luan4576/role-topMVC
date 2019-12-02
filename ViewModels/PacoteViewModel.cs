using role_topMVC.Models;

namespace role_topMVC.ViewModels
{
    public class PacoteViewModel : BaseViewModel
    {
        public string NomeUsuario {get;set;}
        public Cliente cliente {get;set;}
        public PacoteViewModel()
        {
            this.NomeUsuario = "Jovem";
            this.cliente = new Cliente();
        }
    }
}