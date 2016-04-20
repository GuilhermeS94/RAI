using System.Text;
using System.Security.Cryptography;

namespace Modelo
{
    /// <summary>
    /// Classe de metodos utilitarios
    /// </summary>
    public class Utils
    {
        /// <summary>
        /// Método que faz hash de senha para
        /// guardar no banco
        /// </summary>
        /// <param name="senha"></param>
        /// <returns>Hash string 32 chars de senha</returns>
        public static string GetHashSenha(string senha)
        {
            using (MD5 md5Hash = MD5.Create())
            {
                byte[] dados = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(senha));
                StringBuilder sb = new StringBuilder();

                // Loop para cada byte do hash do array 
                // e formata numa string hexa
                for (int i = 0; i < dados.Length; i++)
                {
                    sb.Append(dados[i].ToString("x2"));
                }

                // Returna a string hexa
                return sb.ToString();
            }
        }
    }
}
