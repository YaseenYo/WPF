using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApplication.Models;

namespace WpfApplication.Services
{
    internal class CustomersRepository : ICustomersRepository
    {
        private static readonly List<Customer> _customers;

        static CustomersRepository()
        {
            _customers = new List<Customer>()
            {
                new Customer() 
                {
                    Id = Guid.NewGuid(),
                    Name = "Yaseen",
                    Address = "Bangalore, India",
                    Bank = "National Bank",
                    Phone = 9873728992,
                    AccountNumber = "NBOF023432532",
                    Credit = 300
                },
                new Customer()
                {
                    Id = Guid.NewGuid(),
                    Name = "Maaz",
                    Address = "Mumbai, India",
                    Phone = 9098972890,
                    Bank = "National Bank",
                    AccountNumber = "NBOF023439809",
                    Credit = 470
                },
                new Customer()
                {
                    Id = Guid.NewGuid(),
                    Name = "Muiz",
                    Address = "Mysore, India",
                    Phone = 8686798769,
                    Bank = "Bank Of Baroda",
                    AccountNumber = "BOB093454932",
                    Credit = 600
                },
                new Customer()
                {
                    Id = Guid.NewGuid(),
                    Name = "Faizan",
                    Address = "Delhi, India",
                    Phone = 6763425760,
                    Bank = "Karnataka Bank",
                    AccountNumber = "KB3980787621",
                    Credit = 0
                }
            };
        }

        public bool Add(Customer customer)
        {
            _customers.Add(customer);
            return true;
        }

        public List<Customer> GetAll()
        {
            return _customers;
        }

        public Customer Search(Int64 phoneNumber)
        {
            return _customers.FirstOrDefault(c => c.Phone == phoneNumber);
        }

        public void Update(Customer customer)
        {
            for(int i = 0; i < _customers.Count; i++)
            {
                if (_customers[i].Phone == customer.Phone)
                {
                    _customers[i] = customer;
                    break;
                }
            }
        }
    }
}
