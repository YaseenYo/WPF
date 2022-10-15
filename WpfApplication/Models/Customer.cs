using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
