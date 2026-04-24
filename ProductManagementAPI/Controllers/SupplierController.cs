using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductManagementAPI.Data;
using ProductManagementAPI.Models;

namespace ProductManagementAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class SupplierController : ControllerBase
	{
		private readonly ApplicationDbContext _context;

		public SupplierController(ApplicationDbContext context)
		{
			_context = context;
		}

		// GET: api/supplier
		[HttpGet]
		public async Task<ActionResult<IEnumerable<Supplier>>> GetSuppliers()
		{
			return await _context.Suppliers.ToListAsync();
		}

		// GET: api/supplier/1
		[HttpGet("{id}")]
		public async Task<ActionResult<Supplier>> GetSupplier(int id)
		{
			var supplier = await _context.Suppliers.FindAsync(id);

			if (supplier == null)
				return NotFound();

			return supplier;
		}

		// POST: api/supplier
		[HttpPost]
		public async Task<ActionResult<Supplier>> CreateSupplier(Supplier supplier)
		{
			_context.Suppliers.Add(supplier);
			await _context.SaveChangesAsync();

			return Ok(supplier);
		}

		// PUT: api/supplier/1
		[HttpPut("{id}")]
		public async Task<IActionResult> UpdateSupplier(int id, Supplier supplier)
		{
			if (id != supplier.SupplierId)
				return BadRequest();

			_context.Entry(supplier).State = EntityState.Modified;
			await _context.SaveChangesAsync();

			return Ok();
		}

		// DELETE: api/supplier/1
		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteSupplier(int id)
		{
			var supplier = await _context.Suppliers.FindAsync(id);

			if (supplier == null)
				return NotFound();

			_context.Suppliers.Remove(supplier);
			await _context.SaveChangesAsync();

			return Ok();
		}
	}
}