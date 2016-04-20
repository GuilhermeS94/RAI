using System.ComponentModel.DataAnnotations;

namespace GrupoRAI.Models
{
    /// <summary>
    /// Classe modelo para tela de login
    /// </summary>
    public class Login
    {
        [Required(ErrorMessage = "Preencher o Login")]
        [StringLength(50)]
        public string Usuario { get; set; }

        [Required(ErrorMessage = "Preencher a Senha")]
        [DataType(DataType.Password)]
        [StringLength(35)]
        public string Senha { get; set; }
    }
}
