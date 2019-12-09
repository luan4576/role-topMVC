using System.IO;
using role_topMVC.Models;

namespace role_topMVC.Repositories
{
    public class ClienteRepository : RepositoryBase
    {
        private const string PATH = "Database/Cliente.csv";
        public ClienteRepository()
        {
            if(!File.Exists(PATH))
            {
                File.Create(PATH).Close();
            }

        }
            public bool Inserir (Cliente cliente)
            {
                var linha = new string[] {PrepararRegistroCSV(cliente)};
                File.AppendAllLines (PATH,linha);

                return true;
            
            }

            public Cliente ObterPor(string email)
            {
                var linhas = File.ReadAllLines(PATH);
                foreach(var linha in linhas)
                {
                    if(ExtrairValorDoCampo("email", linha).Equals(email))
                    {
                        Cliente c = new Cliente ();
                        c.Nome = ExtrairValorDoCampo("nome",linha);
                        c.Cpf = ExtrairValorDoCampo("cpf",linha);
                        c.Email = ExtrairValorDoCampo("email", linha);
                        c.Senha = ExtrairValorDoCampo("senha", linha);
                        c.TipoUsuario = uint.Parse(ExtrairValorDoCampo("tipo_usuario",linha));
                        return c;
                    }
                    
                }
                return null;
            }

            private string PrepararRegistroCSV(Cliente cliente)
            {
                return $"tipo_usuario={cliente.TipoUsuario};nome={cliente.Nome};cpf={cliente.Cpf};email={cliente.Email};senha={cliente.Senha}";
            }
    }
}