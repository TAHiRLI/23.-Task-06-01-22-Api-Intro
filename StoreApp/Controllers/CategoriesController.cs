using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Store.Data;
using Store.Data.Entities;
using StoreApp.Dtos.Category;

namespace StoreApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly StoreDbContext _context;

        
        public CategoriesController(StoreDbContext context)
        {
            this._context = context;
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var category = _context.Categories.FirstOrDefault(c => c.Id == id);
            if (category == null)
                return NotFound();

            CategoryGetDetailDto categoryGetDto = new CategoryGetDetailDto
            {
                Id = category.Id,
                Name = category.Name,
            };
            return Ok(categoryGetDto);
        }

        [HttpGet("")]
        public IActionResult GetAll()
        {
            var categories = _context.Categories.ToList();
            List<CategoryListItemDto> categoryDtoList = categories.Select(x => new CategoryListItemDto
            {
                Id=x.Id,
                Name=x.Name,
            }).ToList();
            return Ok(categoryDtoList);
        }
        [HttpPost]
        public IActionResult Create(CategoryPostDto categoryDto)
        {

            var category = new Category
            {
                Name = categoryDto.Name
            };

            _context.Categories.Add(category);
            _context.SaveChanges();
            return Created("", category);
        }
        [HttpPut("{id}")]
        public IActionResult Update(int id, CategoryPutDto categoryDto)
        {
            var category = _context.Categories.FirstOrDefault(x => x.Id == id);
            if (category == null) return NotFound();

            category.Name = categoryDto.Name;
            _context.SaveChanges();

            return NoContent();
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var category = _context.Categories.FirstOrDefault(x => x.Id == id);
            if (category == null) return NotFound();
            _context.Categories.Remove(category);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
