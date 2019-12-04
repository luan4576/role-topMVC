namespace role_topMVC.Models
{
    public class Cliente
    {
        public string Nome {get;set;}
        public string Cpf {get;set;}
        public string Senha {get;set;}
        public string Email {get;set;}
        public string NumeroCartao {get;set;}
        public string SenhaCartao {get;set;}
        

        public Cliente(string nome ,string Cpf,string senha, string email,string numeroCartao,string senhaCartao)
        {
            this.Nome=nome;
            this.Cpf = Cpf;
            this.Senha=senha;
            this.Email=email;
            this.NumeroCartao = numeroCartao;
            this.SenhaCartao = senhaCartao;
            
        }

        public uint TipoUsuario {get;set;}

        public Cliente()
        {
        
        }
    }
}