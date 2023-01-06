using FluentValidation;

namespace StoreApp.Dtos.Category
{
    public class CategoryPostDto
    {
        public string Name { get; set; }
    }
    public class CategoryPostDtoValidator : AbstractValidator<CategoryPostDto>
    {
        public CategoryPostDtoValidator()
        {
            RuleFor(c => c.Name).MaximumLength(20).NotEmpty();
        }
    }
}
