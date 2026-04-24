using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductManagementAPI.Data;
using ProductManagementAPI.Models;

namespace ProductManagementAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CustomerController : ControllerBase
	{
		private readonly ApplicationDbContext _context;

		public CustomerController(ApplicationDbContext context)
		{
			_context = context;
		}

		// GET: api/customer
		[HttpGet]
		public async Task<ActionResult<IEnumerable<Customer>>> GetCustomers()
		{
			return await _context.Customers.ToListAsync();
		}

		// GET: api/customer/1
		[HttpGet("{id}")]
		public async Task<ActionResult<Customer>> GetCustomer(int id)
		{
			var customer = await _context.Customers.FindAsync(id);

			if (customer == null)
				return NotFound();

			return customer;
		}

		// POST: api/customer
		[HttpPost]
		public async Task<ActionResult<Customer>> CreateCustomer(Customer customer)
		{
			_context.Customers.Add(customer);
			await _context.SaveChangesAsync();

			return Ok(customer);
		}

		// PUT: api/customer/1
		[HttpPut("{id}")]
		public async Task<IActionResult> UpdateCustomer(int id, Customer customer)
		{
			if (id != customer.CustomerId)
				return BadRequest();

			_context.Entry(customer).State = EntityState.Modified;
			await _context.SaveChangesAsync();

			return Ok();
		}

		// DELETE: api/customer/1
		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteCustomer(int id)
		{
			var customer = await _context.Customers.FindAsync(id);

			if (customer == null)
				return NotFound();

			_context.Customers.Remove(customer);
			await _context.SaveChangesAsync();

			return Ok();
		}
	}
}