using API.Core.DomainModels;
using API.Core.DomainModels.Transactions;
using System.Linq;
using WebAPI.Infrastructure.EF;

namespace API.Infrastructure.EF.Seeding
{
    public static class TransectionSeeding
    {
        public static void Seed(AssignmentDbContext context)
        {
            var customer1 = context.Customers.First();
            var customer2 = context.Customers.Last();

            var transaction1C1 = new Transaction()
            {
                CurrencyCode = "USD",
                Amount = (decimal)39.75,
                Status = Status.Success,
                CustomerId = customer1.Id
            };
            var transaction2C1 = new Transaction()
            {
                CurrencyCode = "THB",
                Amount = (decimal)10,
                Status = Status.Failed,
                CustomerId = customer1.Id
            };
            var transaction3C1 = new Transaction()
            {
                CurrencyCode = "EUR",
                Amount = (decimal)35.09,
                Status = Status.Canceled,
                CustomerId = customer1.Id
            };

            context.Add(transaction1C1);
            context.Add(transaction2C1);
            context.Add(transaction3C1);

            var transaction1C2 = new Transaction()
            {
                CurrencyCode = "GBP",
                Amount = (decimal)11,
                Status = Status.Success,
                CustomerId = customer2.Id
            };
            var transaction2C2 = new Transaction()
            {
                CurrencyCode = "CNY",
                Amount = (decimal)9553.35,
                Status = Status.Failed,
                CustomerId = customer2.Id
            };
            var transaction3C2 = new Transaction()
            {
                CurrencyCode = "JYP",
                Amount = (decimal)365,
                Status = Status.Canceled,
                CustomerId = customer2.Id
            };

            context.Add(transaction1C2);
            context.Add(transaction2C2);
            context.Add(transaction3C2);

            context.SaveChanges();
        }
    }
}
