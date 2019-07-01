using System;
using System.Collections.Generic;
using System.Text;
using BankAppDB.Models;

namespace BankAppDB.Repositories
{
    public interface IAccountRepository
    {
        //CRUD
        void Create(Account account);
        Account ReadById(long id);
        List<Account> ReadAllAccounts();
        void Update(long id, Account account);
        void Delete(long id);
    }
}
