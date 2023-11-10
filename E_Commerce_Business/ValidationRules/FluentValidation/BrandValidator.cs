using E_Commerce_Entity.Concrete;
using FluentValidation;

namespace E_Commerce_Business.ValidationRules.FluentValidation
{
   public class BrandValidator : AbstractValidator<Brand>
   {
      public BrandValidator()
      {
         RuleFor(p => p.BrandName).NotEmpty();
         RuleFor(p => p.BrandName).MinimumLength(3);
      }
   }
}
