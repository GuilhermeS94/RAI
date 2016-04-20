using System.Linq;
using Modelo;
using System.Data.Entity.Migrations;

namespace Controle
{    
    public class NegociosControle
    {
        ModeloEntity db = new ModeloEntity();

        /// <summary>
        /// Buscar o usuário pelo ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Um usuario(Objeto Pessoas)</returns>
        public Pessoas BuscarUsuario(int id)
        {
            Pessoas p;

            p = db.Pessoas.Find(id);
            p.Senha = string.Empty;
            return p;
        }

        /// <summary>
        /// Atualiza as informações de um usuário
        /// </summary>
        /// <param name="p"></param>
        /// <returns>Retorna um bool de acordo com a operação realizada de Update</returns>
        public bool AtualizarUsuario(Pessoas p)
        {
            Pessoas aux = db.Pessoas.Where(ps => ps.Id == p.Id).First();//dados antigos para comparar

            //caso o suário apague algum campo, ele irá substituir pelo valor antigo
            if (string.IsNullOrEmpty(p.Email.Trim()))
                p.Email = aux.Email;
            if (string.IsNullOrEmpty(p.Login.Trim()))
                p.Login = aux.Login;
            if (string.IsNullOrEmpty(p.Nome.Trim()))
                p.Nome = aux.Nome;
            if (string.IsNullOrEmpty(p.Senha.Trim()))
                p.Senha = aux.Senha;
            
            db.Pessoas.AddOrUpdate(p);
            db.SaveChanges();//"commit"

            return true;
        }

        /// <summary>
        /// Lista de usuários cadastrados
        /// </summary>
        /// <returns>Uma lista de usuários(Objeto Pessoas)</returns>
        public IQueryable<Pessoas> ListarUsuarios()
        {
            return db.Pessoas;
        }

        /// <summary>
        /// Deletar um suário
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public bool DeletarUsuario(Pessoas p)
        {
            db.Pessoas.Remove(p);
            int n = db.SaveChanges();

            if (n > 0)
                return true;
            else
                return false;
        }
    }
}
