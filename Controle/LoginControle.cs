using System.Linq;
using Modelo;

namespace Controle
{
    public class LoginControle
    {
        ModeloEntity db = new ModeloEntity();
        /// <summary>
        /// Verifica se o usuário existe
        /// </summary>
        /// <param name="usuario"></param>
        /// <param name="senha"></param>
        /// <returns>Completa um Objeto para Session</returns>
        public Pessoas EfetuarLogin(string usuario, string senha)
        {
            Pessoas p;

            var ps = db.Pessoas.Where(l => l.Login == usuario && l.Senha == senha);

            if (ps.Any())
                p = ps.First();
            else
                return null;

            p.Senha = string.Empty;
            return p;
        }

        /// <summary>
        /// Cadastra um novo usuário no banco
        /// </summary>
        /// <param name="p"></param>
        /// <returns>Retorna um bool se a operação foi um sucesso ou não</returns>
        public bool NovoUsuario(Pessoas p)
        {
            db.Pessoas.Add(p);
            int mudanca = db.SaveChanges();// SaveChangesAsync();

            if (mudanca == 1)
                return true;
            else
                return false;
        }
    }
}
