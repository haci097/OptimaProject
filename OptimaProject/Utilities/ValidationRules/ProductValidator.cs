using FluentValidation;
using OptimaProject.Entities.Concrete;

namespace OptimaProject.Utilities.ValidationRules
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(c => c.ProductName).NotEmpty().WithMessage("Məhsul adı boş ola bilməz!");
        }
    }
}
