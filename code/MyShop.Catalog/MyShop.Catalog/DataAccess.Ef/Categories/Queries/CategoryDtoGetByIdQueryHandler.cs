using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MyShop.Catalog.Domain.Model;
using MyShop.Catalog.Queries;
using MyShop.Catalog.Queries.Categories;

namespace MyShop.Catalog.DataAccess.Ef.Categories.Queries
{
    public class CategoryDtoGetByIdQueryHandler : IRequestHandler<CategoryDtoGetByIdQuery, ResultModel<CategoryDto>>
    {
        private readonly CatalogContext _context;

        public CategoryDtoGetByIdQueryHandler(CatalogContext context)
        {
            _context = context;
        }

        public async Task<ResultModel<CategoryDto>> Handle(CategoryDtoGetByIdQuery request, CancellationToken cancellationToken)
        {
            IQueryable<Category> efQuery = _context.Set<Category>();

            efQuery = efQuery.AddIncludes();

            var data = await efQuery
                    .AsNoTracking()
                    .FirstOrDefaultAsync(m => request.Id == m.Id, cancellationToken);

            var result = new ResultModel<CategoryDto>
            {
                Data = data.Adapt<CategoryDto>()
            };

            return result;
        }
    }
}