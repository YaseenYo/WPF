using System;
using System.Collections.Generic;
using WpfApplication.Models;

namespace WpfApplication.Services
{
    interface ICustomersRepository
    {
        List<Customer> GetAll();
        bool Add(Customer customer);
        Customer Search(Int64 phoneNumber);
        void Update(Customer customer);
    }
}
