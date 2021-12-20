using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Qurl.Queryable;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MyShop.Customers.Domain.Model;
using MyShop.Customers.Queries;
using MyShop.Customers.Queries.Customers;

namespace MyShop.Customers.DataAccess.Ef.Customers.Queries
{
    public class CustomerDtoPagedQueryHandler : IRequestHandler<CustomerDtoPagedQuery, ResultModel<IEnumerable<CustomerDto>>>
    {
        private readonly CustomersContext _context;

        public CustomerDtoPagedQueryHandler(CustomersContext context)
        {
            _context = context;
        }

        public async Task<ResultModel<IEnumerable<CustomerDto>>> Handle(CustomerDtoPagedQuery request, CancellationToken cancellationToken)
        {
            var result = new ResultModel<IEnumerable<CustomerDto>>();

            var efQuery = _context.Set<Customer>().ApplyQuery(request, false);
            result.TotalCount = await efQuery.CountAsync(cancellationToken);
            efQuery = efQuery.ApplySortAndPaging(request);

            var data = await efQuery
                .AsNoTracking()
                .ToListAsync(cancellationToken);
           
            result.Data = data.Adapt<List<CustomerDto>>();

            return result;
        }
    }
}