using System;
using MediatR;

namespace MyShop.Catalog.Queries.Categories
{
    public class CategoryDtoGetByIdQuery : IRequest<ResultModel<CategoryDto>>
    {
        public CategoryDtoGetByIdQuery()
        {
        }

        public CategoryDtoGetByIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
