using API.Infrastructure.EF.Seeding;
using System.Linq;
using WebAPI.Infrastructure.EF;

namespace API.Infrastructure
{
    public static class DBContextExtension
    {
        public static void EnsureSeeded(this AssignmentDbContext context)
        {
            if (!context.Customers.Any())
            {
                CustomerSeeding.Seed(context);
                TransectionSeeding.Seed(context);
            }
        }
    }
}
