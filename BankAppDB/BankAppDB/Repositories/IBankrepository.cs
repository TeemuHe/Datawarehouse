using System;
using System.Collections.Generic;
using System.Text;
using BankAppDB.Models;

namespace BankAppDB.Repositories
{
    public interface IBankRepository
    {
        //CRUD
        void Create(Bank bank);
        Bank ReadById(long id);
        void Update(long id, Bank bank);
        void Delete(long id);

    }
}
