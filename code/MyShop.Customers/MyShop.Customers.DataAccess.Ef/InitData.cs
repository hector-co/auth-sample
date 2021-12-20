using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MyShop.Customers.Domain.Model;

namespace MyShop.Customers.DataAccess.Ef
{
    public class InitData : IHostedService
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly bool _isDevEnv;

        public InitData(IServiceProvider serviceProvider, bool isDevEnv = true)
        {
            _serviceProvider = serviceProvider;
            _isDevEnv = isDevEnv;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            using var scope = _serviceProvider.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<CustomersContext>();

            await context.Database.MigrateAsync(cancellationToken);

            if (_isDevEnv)
                await AddData(context, cancellationToken);
        }

        public Task StopAsync(CancellationToken cancellationToken) => Task.CompletedTask;

        private static async Task AddData(CustomersContext context, CancellationToken cancellationToken)
        {
            await AddCategories(context, cancellationToken);
        }

        private static async Task AddCategories(CustomersContext context, CancellationToken cancellationToken)
        {
            if (!context.Set<Customer>().Any())
            {
                var customers = new[]
                {
                    new Customer
                    {
                        Name = "Customer1",
                        Guid = Guid.NewGuid(),
                        UserId = "",
                        Active = true
                    }
                };
                foreach (var model in customers)
                {
                    context.Set<Customer>().Add(model);
                    await context.SaveChangesAsync(cancellationToken);
                }
            }
        }
    }
}
