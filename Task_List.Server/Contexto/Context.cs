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
        public DbSet<Projeto> Projetos { get; set; }
        public DbSet<Recurso> Recursos { get; set; }
        public DbSet<Status> Status { get; set; }
        public DbSet<Tarefa> Tarefas { get; set; }
        public DbSet<TarefaRecursos> TarefaRecursos { get; set; }
        public DbSet<Tipo> Tipos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.ToTable("Usuarios");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Nome).HasMaxLength(50).IsRequired();
                entity.Property(e => e.Login).HasMaxLength(20).IsRequired();
                entity.Property(e => e.Senha).HasMaxLength(20).IsRequired();
                entity.Property(e => e.Cpf).HasMaxLength(11).IsRequired();
                entity.Property(e => e.Telefone).HasMaxLength(11);
            });

            modelBuilder.Entity<Projeto>(entity =>
            {
                entity.ToTable("Projetos");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Nome).HasMaxLength(50).IsRequired();
                entity.Property(e => e.Descricao).HasMaxLength(50).IsRequired();
                entity.Property(e => e.DataInicio).IsRequired();
                entity.Property(e => e.DataFim).IsRequired();
                entity.HasOne(p => p.Usuario).WithMany(u => u.Projetos).HasForeignKey(p => p.UsuarioId);
                entity.HasOne(p => p.Status).WithMany(u => u.Projeto).HasForeignKey(p => p.StatusId);
            });

            modelBuilder.Entity<Recurso>(entity =>
            {
                entity.ToTable("Recursos");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Descricao).HasMaxLength(50).IsRequired();
                entity.HasOne(r => r.Tipo).WithMany(t => t.Recursos).HasForeignKey(r => r.TipoId);
            });

            modelBuilder.Entity<Tipo>(entity =>
            {
                entity.ToTable("Tipos");
                entity.HasKey(t => t.Id);
                entity.Property(t => t.Descricao).IsRequired().HasMaxLength(100);
            });

            modelBuilder.Entity<Tarefa>(entity =>
            {
                entity.ToTable("Tarefas");
                entity.HasKey(t => t.Id);
                entity.Property(t => t.Nome).IsRequired().HasMaxLength(100);
                entity.Property(t => t.Descricao).HasMaxLength(500);
                entity.Property(t => t.DataPrevistaInicio).IsRequired();
                entity.Property(t => t.DataPrevistaFim).IsRequired();
                entity.Property(t => t.DataRealInicio);
                entity.Property(t => t.DataRealFim);
                entity.Property(t => t.DuracaoHoras);
                entity.HasOne(t => t.Status).WithMany(s => s.Tarefa).HasForeignKey(t => t.StatusId);
                entity.HasOne(t => t.Antecessora).WithMany().HasForeignKey(t => t.AntecessoraId);
                entity.HasMany(t => t.TarefaRecursos).WithOne(tr => tr.Tarefa).HasForeignKey(tr => tr.TarefaId);
            });

            modelBuilder.Entity<TarefaRecursos>(entity =>
            {
                entity.ToTable("TarefaRecursos");
                entity.HasKey(tr => tr.Id);
                entity.HasOne(tr => tr.Recurso).WithMany().HasForeignKey(tr => tr.RecursoId);
                entity.HasOne(tr => tr.Tarefa).WithMany().HasForeignKey(tr => tr.TarefaId);
            });

            modelBuilder.Entity<Status>(entity =>
            {
                entity.ToTable("Status");
                entity.HasKey(s => s.Id);
                entity.Property(s => s.Descricao).IsRequired().HasMaxLength(50);
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
