using System.Collections.Generic;

namespace ProductManagementAPI.Models
{
	public class Category
	{
		public int CategoryId { get; set; }
		public string Name { get; set; }

		// 🔗 ONE CATEGORY HAS MANY PRODUCTS
		public List<Product> Products { get; set; }
	}
}