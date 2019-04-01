using System;
using System.Collections.Generic;
using System.Text;
using BankAppDB.Models;
using BankAppDB.Repositories;

namespace BankAppDB.Views
{
    class UIModels
    {
        private readonly BankRepository _bankRepository = new BankRepository();
        public void CreateBank()
        {
            Bank bank = new Bank();
            bank.Name = "Uusi pankki";
            bank.BIC = "4545445454";
            Console.WriteLine("Uusi pankki luotu");
            _bankRepository.Create(bank);
        }

        public void DeleteBank(long id)
        {
            ReadBankById(id);
            _bankRepository.Delete(id);
            ReadBankById(id);
        }

        public void ReadBankById(long id)
        {
            var bank = _bankRepository.ReadById(id);
            if (bank == null)
            {
                Console.WriteLine($"Pankki numerolla {id} ei löydy");
            }
            else
            {
                Console.WriteLine($"{bank.Id}   {bank.Name}");
            }
        }
    }
}
