using System;
using System.Collections.Generic;
using System.IO;
using role_topMVC.Models;

namespace role_topMVC.Repositories
{
    public class PacoteRepository : RepositoryBase
    {
                private const string PATH = "Database/Pacote.csv";
        public PacoteRepository()
        {
            if (!File.Exists(PATH))
            {
                File.Create(PATH).Close();
            }
        }

        public bool Inserir(Pacote pacote)
        {
            var quantidadeLinhas = File.ReadAllLines(PATH).Length;
            pacote.Id = (ulong) ++quantidadeLinhas;
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
                pacote.Id = ulong.Parse (ExtrairValorDoCampo("id",linha));
                pacote.Status = uint.Parse(ExtrairValorDoCampo("status_pacote", linha));
                pacote.Cliente.Email = ExtrairValorDoCampo("cliente_email",linha);
                pacote.Cliente.Senha = ExtrairValorDoCampo("cliente_senha",linha);
                pacote.Cliente.Cpf = ExtrairValorDoCampo("cliente_cpf",linha);
                pacote.Contrato.Nome = ExtrairValorDoCampo("contrato_nome",linha);
                pacote.Contrato.Preco = double.Parse (ExtrairValorDoCampo("contrato_preco",linha));
                pacote.DataContrato = DateTime.Parse(ExtrairValorDoCampo("data_contrato",linha));
                

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
            var linhaPacote = -1;
            var resultado = false;

            for (int i = 0; i < pacotesTotais.Length; i++)
            {
                var idConvertido = ulong.Parse (ExtrairValorDoCampo ("id" ,pacotesTotais[i]));
                if (pacote.Id.Equals(idConvertido))
                {
                    linhaPacote= i;
                    resultado = true;
                    break;
                }
            }

            if(resultado) {
                pacotesTotais[linhaPacote] = pacoteCSV;
                File.WriteAllLines(PATH, pacotesTotais);
            }

            return resultado;

        }


        private string PrepararRegistroCSV(Pacote pacote)
        {
            Cliente cliente = pacote.Cliente;
            Contrato contrato = pacote.Contrato;
            

            return $"id={pacote.Id};status_pacote={pacote.Status};cliente_email={cliente.Email};cliente_senha={cliente.Senha};cliente_cpf={cliente.Cpf};contrato_nome={contrato.Nome};contrato_preco={contrato.Preco};preco-total={pacote.PrecoTotal};data_contrato={pacote.DataContrato}";
        }

    }
}