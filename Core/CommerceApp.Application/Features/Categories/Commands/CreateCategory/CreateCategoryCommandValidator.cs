using FluentValidation;

namespace CommerceApp.Application.Features.Categories.Commands.CreateCategory
{
    public class CreateCategoryCommandValidator:AbstractValidator<CreateCategoryCommandRequest>
    {
        public CreateCategoryCommandValidator()
        {
            RuleFor(p => p.Name).NotEmpty();
            RuleFor(p => p.Priority).GreaterThan(0);
            RuleFor(p => p.ParentId).GreaterThanOrEqualTo(0);
        }
    }
}
