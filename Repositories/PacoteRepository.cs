using System.Collections.Generic;
using System.IO;
using role_topMVC.Models;

namespace role_topMVC.Repositories
{
    public class PacoteRepository : RepositoryBase
    {
                private const string PATH = "Database/Pedido.csv";
        public PacoteRepository()
        {
            if (!File.Exists(PATH))
            {
                File.Create(PATH).Close();
            }
        }

        public bool Inserir(Pacote pacote)
        {
            var linha = new string [] {PrepararRegistroCSV(pacote)};
            
            File.AppendAllLines(PATH,linha);
            return true;
        }

        public List<Pacote> ObterTodos()
        {

            var linhas = File.ReadAllLines(PATH);
            List<Pacote> pacotes = new List<Pacote>();
            foreach (var linha in linhas)
            {
                Pacote pacote = new Pacote();
                pacote.Cliente.Nome = ExtrairValorDoCampo("cliente_nome", linha);
                pacote.Cliente.Cpf = ExtrairValorDoCampo("cliente_cpf", linha);
                pacote.Cliente.Email = ExtrairValorDoCampo("cliente_email", linha);

                pacotes.Add(pacote);
            }

            return pacotes;
        }

         public List<Pacote> ObterTodosPorCliente(string email)
        {
            var pedidosTotais = ObterTodos();
            List<Pacote> pedidosCliente = new List<Pacote>();
            foreach(var pedido in pedidosTotais)
            {
                if(pedido.Cliente.Email.Equals(email))
                {
                    pedidosCliente.Add(pedido);
                }
            }
            return pedidosCliente;

        }



         private string PrepararRegistroCSV(Pacote pacote)
        {
            Cliente cliente = pacote.Cliente;
            

            return $"cliente_nome={cliente.Nome};cliente_endereco={cliente.Cpf};cliente_email={cliente.Email};preco-total={pacote.PrecoTotal}";
        }

    }
}