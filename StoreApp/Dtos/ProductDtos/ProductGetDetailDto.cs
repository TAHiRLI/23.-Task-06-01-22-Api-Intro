using Microsoft.Data.SqlClient;

namespace StoreApp.Dtos.ProductDtos
{
    public class ProductGetDetailDto
    {
        public int Id { get; set; } 
        public string Name { get; set; }
        public decimal SalePrice { get; set; }
        public decimal DiscountPrectent { get; set; }
        public CategoryDtoInProductDetailDto Category { get; set; }
    }
    public class CategoryDtoInProductDetailDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
