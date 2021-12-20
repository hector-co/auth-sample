using System;
using System.Collections.Generic;

namespace MyShop.Customers.Domain.Model
{
    public partial class Customer 
    {
        public int Id { get; set; }
        public Guid Guid { get; set; }
        public string Name { get; set; }
        public bool Active { get; set; }
        public string UserId { get; set; }
    }
}