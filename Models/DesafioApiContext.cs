namespace DesafioApi.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DesafioApiContext : DbContext
    {
        public DesafioApiContext()
            : base("name=DesafioApiContext")
        {
        }

        public virtual DbSet<Marca> Marca { get; set; }
        public virtual DbSet<Patrimonio> Patrimonio { get; set; }

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Marca>()
        //        .Property(e => e.MarcaNome)
        //        .IsUnicode(false);

        //    modelBuilder.Entity<Marca>()
        //        .HasMany(e => e.Patrimonio)
        //        .WithRequired(e => e.Marca)
        //        .WillCascadeOnDelete(false);

        //    modelBuilder.Entity<Patrimonio>()
        //        .Property(e => e.PatrimonioNome)
        //        .IsUnicode(false);

        //    modelBuilder.Entity<Patrimonio>()
        //        .Property(e => e.PatrimonioDescricao)
        //        .IsUnicode(false);
        //}
    }
}
