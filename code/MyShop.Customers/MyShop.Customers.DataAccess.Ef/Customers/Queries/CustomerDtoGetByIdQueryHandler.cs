using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MyShop.Customers.Domain.Model;
using MyShop.Customers.Queries;
using MyShop.Customers.Queries.Customers;

namespace MyShop.Customers.DataAccess.Ef.Customers.Queries
{
    public class CustomerDtoGetByIdQueryHandler : IRequestHandler<CustomerDtoGetByIdQuery, ResultModel<CustomerDto>>
    {
        private readonly CustomersContext _context;

        public CustomerDtoGetByIdQueryHandler(CustomersContext context)
        {
            _context = context;
        }

        public async Task<ResultModel<CustomerDto>> Handle(CustomerDtoGetByIdQuery request, CancellationToken cancellationToken)
        {
            IQueryable<Customer> efQuery = _context.Set<Customer>();

            var data = await efQuery
                    .AsNoTracking()
                    .FirstOrDefaultAsync(m => request.Id == m.Id, cancellationToken);

            var result = new ResultModel<CustomerDto>
            {
                Data = data.Adapt<CustomerDto>()
            };

            return result;
        }
    }
}