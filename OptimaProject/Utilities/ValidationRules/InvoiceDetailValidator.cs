using FluentValidation;
using OptimaProject.Entities.Concrete;

namespace OptimaProject.Utilities.ValidationRules
{
    public class InvoiceDetailValidator : AbstractValidator<InvoiceDetail>
    {
        public InvoiceDetailValidator()
        {
            RuleFor(i => i.InvoiceId).NotEmpty().WithMessage("Qaimə nömrəsi boş ola bilməz!"); ;   
            RuleFor(i => i.ProductId).NotEmpty().WithMessage("Məhsul adı boş ola bilməz!"); ;   
            RuleFor(i => i.ProductPrice).NotEmpty().WithMessage("Məhsul qiyməti boş ola bilməz!"); ;   
            RuleFor(i => i.ProductCount).NotEmpty().WithMessage("Məhsul sayı boş ola bilməz!"); ;   
        }
    }
}
