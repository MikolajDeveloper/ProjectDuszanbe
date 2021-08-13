using Microsoft.EntityFrameworkCore;
using ProjectDuszanbe.Domain.Model;

namespace ProjectDuszanbe.Infrastructure
{
    public class Context : DbContext
    {
        public DbSet<Language> Languages { get; set; }
        public DbSet<Translation> Translations { get; set; }
        public DbSet<Word> Words { get; set; }

        public Context(DbContextOptions options) : base(options)
        {
            
        }
        
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}