using System.Collections.Generic;
using role_topMVC.Models;

namespace role_topMVC.ViewModels
{
    public class PacoteViewModel : BaseViewModel
    {
        public List<Contrato> Contratos {get;set;}
        public string NomeUsuario {get;set;}
        public Cliente cliente {get;set;}
        public PacoteViewModel()
        {
            this.NomeUsuario = "Jovem";
            this.cliente = new Cliente();
            this.Contratos = new List<Contrato>();
        }
    }
}