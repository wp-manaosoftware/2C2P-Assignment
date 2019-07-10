using Microsoft.EntityFrameworkCore;
using API.Core.DomainModels;

namespace RoadWatch.Infrastructure.DAL.EF.Mappings
{
    public static class CustomerMap
    {
        public static ModelBuilder MapCustomer(this ModelBuilder modelBuilder)
        {
            var entity = modelBuilder.Entity<Customer>();
            entity.ToTable("Customers");
            entity.Property(c => c.Id).ValueGeneratedOnAdd();
            entity.Property(c => c.Name);
            entity.Property(c => c.ContactEmail);
            entity.Property(c => c.MobileNo);
            entity.Property(c => c.CreatedDate);
            entity.Property(c => c.UpdatedDate);
            entity.HasMany(c => c.Transactions).WithOne(c => c.Customer).HasForeignKey(c => c.CustomerId);
            return modelBuilder;
        }
    }
}
