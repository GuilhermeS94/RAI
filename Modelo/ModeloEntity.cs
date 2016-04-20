namespace Modelo
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ModeloEntity : DbContext
    {
        /// <summary>
        /// Classe ENTITY que "converte" tabelas em classes
        /// e queries em métodos
        /// </summary>
        public ModeloEntity()
            : base("name=ModeloEntity")
        {
        }

        public virtual DbSet<Pessoas> Pessoas { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pessoas>()
                .Property(e => e.Login)
                .IsUnicode(false);

            modelBuilder.Entity<Pessoas>()
                .Property(e => e.Senha)
                .IsUnicode(false);

            modelBuilder.Entity<Pessoas>()
                .Property(e => e.Nome)
                .IsUnicode(false);

            modelBuilder.Entity<Pessoas>()
                .Property(e => e.Email)
                .IsUnicode(false);
        }
    }
}
