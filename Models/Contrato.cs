namespace role_topMVC.Models
{
    public class Contrato : Produto
    {
        public Contrato()
        {

        }

        public Contrato (string nome, double preco)
        {
            this.Nome=nome;
            this.Preco=preco;
        }
    }
}