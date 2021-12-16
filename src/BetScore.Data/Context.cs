using BetScore.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace BetScore.Data.Repositories
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        //public DbSet<CharacteristicConfig> CharacteristicConfigs { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(Context).Assembly);

            //modelBuilder.Entity<CharacteristicsConfigCustomValue>(e => { e.HasNoKey(); });
            //modelBuilder.Entity<CharacteristicEntity>(e => { e.HasNoKey(); });

        }

        public async Task<bool> Commit()
        {
            return await base.SaveChangesAsync() > 0;
        }

    }
}
