using System;
using System.Collections.Generic;
using MediatR;
using Qurl;

namespace MyShop.Catalog.Queries.Categories
{
    public class CategoryDtoPagedQuery : Query<CategoryDtoPagedQuery.FilterProperties>, IRequest<ResultModel<IEnumerable<CategoryDto>>>
    {
        public CategoryDtoPagedQuery() : base(new SortValue("Id", SortDirection.Ascending))
        {
        }

        public class FilterProperties
        {
            public FilterProperty<int> SubCategoriesId { get; set; }
            public FilterProperty<string> Name { get; set; }
            public FilterProperty<string> Description { get; set; }
            public FilterProperty<string> Image { get; set; }
            public FilterProperty<int> DisplayOrder { get; set; }
            public FilterProperty<int> PublishedProductsCount { get; set; }
            public FilterProperty<bool> Active { get; set; }
        }
    }
}
