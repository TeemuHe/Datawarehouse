using System;
using System.Collections.Generic;
using System.Text;
using BankAppDB.Models;

namespace BankAppDB.Repositories
{
    public interface ITransactionRepository
    {
        //CRUD
        void Create(Transaction transaction);
        List<Transaction> ReadTransactions();
        Transaction ReadById(long id);
        void Update(long id, Transaction transaction);
        void Delete(long id);
    }
}
