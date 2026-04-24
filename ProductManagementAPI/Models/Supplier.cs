using System.Collections.Generic;

namespace ProductManagementAPI.Models
{
	public class Supplier
	{
		public int SupplierId { get; set; }
		public string Name { get; set; }

		// 🔗 ONE SUPPLIER HAS MANY PRODUCTS
		public List<Product> Products { get; set; }
	}
}