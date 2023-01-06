using FluentValidation;

namespace StoreApp.Dtos.ProductDtos
{
    public class ProductPutDto
    {
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public decimal CostPrice { get; set; }
        public decimal SalePrice { get; set; }
        public decimal DiscountPercent { get; set; }
    }
    public class ProductPutDtoValidator : AbstractValidator<ProductPutDto>
    {
        public ProductPutDtoValidator()
        {
            RuleFor(x => x.Name).MaximumLength(25).NotEmpty();
            RuleFor(x => x.CostPrice).GreaterThan(-1);
            RuleFor(x => x.SalePrice).GreaterThan(-1);
            RuleFor(x => x.DiscountPercent).InclusiveBetween(-1, 101);
        }
    }
}
