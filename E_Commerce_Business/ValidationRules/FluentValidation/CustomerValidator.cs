using E_Commerce_Entity.Concrete;
using FluentValidation;

namespace E_Commerce_Business.ValidationRules.FluentValidation
{
   public class CustomerValidator : AbstractValidator<Customer>
   {
      public CustomerValidator()
      {
         RuleFor(p => p.CustomerName).NotEmpty();
         RuleFor(p => p.CustomerLastName).NotEmpty();

         RuleFor(p => p.CustomerName).MinimumLength(3);
         RuleFor(p => p.CustomerLastName).MinimumLength(3);
      }
   }
}
