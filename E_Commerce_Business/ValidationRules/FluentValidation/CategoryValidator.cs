using E_Commerce_Entity.Concrete;
using FluentValidation;

namespace E_Commerce_Business.ValidationRules.FluentValidation
{
   public class CategoryValidator : AbstractValidator<Category>
   {
      public CategoryValidator()
      {
         RuleFor(p => p.CategoryName).NotEmpty();
         RuleFor(p => p.CategoryName).MinimumLength(3);
      }
   }
}
