using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductManagementAPI.Data;
using ProductManagementAPI.Models;

namespace ProductManagementAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProductController : ControllerBase
	{
		private readonly ApplicationDbContext _context;

		public ProductController(ApplicationDbContext context)
		{
			_context = context;
		}

		// GET: api/product (WITH Category + Supplier)
		[HttpGet]
		public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
		{
			return await _context.Products
				.Include(p => p.Category)
				.Include(p => p.Supplier)
				.ToListAsync();
		}

		// GET: api/product/1
		[HttpGet("{id}")]
		public async Task<ActionResult<Product>> GetProduct(int id)
		{
			var product = await _context.Products
				.Include(p => p.Category)
				.Include(p => p.Supplier)
				.FirstOrDefaultAsync(p => p.ProductId == id);

			if (product == null)
				return NotFound();

			return product;
		}

		// POST: api/product
		[HttpPost]
		public async Task<ActionResult<Product>> CreateProduct(Product product)
		{
			_context.Products.Add(product);
			await _context.SaveChangesAsync();

			return Ok(product);
		}

		// PUT: api/product/1
		[HttpPut("{id}")]
		public async Task<IActionResult> UpdateProduct(int id, Product product)
		{
			if (id != product.ProductId)
				return BadRequest();

			_context.Entry(product).State = EntityState.Modified;
			await _context.SaveChangesAsync();

			return Ok();
		}

		// DELETE: api/product/1
		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteProduct(int id)
		{
			var product = await _context.Products.FindAsync(id);

			if (product == null)
				return NotFound();

			_context.Products.Remove(product);
			await _context.SaveChangesAsync();

			return Ok();
		}
	}
}