using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BankAppDB.Models;
using Microsoft.EntityFrameworkCore;

namespace BankAppDB.Repositories
{
    class BankRepository : IBankRepository
    {
        private readonly BankdbContext _bankdbContext = new BankdbContext();
        public void Create(Bank bank)
        {
            _bankdbContext.Bank.Add(bank);
            _bankdbContext.SaveChanges();
        }

        public void Delete(long id)
        {
            //DELETE * FROM PERSON WHERE ID={id}
            var deletedBank = ReadById(id);
            if(deletedBank != null)
            {
                _bankdbContext.Bank.Remove(deletedBank);
                _bankdbContext.SaveChanges();
                Console.WriteLine("Haluttu pankki poistettu");
            }
            else
            {
                Console.WriteLine("Poistaminen epäonnistui - ID tuntematon");
            }
        }

        public Bank ReadById(long id)
        {
            var bank = _bankdbContext.Bank
                .Include(b => b.Account)
                .Where(b => b.Id == id)
                .FirstOrDefault();
            return bank;
        }

        public void Update(long id, Bank bank)
        {
            throw new NotImplementedException();
        }
    }
}
