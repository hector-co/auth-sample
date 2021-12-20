using FluentValidation;

namespace MyShop.Catalog.Commands.Products
{
    public class RegisterProductCommandValidator : AbstractValidator<RegisterProductCommand>
    {
        public RegisterProductCommandValidator()
        {
            RuleFor(c => c.SubCategoryId).NotEmpty();
            RuleFor(c => c.Name).NotEmpty();
            RuleFor(c => c.Images).NotEmpty();
        }
    }
}
