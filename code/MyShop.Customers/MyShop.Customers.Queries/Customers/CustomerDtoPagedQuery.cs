using System;
using System.Collections.Generic;
using MediatR;
using Qurl;

namespace MyShop.Customers.Queries.Customers
{
    public class CustomerDtoPagedQuery : Query<CustomerDtoPagedQuery.FilterProperties>, IRequest<ResultModel<IEnumerable<CustomerDto>>>
    {
        public CustomerDtoPagedQuery() : base(new SortValue("Id", SortDirection.Ascending))
        {
        }

        public class FilterProperties
        {
            public FilterProperty<Guid> Guid { get; set; }
            public FilterProperty<string> Name { get; set; }
            public FilterProperty<bool> Active { get; set; }
            public FilterProperty<string> UserId { get; set; }
        }
    }
}
