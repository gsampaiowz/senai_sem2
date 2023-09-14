using Microsoft.EntityFrameworkCore;
using webapi.inlock.codefirst.Domains;

namespace webapi.inlock.codefirst.Contexts
    {
    public class InlockContext : DbContext
        {
        public DbSet<TipoUsuario> TipoUsuario { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Estudio> Estudio { get; set; }
        public DbSet<Jogo> Jogo { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
            optionsBuilder.UseSqlServer("Server = NOTE10-S14\\SQLEXPRESS; Database = Inlock_Games_CodeFirst_Tarde; User Id = sa; Password = Senai@134; TrustServerCertificate = True;");
            base.OnConfiguring(optionsBuilder);
            }
        }
    }
