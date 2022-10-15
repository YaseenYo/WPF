using System;
using System.Collections.Generic;

namespace WpfApplication.Models
{
    internal class Transaction
    {
        public Guid Id { get; set; }
        public Customer Customer { get; set; }
        public List<Product> Products { get; set; }
        public float ProductsAmount
        {
            get
            {
                float amount = 0;
                foreach (var item in Products)
                {
                    amount += item.Price;
                }
                return amount;
            }
        }
        public float CreditUsed { get; set; }
        public float TotalAmount
        { 
            get
            {
                return ProductsAmount - CreditUsed;
            }
        }
    }
}
