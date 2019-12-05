using System;
using role_topMVC.Enums;

namespace role_topMVC.Models
{
    public class Pacote
    {
        public ulong Id {get;set;}
        public Cliente Cliente {get;set;}
        public Contrato Contrato {get;set;}
        public DateTime DataContrato  {get;set;}
        public double PrecoTotal {get;set;}
        public uint Status {get;set;}

        public Pacote()
        {
            this.Cliente = new Cliente();
            this.Contrato = new Contrato();
            this.Id = 0;
            this.Status = (uint) StatusPacote.PENDENTE;
            this.DataContrato = DataContrato;
            
        }
    }
}