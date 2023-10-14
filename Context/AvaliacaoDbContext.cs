using Avaliacoes.Domain;
using Microsoft.EntityFrameworkCore;

namespace Avaliacoes.Context
{
    public class AvaliacaoDbContext : DbContext
    {
        public AvaliacaoDbContext(DbContextOptions<AvaliacaoDbContext> options) : base(options) { }
    
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Avaliacao> Avaliacao { get; set; }

        public DbSet<Divisao> Divisao { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>().HasMany(a => a.Avaliacoes).WithOne(u => u.Usuario).HasForeignKey(a => a.AvaliacaoId);           
            modelBuilder.Entity<Divisao>().HasMany(u => u.Usuarios).WithOne(d => d.Divisao).HasForeignKey(d => d.DivisaoId);            
        }
    }
}
