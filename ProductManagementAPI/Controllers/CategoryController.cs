using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductManagementAPI.Data;
using ProductManagementAPI.Models;

namespace ProductManagementAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CategoryController : ControllerBase
	{
		private readonly ApplicationDbContext _context;

		public CategoryController(ApplicationDbContext context)
		{
			_context = context;
		}

		// GET: api/category
		[HttpGet]
		public async Task<ActionResult<IEnumerable<Category>>> GetCategories()
		{
			return await _context.Categories.ToListAsync();
		}

		// GET: api/category/1
		[HttpGet("{id}")]
		public async Task<ActionResult<Category>> GetCategory(int id)
		{
			var category = await _context.Categories.FindAsync(id);

			if (category == null)
				return NotFound();

			return category;
		}

		// POST: api/category
		[HttpPost]
		public async Task<ActionResult<Category>> CreateCategory(Category category)
		{
			_context.Categories.Add(category);
			await _context.SaveChangesAsync();

			return Ok(category);
		}

		// PUT: api/category/1
		[HttpPut("{id}")]
		public async Task<IActionResult> UpdateCategory(int id, Category category)
		{
			if (id != category.CategoryId)
				return BadRequest();

			_context.Entry(category).State = EntityState.Modified;
			await _context.SaveChangesAsync();

			return Ok();
		}

		// DELETE: api/category/1
		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteCategory(int id)
		{
			var category = await _context.Categories.FindAsync(id);

			if (category == null)
				return NotFound();

			_context.Categories.Remove(category);
			await _context.SaveChangesAsync();

			return Ok();
		}
	}
}