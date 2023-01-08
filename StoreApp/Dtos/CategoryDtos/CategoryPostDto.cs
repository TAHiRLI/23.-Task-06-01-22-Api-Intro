using FluentValidation;

namespace StoreApp.Dtos.Category
{
    public class CategoryPostDto
    {
       // /// <summary>
      //  /// this is for a category name
       // /// <example>categoryName</example>
      //  /// </summary>
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
