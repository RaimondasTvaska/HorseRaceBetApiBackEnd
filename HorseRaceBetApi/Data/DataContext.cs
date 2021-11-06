using HorseRaceBetApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace HorseRaceBetApi.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Horse> Horses { get; set; }
        public DbSet<Better> Betters { get; set; }
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Horse>()
        //        .HasMany(b => b.Betters)
        //        .WithOne()
        //        .HasForeignKey(h => h.Horse_Id);
        //}
    }
}
