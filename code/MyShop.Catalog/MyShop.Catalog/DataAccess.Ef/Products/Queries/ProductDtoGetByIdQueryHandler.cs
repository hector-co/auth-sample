using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MyShop.Catalog.Domain.Model;
using MyShop.Catalog.Queries;
using MyShop.Catalog.Queries.Products;

namespace MyShop.Catalog.DataAccess.Ef.Products.Queries
{
    public class ProductDtoGetByIdQueryHandler : IRequestHandler<ProductDtoGetByIdQuery, ResultModel<ProductDto>>
    {
        private readonly CatalogContext _context;

        public ProductDtoGetByIdQueryHandler(CatalogContext context)
        {
            _context = context;
        }

        public async Task<ResultModel<ProductDto>> Handle(ProductDtoGetByIdQuery request, CancellationToken cancellationToken)
        {
            IQueryable<Product> efQuery = _context.Set<Product>();

            efQuery = efQuery.AddIncludes();

            var data = await efQuery
                    .AsNoTracking()
                    .FirstOrDefaultAsync(m => request.Id == m.Id, cancellationToken);

            var result = new ResultModel<ProductDto>
            {
                Data = data.Adapt<ProductDto>()
            };

            return result;
        }
    }
}