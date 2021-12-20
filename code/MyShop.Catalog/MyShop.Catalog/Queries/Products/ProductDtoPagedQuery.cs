using System;
using System.Collections.Generic;
using MediatR;
using Qurl;

namespace MyShop.Catalog.Queries.Products
{
    public class ProductDtoPagedQuery : Query<ProductDtoPagedQuery.FilterProperties>, IRequest<ResultModel<IEnumerable<ProductDto>>>
    {
        public ProductDtoPagedQuery() : base(new SortValue("Id", SortDirection.Ascending))
        {
        }

        public class FilterProperties
        {
            public FilterProperty<Guid> Guid { get; set; }
            public FilterProperty<int> SubCategoryId { get; set; }
            public FilterProperty<string> Name { get; set; }
            public FilterProperty<string> Description { get; set; }
            public FilterProperty<string> Images { get; set; }
            public FilterProperty<float> Price { get; set; }
            public FilterProperty<float?> Stock { get; set; }
            public FilterProperty<bool> Published { get; set; }
            public FilterProperty<DateTimeOffset> RegistrationDate { get; set; }
            public FilterProperty<bool> Active { get; set; }
        }
    }
}
