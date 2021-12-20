using System;
using System.Collections.Generic;

namespace MyShop.Customers.Queries.Customers
{
    public class CustomerDto
    {
        public int Id { get; set; }
        public Guid Guid { get; set; }
        public string Name { get; set; }
        public bool Active { get; set; }
        public string UserId { get; set; }
    }
}
