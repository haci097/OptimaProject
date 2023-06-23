using FluentValidation;
using OptimaProject.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OptimaProject.Utilities.ValidationRules
{
    public class CustomerValidator : AbstractValidator<Customer>
    {
        public CustomerValidator()
        {
            RuleFor(c => c.CustomerName).NotEmpty().WithMessage("Müştəri adı boş ola bilməz!");
        }
    }
}
