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
        private readonly CustomerRepository _customerRepository = new CustomerRepository();
        private readonly AccountRepository _accountRepository = new AccountRepository();
        private readonly TransactionRepository _transactionRepository = new TransactionRepository();

        public void CreateBank()
        {
            Bank bank = new Bank();
            bank.Name = "Uusi pankki";
            bank.BIC = "4545445454";
            Console.WriteLine("Uusi pankki luotu");
            _bankRepository.Create(bank);
        }

        public void CreateCustomerAccount()
        {
            Customer customer = new Customer();

            customer.BankId = 7;
            customer.Firstname = "Herra";
            customer.Lastname = "Rahamies";
            customer.Account = new List<Account>
            {
                new Account
                {
                    Balance = 505000,
                    Name = "Pienitili",
                    IBAN = "FIPALJONRAHAA",
                    BankId = 7
                }
            };
            _customerRepository.Create(customer);

        }

        internal void ReadCustomerByBankId(long bankId)
        {
            var customers = _customerRepository.ReadAllCustomers();
            if (customers == null)
            {
                Console.WriteLine($"Pankkia ID:llä {bankId} ei löydy");
            }
            else
            {
                Console.WriteLine("Pankin asiakkaat:");
                foreach (var c in customers)
                {
                    if(c.BankId == bankId)
                    {
                        Console.WriteLine($"Asiakas nr. {c.Id}    {c.Firstname} {c.Lastname}");
                    }
                }
            }
        }

        internal void ReadAccountsByBankId(long bankId)
        {
            var accounts = _accountRepository.ReadAllAccounts();
            Console.WriteLine("Pankin tilit:");
            foreach (var a in accounts)
            {
                if(accounts == null)
                {
                    Console.WriteLine("Ei ole tilejä");
                }
                else if(a.BankId == bankId)
                {
                    Console.WriteLine($"Tili: {a.Name}\nBalance: {a.Balance}");
                }
            }          
        }

        internal void ReadTransactionById(long id)
        {
            var transactions = _transactionRepository.ReadTransactions();

            foreach (var t in transactions)
            {
                if(transactions == null)
                {
                    Console.WriteLine("ei löydy");
                }
                else
                {
                    Console.WriteLine($"Määrä: {t.Amount}\nAika: {t.Timestamp}");
                }
            }
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

        public void UpdateBank()
        {
            Bank updateBank = _bankRepository.ReadById(9);
            updateBank.Name = "Pankki123";
            updateBank.BIC = "ASDFGHJKL";
            _bankRepository.Update(9, updateBank);
        }

        public void UpdateCustomer()
        {
            Customer updateCustomer = _customerRepository.ReadById(25);
            updateCustomer.Firstname = "Testi";
            updateCustomer.Lastname = "Homma";
            updateCustomer.BankId = 7;

            _customerRepository.Update(25, updateCustomer);
        }

        public void DeleteCustomer(long id)
        {
            ReadCustomerById(id);
            _customerRepository.Delete(id);
            ReadCustomerById(id);
        }

        public void ReadCustomerById(long id)
        {
            var customer = _customerRepository.ReadById(id);
            if (customer == null)
            {
                Console.WriteLine($"Henkilöä ID:llä {id} ei löydy");
            }
            else
            {
                Console.WriteLine($"Henkilö poistettu tietokannasta ---- {customer.Id}    {customer.Firstname} {customer.Lastname}");
            }
        }

        public void ReadCustomerInfo(long customerId)
        {
            var customer = _customerRepository.ReadById(customerId);
            if (customer == null)
            {
                Console.WriteLine($"Asiakasta kyseisellä ID:llä ei löydy");
            }
            else
            {
                Console.WriteLine($"{customer.Firstname} {customer.Lastname}");
                foreach (var c in customer.Account)
                {
                    Console.WriteLine($"Tili: {c.Name}\tBalance: {c.Balance}");
                }
            }
        }

        public void AddTransaction()
        {
            Transaction transaction = new Transaction();
            transaction.IBAN = "FI112233445566778899";
            transaction.Amount = 99999;
            transaction.Timestamp = DateTime.Now;
            _accountRepository.CreateTransaction(transaction);
            Console.WriteLine("Paina ENTER jatkaaksesi");
        }

        /*public void ReadCustomerByBankId(long id)
        {
            var account = _accountRepository.ReadByBankId(id);
            if (account == null)
            {
                Console.WriteLine("Pankkia ei oo");
            }
            else
            {
                foreach (var a in account.)
                {
                    if(account.Id == id)
                    {
                        Console.WriteLine($"{a.}");
                    }
                }
            }
        }*/
    }
}
