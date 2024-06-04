using Microsoft.EntityFrameworkCore;
using MyTE.Models;
using Projeto.Myte.WebAPI.BackEnd.Models.Entities;

namespace MyTE.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        // Referencia às entities definidas na aplicação
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Departamento> Departamentos { get; set; }
        public DbSet<TipoUsuario> TiposUsuarios { get; set; }
        public DbSet<RegistroHoras> RegistrosHoras { get; set; }
        public DbSet<Wbs> Wbs { get; set; }

        // OnModelCreating ajuda a fazer o mapeamento da relação entre as tabelas
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Mapeamento da entidade Departamento
            modelBuilder.Entity<Departamento>()
                .HasKey(d => d.IdDepartamento); // Define a chave primária
            modelBuilder.Entity<Departamento>().ToTable("Departamentos"); 

            // Mapeamento da entidade Usuario
            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario); // Define a chave primária
                entity.HasOne(e => e.Departamento)
                      .WithMany(d => d.Usuarios) // Um departamento tem muitos usuários
                      .HasForeignKey(e => e.IdDepartamento)
                      .OnDelete(DeleteBehavior.Restrict); // Define o comportamento ao deletar um departamento

                entity.HasOne(e => e.TipoUsuario)
                      .WithMany(t => t.Usuarios)
                      .HasForeignKey(e => e.IdTipoUsuario)
                      .OnDelete(DeleteBehavior.SetNull);

                entity.Property(e => e.DataContratacao)  // Configura a nova coluna
                    .IsRequired();

                entity.ToTable("Usuarios"); 
            });

            modelBuilder.Entity<TipoUsuario>().ToTable("TiposUsuarios"); 

            modelBuilder.Entity<RegistroHoras>()
                .HasOne(rh => rh.Wbs)
                .WithMany(w => w.RegistrosHoras)
                .HasForeignKey(rh => rh.IdWBS)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<RegistroHoras>().ToTable("RegistrosHoras"); 

            modelBuilder.Entity<Wbs>().ToTable("Wbs"); 

            base.OnModelCreating(modelBuilder);
        }
    }
}
