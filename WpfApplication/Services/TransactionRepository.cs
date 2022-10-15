using System;
using System.Collections.Generic;
using System.Linq;
using WpfApplication.Models;

namespace WpfApplication.Services
{
    internal class TransactionRepository : ITransactionRepository
    {
        private static readonly List<Transaction> _transactions;

        static TransactionRepository() {
            _transactions = new List<Transaction>()
            {
                new Transaction()
                {
                    Id = new Guid("7bbbf3da-3a62-428d-962d-d9cd66ed1967"),
                    Customer = new Customer()
                    {
                        Id = Guid.NewGuid(),
                        Name = "Muiz",
                        Address = "Mysore, India",
                        Phone = 8686798769,
                        Bank = "Bank Of Baroda",
                        AccountNumber = "BOB093454932",
                        Credit = 600
                    },
                    Products = new List<Product>()
                    {
                        new Product()
                        {
                            Id = Guid.NewGuid(),
                            Name = "Cricket Game 2022",
                            Category = Category.Games,
                            Price = 4000
                        },
                        new Product()
                        {
                            Id = Guid.NewGuid(),
                            Name = "GTA",
                            Category = Category.Games,
                            Price = 6000
                        }
                    },
                    CreditUsed = 200
                },
                new Transaction()
                {
                    Id = new Guid("a0ebfa6a-d531-434d-af33-84a2dd48b8ca"),
                    Customer = new Customer()
                    {
                        Id = Guid.NewGuid(),
                        Name = "Kaif",
                        Address = "Mysore, India",
                        Phone = 8686709769,
                        Bank = "Bank Of Baroda",
                        AccountNumber = "BOB093454932",
                        Credit = 0
                    },
                    Products = new List<Product>()
                    {
                        new Product()
                        {
                            Id = Guid.NewGuid(),
                            Name = "IPhone 13 Pro",
                            Category = Category.Phone,
                            Price = 80000
                        },
                        new Product()
                        {
                            Id = Guid.NewGuid(),
                            Name = "Realme Pad x",
                            Category = Category.Tablet,
                            Price = 19000
                        }
                    },
                    CreditUsed = 1000
                }
            };
        }
        public bool Add(Transaction transaction)
        {
            _transactions.Add(transaction);
            return true;
        }

        public List<Transaction> GetAll()
        {
            return _transactions;
        }

        public Transaction Search(Guid id)
        {
            return _transactions.FirstOrDefault(t => t.Id == id);
        }
    }
}
