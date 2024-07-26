using Microsoft.EntityFrameworkCore;
using Task_List.Server.Models;

namespace Task_List.Server.Contexto
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) :
            base(options)
        {
        }

        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.ToTable("Usuarios");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Nome).HasMaxLength(50);
                entity.Property(e => e.Funcao).HasMaxLength(100);
            });
        }
    }
}
