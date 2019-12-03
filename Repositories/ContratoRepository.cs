using System.Collections.Generic;
using System.IO;
using role_topMVC.Models;

namespace role_topMVC.Repositories
{
    public class ContratoRepository
    {
        private const string PATH = "Database/Contrato.csv";

        public ContratoRepository()
        {
            if (!File.Exists(PATH))
            {
                File.Create(PATH).Close();
            }
        }

        public double ObterPrecoDe(string nomeContrato)
        {
            var lista = ObterTodos();
            double preco = 0.0;
            foreach (var item in lista)
            {
                if(item.Nome.Equals(nomeContrato))
                {
                    preco = item.Preco;
                    break;
                }
            }
            return preco;
        }

         public List<Contrato> ObterTodos()
        {
            List<Contrato> contratos = new List<Contrato>();
            string [] linhas = File.ReadAllLines(PATH);
            foreach(var linha in linhas)
            {
                Contrato h = new Contrato();
                string [] dados = linha.Split(";");
                h.Nome = dados[0];
                h.Preco = double.Parse(dados[1]);
                contratos.Add(h);

            }

            return contratos;
        }
    }
}