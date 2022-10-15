using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApplication.Models;

namespace WpfApplication.Services
{
    interface ITransactionRepository
    {
        List<Transaction> GetAll();
        bool Add(Transaction customer);
        Transaction Search(Guid id);
    }
}
