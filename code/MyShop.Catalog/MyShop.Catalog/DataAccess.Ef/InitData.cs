using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MyShop.Catalog.Domain.Model;

namespace MyShop.Catalog.DataAccess.Ef
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
            var context = scope.ServiceProvider.GetRequiredService<CatalogContext>();

            await context.Database.MigrateAsync(cancellationToken);

            if (_isDevEnv)
                await AddData(context, cancellationToken);
        }

        public Task StopAsync(CancellationToken cancellationToken) => Task.CompletedTask;

        private static async Task AddData(CatalogContext context, CancellationToken cancellationToken)
        {
            await AddCategories(context, cancellationToken);
            await AddProducts(context, cancellationToken);
        }

        private static async Task AddCategories(CatalogContext context, CancellationToken cancellationToken)
        {
            if (!context.Set<Category>().Any())
            {
                var categories = new[]
                {
                    new Category
                    {
                        Name = "Drinks",
                        DisplayOrder = 1,
                        SubCategories = new List<Category>
                        {
                            new Category
                            {
                                Name = "Juices",
                                DisplayOrder = 1,
                                Active = true
                            },
                            new Category
                            {
                                Name = "Beers",
                                DisplayOrder = 2,
                                Active = true
                            },
                            new Category
                            {
                                Name = "Wines",
                                DisplayOrder = 3,
                                Active = true
                            }
                        },
                        Active = true
                    }
                };
                foreach (var model in categories)
                {
                    context.Set<Category>().Add(model);
                    await context.SaveChangesAsync(cancellationToken);
                }
            }
        }

        private static async Task AddProducts(CatalogContext context, CancellationToken cancellationToken)
        {
            if (!context.Set<Product>().Any())
            {
                var products = new[]
                {
                    new Product
                    {
                        Guid = Guid.NewGuid(),
                        SubCategory = context.Set<Category>().Find(2),
                        Name = "Oferta1",
                        Description = "Descripción Oferta1",
                        Price = 150,
                        Images = new List<string> { "no-image" },
                        Active = true,
                        RegistrationDate = DateTime.SpecifyKind(new DateTime(2021, 1, 1), DateTimeKind.Utc),
                        Published = true,
                    },
                    new Product
                    {
                        Guid = Guid.NewGuid(),
                        SubCategory = context.Set<Category>().Find(3),
                        Name = "Oferta2",
                        Description = "Descripción Oferta2",
                        Price = 500,
                        Images = new List<string> { "no-image" },
                        Active = true,
                        RegistrationDate = DateTime.SpecifyKind(new DateTime(2021, 1, 15), DateTimeKind.Utc),
                        Published = true,
                        Stock = 10,
                    },
                    new Product
                    {
                        Guid = Guid.NewGuid(),
                        SubCategory = context.Set<Category>().Find(4),
                        Name = "Oferta3",
                        Description = "Descripción Oferta3",
                        Price = 250,
                        Images = new List<string> { "no-image" },
                        Active = true,
                        RegistrationDate = DateTime.SpecifyKind(new DateTime(2021, 2, 1), DateTimeKind.Utc),
                        Published = true,
                    },
                    new Product
                    {
                        Guid = Guid.NewGuid(),
                        SubCategory = context.Set<Category>().Find(2),
                        Name = "Oferta4",
                        Description = "Descripción Oferta4",
                        Price = 900,
                        Images = new List<string> { "no-image" },
                        Active = true,
                        RegistrationDate = DateTime.SpecifyKind(new DateTime(2021, 2, 10), DateTimeKind.Utc),
                        Published = true,
                        Stock = 20,
                    },
                    new Product
                    {
                        Guid = Guid.NewGuid(),
                        SubCategory = context.Set<Category>().Find(3),
                        Name = "Oferta5",
                        Description = "Descripción Oferta5",
                        Price = 1200,
                        Images = new List<string> { "no-image" },
                        Active = true,
                        RegistrationDate = DateTime.SpecifyKind(new DateTime(2021, 2, 25), DateTimeKind.Utc),
                        Published = true,
                    },
                    new Product
                    {
                        Guid = Guid.NewGuid(),
                        SubCategory = context.Set<Category>().Find(4),
                        Name = "Oferta6",
                        Description = "Descripción Oferta6",
                        Price = 2000,
                        Images = new List<string> { "no-image" },
                        Active = true,
                        RegistrationDate = DateTime.SpecifyKind(new DateTime(2021, 3, 5), DateTimeKind.Utc),
                        Published = true,
                        Stock = 30,
                    }
                };
                foreach (var model in products)
                {
                    context.Set<Product>().Add(model);
                    await context.SaveChangesAsync(cancellationToken);
                }
            }
        }
    }
}
