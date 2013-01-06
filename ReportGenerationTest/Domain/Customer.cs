using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReportGenerationTest.Domain
{
	public class CustomerRepository
	{
		public Customer GetCustomer()
		{
			var customer = new Customer()
				{
					Name = "Joe"
				};
			
			customer.Products.Add(new Product
				{
					ProductName = "Awesome Product",
					ProductID = 1
				});

			customer.Products.Add(new Product
				{
					ProductName = "Not so Awesome Product",
					ProductID = 2
				});
			return customer;
		}
	}

	public class CustomerModel
	{
		public string Name { get; set; }
		public int ProductCount { get; set; }
	}

	public class Customer
	{
		public Customer()
		{
			Products = new List<Product>();
		}

		public string Name { get; set; }
		public List<Product> Products { get; set; }

		public Array GetProducts()
		{
			return Products.ToArray();
		}
	}

	public class Product
	{
		public string ProductName { get; set; }
		public int ProductID { get; set; }
	}
}
