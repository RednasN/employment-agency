using Jex.Domain;
using Jex.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Jex.Infrastructure.Persistence
{
    public class JexDbcontext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(databaseName: "JexDb");
        }
        public DbSet<Vacancy> Vacancies { get; set; }
        public DbSet<Company> Companies { get; set; }
    }
}
