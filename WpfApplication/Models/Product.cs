using System;

namespace WpfApplication.Models
{
    internal class Product
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
        public Category Category { get; set; }
    }

    public enum Category
    {
        Games,
        Phone,
        Tablet
    }
}
