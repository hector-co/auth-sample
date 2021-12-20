using MediatR;

namespace MyShop.Catalog.Commands.Products
{
    public class RegisterProductCommand : IRequest
    {
        public int SubCategoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<string> Images { get; set; }
        public float Price { get; set; }
        public float? Stock { get; set; }
    }
}
