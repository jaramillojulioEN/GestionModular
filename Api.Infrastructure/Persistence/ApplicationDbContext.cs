using Api.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Api.Infrastructure.Persistence
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {
        }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Almacen> Almacenes { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categoria>(entity => 
            {
                entity.ToTable("Categorias");
                entity.HasKey(p=> p.Id);
                entity.Property(p=>p.NombreCategoria).HasMaxLength(250);
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.ToTable("Usuarios");
                entity.HasKey(p => p.Id);
                entity.Property(p => p.NombreCompleto).HasMaxLength(250);
            });

            modelBuilder.Entity<Almacen>(entity =>
            {
                entity.ToTable("Almacenes");
                entity.HasKey(p => p.Id);
                entity.Property(a => a.Descripcion).HasMaxLength(250);
            });

            modelBuilder.Entity<Producto>(entity =>
            {
                entity.ToTable("Productos");
                entity.HasKey(p => p.Id);
                entity.HasOne(p => p.Categoria).WithMany(c => c.Productos).HasForeignKey(p => p.IdCategoria);
                entity.HasOne(p => p.Almacen).WithMany(a => a.Productos).HasForeignKey(p => p.IdAlmacen);
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
