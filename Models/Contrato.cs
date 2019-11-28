namespace role_topMVC.Models
{
    public class Contrato
    {
        public Cliente Cliente {get;set;}
        public double PrecoTotal {get;set;}

        public Contrato()
        {
            this.Cliente = new Cliente();
            
    
        }
}
}