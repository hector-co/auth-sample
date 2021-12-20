using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Qurl.Queryable;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MyShop.Catalog.Domain.Model;
using MyShop.Catalog.Queries;
using MyShop.Catalog.Queries.Categories;

namespace MyShop.Catalog.DataAccess.Ef.Categories.Queries
{
    public class CategoryDtoPagedQueryHandler : IRequestHandler<CategoryDtoPagedQuery, ResultModel<IEnumerable<CategoryDto>>>
    {
        private readonly CatalogContext _context;

        public CategoryDtoPagedQueryHandler(CatalogContext context)
        {
            _context = context;
        }

        public async Task<ResultModel<IEnumerable<CategoryDto>>> Handle(CategoryDtoPagedQuery request, CancellationToken cancellationToken)
        {
            var result = new ResultModel<IEnumerable<CategoryDto>>();

            var efQuery = _context.Set<Category>().ApplyQuery(request, false);
            efQuery = efQuery.Where(c => c.CategoryId == null);
            result.TotalCount = await efQuery.CountAsync(cancellationToken);
            efQuery = efQuery.ApplySortAndPaging(request);

            efQuery = efQuery.AddIncludes();
            
            var data = await efQuery
                .AsNoTracking()
                .ToListAsync(cancellationToken);
           
            result.Data = data.Adapt<List<CategoryDto>>();

            return result;
        }
    }
}