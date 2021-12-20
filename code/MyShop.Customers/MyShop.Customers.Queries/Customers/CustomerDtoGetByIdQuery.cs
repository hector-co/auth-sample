using System;
using MediatR;

namespace MyShop.Customers.Queries.Customers
{
    public class CustomerDtoGetByIdQuery : IRequest<ResultModel<CustomerDto>>
    {
        public CustomerDtoGetByIdQuery()
        {
        }

        public CustomerDtoGetByIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
