using System.Collections.Generic;
using role_topMVC.Models;

namespace role_topMVC.ViewModels
{
    public class DashboardViewModel : BaseViewModel
    {
        public List<Pacote> pacotes {get;set;} 
        public uint PacotesAprovados {get;set;}
        public uint PacotesReprovados {get;set;}
        public uint PacotesPendentes {get;set;}
        public DashboardViewModel()
        {
        this.pacotes = new List<Pacote>();
        }
    }
}