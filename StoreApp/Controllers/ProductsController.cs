using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Store.Data;
using Store.Data.Entities;
using StoreApp.Dtos.ProductDtos;
using StoreApp.Helpers;
using System.Net.Http.Headers;
using System.Text;
using Microsoft.AspNetCore.Hosting;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace StoreApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly StoreDbContext _context;
        private readonly IHostingEnvironment _env;

        public ProductsController(StoreDbContext context,IHostingEnvironment env)
        {
            this._context = context;
            this._env = env;
        }
        [HttpGet("Id")]
        public IActionResult Get(int Id)
        {
            var product = _context.Products.Include(x=> x.Category).FirstOrDefault(x => x.Id == Id);
            if (product == null)
                return NotFound();

            ProductGetDetailDto productDto = new ProductGetDetailDto
            {
                Id = product.Id,
                Name = product.Name,
                SalePrice = product.SalePrice,
                DiscountPrectent = product.DiscountPercent,
                Category = new CategoryDtoInProductDetailDto
                {
                    Name = product.Category.Name,
                    Id = product.Category.Id
                }

            };

            return Ok(productDto);
        }

        [HttpPost]
        public IActionResult Create(ProductPostDto productDto)
        {

            Product product = new Product
            {
                Name = productDto.Name,
                SalePrice = productDto.SalePrice,
                CostPrice =productDto.CostPrice,
                CategoryId = productDto.CategoryId,
                DiscountPercent = productDto.DiscountPercent,   
            };

            _context.Products.Add(product);
            _context.SaveChanges();

            return Created("", product);
        }
        [HttpPut("id")]
        public IActionResult Edit(int id, ProductPutDto productDto)
        {
            var product = _context.Products.Include(x=> x.Category).FirstOrDefault(x => x.Id == id);
            if(product == null)
            return NotFound();
            var category = _context.Categories.FirstOrDefault(x => x.Id == productDto.CategoryId);
            if (category == null)
                return NotFound();


            product.Name = productDto.Name;
            product.CostPrice = productDto.CostPrice;
            product.SalePrice = productDto.SalePrice;
            product.DiscountPercent = productDto.DiscountPercent;
            product.Category = category;

            _context.SaveChanges();

            return NoContent();
        }
        [HttpDelete("id")]
        public IActionResult Delete(int id)
        {
            var product = _context.Products.FirstOrDefault(x => x.Id == id);
            if (product == null)
                return NotFound();
            _context.Products.Remove(product);
            _context.SaveChanges();
            return NoContent();
        }

        /// <summary>
        ///     testing to upload just a single file without validaiton
        /// </summary>

        [HttpPost("file")]
        public async Task<IActionResult> Upload(IFormFile file)
        {
        
            if (file == null)
                return NotFound();


            FileManager.Save(file,this._env.ContentRootPath, "Uploads", 100);

            return Ok();
        }
    }
}
