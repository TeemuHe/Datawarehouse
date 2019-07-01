using System;
using System.Collections.Generic;
using System.Text;
using BankAppDB.Models;

namespace BankAppDB.Repositories
{
    public interface ICustomerRepository
    {
        //CRUD
        Customer Create(Customer customer);
        Customer ReadById(long id);
        List<Customer> ReadAllCustomers();
        void Update(long id, Customer customer);
        void Delete(long id);
    }
}
