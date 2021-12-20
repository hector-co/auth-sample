using MediatR;
using MyShop.Catalog.Commands.Products;
using MyShop.Catalog.Domain.Model;
using Shared.Auth;

namespace MyShop.Catalog.DataAccess.Ef.Products.Commands
{
    public class RegisterProductCommandHandler : IRequestHandler<RegisterProductCommand>
    {
        private readonly CatalogContext _context;
        private readonly ISessionInfo _sessionInfo;

        public RegisterProductCommandHandler(CatalogContext context, ISessionInfo sessionInfo)
        {
            _context = context;
            _sessionInfo = sessionInfo;
        }

        public async Task<Unit> Handle(RegisterProductCommand request, CancellationToken cancellationToken)
        {
            var product = new Product
            {
                Guid = Guid.NewGuid(),
                Name = request.Name,
                Description = request.Description,
                Images = request.Images,
                Price = request.Price,
                Stock = request.Stock,
                SubCategoryId = request.SubCategoryId,
                Active = true
            };
            _context.Add(product);

            await _context.SaveChangesAsync(cancellationToken);

            return await Unit.Task;
        }
    }
}
