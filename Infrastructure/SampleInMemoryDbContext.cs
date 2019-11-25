using Microsoft.EntityFrameworkCore;
using AlintaEnergy.Infrastructure.Model;
using System;

namespace AlintaEnergy.Infrastructure
{
    public class SampleInMemoryDbContext : DbContext
    {
        public SampleInMemoryDbContext(
           DbContextOptions<SampleInMemoryDbContext> dbContextOptions)
           : base(dbContextOptions) { }

        public DbSet<Customer> Customers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>()
                .HasKey(x => x.Id);
        }
    }
}
