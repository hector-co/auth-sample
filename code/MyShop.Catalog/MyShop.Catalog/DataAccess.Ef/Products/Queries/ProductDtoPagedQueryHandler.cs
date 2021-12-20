using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Qurl.Queryable;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MyShop.Catalog.Domain.Model;
using MyShop.Catalog.Queries;
using MyShop.Catalog.Queries.Products;

namespace MyShop.Catalog.DataAccess.Ef.Products.Queries
{
    public class ProductDtoPagedQueryHandler : IRequestHandler<ProductDtoPagedQuery, ResultModel<IEnumerable<ProductDto>>>
    {
        private readonly CatalogContext _context;

        public ProductDtoPagedQueryHandler(CatalogContext context)
        {
            _context = context;
        }

        public async Task<ResultModel<IEnumerable<ProductDto>>> Handle(ProductDtoPagedQuery request, CancellationToken cancellationToken)
        {
            var result = new ResultModel<IEnumerable<ProductDto>>();

            var efQuery = _context.Set<Product>().ApplyQuery(request, false);
            result.TotalCount = await efQuery.CountAsync(cancellationToken);
            efQuery = efQuery.ApplySortAndPaging(request);

            efQuery = efQuery.AddIncludes();
            
            var data = await efQuery
                .AsNoTracking()
                .ToListAsync(cancellationToken);
           
            result.Data = data.Adapt<List<ProductDto>>();

            return result;
        }
    }
}