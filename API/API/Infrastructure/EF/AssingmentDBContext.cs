using API.Core.DomainModels;
using API.Infrastructure.EF.Mapping;
using Microsoft.EntityFrameworkCore;
using RoadWatch.Infrastructure.DAL.EF.Mappings;

namespace WebAPI.Infrastructure.EF
{
    public class AssignmentDbContext : DbContext
    {
        public AssignmentDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Transaction> Transactions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.MapCustomer();
            modelBuilder.MapTransaction();
            base.OnModelCreating(modelBuilder);
        }
    }
}
