using System;

namespace role_topMVC.Models
{
    public class Cliente
    {
        public string Nome {get;set;}
        public string Cpf {get;set;}
        public string Senha {get;set;}
        public string Email {get;set;}
        


        

        public Cliente(string nome ,string Cpf,string senha, string email )
        {
            this.Nome=nome;
            this.Cpf = Cpf;
            this.Senha=senha;
            this.Email=email;
        
            
            
        }

        public uint TipoUsuario {get;set;}
        public int NumeroCartao {get;set;}
        public string SenhaCartao {get;set;}
        public Cliente()
        {
    
        }
    }
}