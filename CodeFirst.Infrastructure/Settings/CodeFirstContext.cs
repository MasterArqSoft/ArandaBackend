using CodeFirst.Domain.Entities;
using CodeFirst.Infrastructure.Seeds;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace CodeFirst.Infrastructure.Settings
{
    public class CodeFirstContext : DbContext
    {
        public CodeFirstContext()
        {
        }

        public CodeFirstContext(DbContextOptions<CodeFirstContext> options)
            : base(options)
        {
        }
        public virtual DbSet<Product> Productos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            modelBuilder.SeedData();
        }
    }
}