using Microsoft.EntityFrameworkCore;
using Api.Models;


namespace Api.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Usuario> Users { get; set; }
        public DbSet<Proyecto> Proyectos { get; set; }

        public DbSet<Email> Emails { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=main.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
    }
    }

}