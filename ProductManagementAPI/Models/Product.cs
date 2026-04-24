namespace ProductManagementAPI.Models
{
	public class Product
	{
		public int ProductId { get; set; }

		public string Name { get; set; }

		public decimal Price { get; set; }

		// 🔗 FOREIGN KEYS (RELATIONSHIPS)
		public int CategoryId { get; set; }
		public int SupplierId { get; set; }

		// 🔗 NAVIGATION PROPERTIES
		public Category Category { get; set; }
		public Supplier Supplier { get; set; }
	}
}