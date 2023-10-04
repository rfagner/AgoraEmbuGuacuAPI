using AgoraEmbuGuacuAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace AgoraEmbuGuacuAPI.Context
{
    public class AgoraContext : DbContext
    {
        public AgoraContext(DbContextOptions<AgoraContext> options)
        : base(options)
        {
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Denuncia> Denuncias { get; set; }
        public DbSet<Comentario> Comentarios { get; set; }
        public DbSet<TipoUsuario> TipoUsuario { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Denuncia>()
                .HasMany(d => d.Comentarios)
                .WithOne()
                .HasForeignKey(c => c.DenunciaId);
        }

    }
}
