using Microsoft.EntityFrameworkCore;
using MyMoneyAPI.Data.EntityMapping;
using MyMoneyAPI.Models;
using System.Security.Principal;

namespace MyMoneyAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<AccountEntity> Accounts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Apply Fluent API configurations from separate classes
            modelBuilder.ApplyConfiguration(new AccountConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
