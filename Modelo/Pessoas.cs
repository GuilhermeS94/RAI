namespace Modelo
{
    using System.ComponentModel.DataAnnotations;

    public partial class Pessoas
    {
        /// <summary>
        /// Classe enteidade do banco
        /// </summary>
        public int Id { get; set; }

        [Required(ErrorMessage = "Preencher o Login")]
        [StringLength(50)]
        public string Login { get; set; }

        [Required(ErrorMessage = "Preencher a Senha")]
        [StringLength(35)]
        public string Senha { get; set; }

        [Required(ErrorMessage = "Preencher o Nome")]
        [StringLength(100)]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Preencher o Email")]
        [Display(Name = "E-Mail")]
        [StringLength(100)]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Nível")]
        public short Nivel { get; set; }
    }
}
