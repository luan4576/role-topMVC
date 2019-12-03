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
            var pacotesTotais = ObterTodos();
            List<Pacote> pacotesCliente = new List<Pacote>();
            foreach(var pacote in pacotesTotais)
            {
                if(pacote.Cliente.Email.Equals(email))
                {
                    pacotesCliente.Add(pacote);
                }
            }
            return pacotesCliente;
        }

         public Pacote ObterPor(ulong id )
        {
            var pacotesTotais = ObterTodos();
            foreach (var pacote in pacotesTotais)
            {
                if(pacote.Id == id)
                {
                    return pacote;
                }
            }
            return null;
        }

        public bool Atualizar ( Pacote pacote)
        {
            var pacotesTotais = File.ReadAllLines(PATH);
            var pacoteCSV = PrepararRegistroCSV(pacote);
            var linhaPedido = -1;
            var resultado = false;

            for (int i = 0; i < pacotesTotais.Length; i++)
            {
                var idConvertido = ulong.Parse (ExtrairValorDoCampo ("id" ,pacotesTotais[i]));
                if (pacote.Id.Equals(idConvertido))
                {
                    linhaPedido = i;
                    resultado = true;
                    break;
                }
            }

            if(resultado) {
                pacotesTotais[linhaPedido] = pacoteCSV;
                File.WriteAllLines(PATH, pacotesTotais);
            }

            return resultado;

        }

//escrever o resto das coisas//
         private string PrepararRegistroCSV(Pacote pacote)
        {
            Cliente cliente = pacote.Cliente;
            Contrato contrato = pacote.Contrato;
            

            return $"id ={pacote.Id};status_pedido={pacote.Status};cliente_nome={cliente.Nome};cliente_endereco={cliente.Cpf};cliente_email={cliente.Email};preco-total={pacote.PrecoTotal}";
        }

    }
}