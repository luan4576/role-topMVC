using System.Collections.Generic;
using role_topMVC.Models;

namespace role_topMVC.Repositories
{
    public class ContratoRepository : RepositoryBase
    {
                private const string PATH = "Database/Pedido.csv";
        public ContratoRepository()
        {
            if (!File.Exists(PATH))
            {
                File.Create(PATH).Close();
            }
        }

        public bool Inserir(Contrato contrato)
        {
            var linha = new string [] {PrepararRegistroCSV(contrato)};
            
            File.AppendAllLines(PATH,linha);
            return true;
        }

        public List<Contrato> ObterTodos()
        {

            var linhas = File.ReadAllLines(PATH);
            List<Contrato> pedidos = new List<Contrato>();
            foreach (var linha in linhas)
            {
                Contrato contrato = new Contrato();
                contrato.Cliente.Nome = ExtrairValorDoCampo("cliente_nome", linha);
                contrato.Cliente.Cpf = ExtrairValorDoCampo("cliente_cpf", linha);
                contrato.Cliente.Email = ExtrairValorDoCampo("cliente_email", linha);
            }
        }

         private string PrepararRegistroCSV(Contrato contrato)
        {
            Cliente cliente = contrato.Cliente;
            

            return $"cliente_nome={cliente.Nome};cliente_endereco={cliente.Cpf};cliente_email={cliente.Email};data_pedido={contrato.DataDoPedido};preco-total={contrato.PrecoTotal}";
        }

    }
}