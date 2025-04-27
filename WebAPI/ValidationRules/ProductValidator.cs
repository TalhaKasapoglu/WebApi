using FluentValidation;
using WebAPI.Entities;

namespace WebAPI.ValidationRules
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(p => p.ProductName).NotEmpty().WithMessage("Product name cannot be left blank!")
                .MinimumLength(5).WithMessage("Product name must have at least 5 character input!")
                .MaximumLength(100).WithMessage("Produc name must be a maximum of 100 characters!");

            RuleFor(p => p.Price).NotEmpty().WithMessage("Price cannot be left blank!")
                .GreaterThan(0).WithMessage("Price cannot take negative values!");

            RuleFor(p => p.ProductDescription).NotEmpty().WithMessage("Product description cannot be left blank!");
        }
    }
}
