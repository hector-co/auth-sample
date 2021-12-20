using System;
using MediatR;

namespace MyShop.Catalog.Queries.Products
{
    public class ProductDtoGetByIdQuery : IRequest<ResultModel<ProductDto>>
    {
        public ProductDtoGetByIdQuery()
        {
        }

        public ProductDtoGetByIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
