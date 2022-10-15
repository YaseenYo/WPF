using System;

namespace WpfApplication.Models
{
	internal class Customer
    {
		public Guid Id { get; set; }
		public string Name { get; set; }
		public string Address { get; set; }
		public string Bank { get; set; }
		public Int64 Phone { get; set; }
		public string AccountNumber { get; set; }
		public float Credit { get; set; }
	}
}
