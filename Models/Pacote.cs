using System;

namespace role_topMVC.Models
{
    public class Pacote
    {
        public Cliente Cliente {get;set;}
        public DateTime DataDoContrato  {get;set;}
        public double PrecoTotal {get;set;}

        public Pacote()
        {
            this.Cliente = new Cliente();
        }
    }
}