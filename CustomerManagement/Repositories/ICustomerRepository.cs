using CustomerManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CustomerManagement.Repositories
{
    public interface ICustomerRepository
    {
        IEnumerable<Customer> GetCustomers();
        Customer GetCustomers(int customerID);
        void Add(Customer customer);
        void Update(Customer customer);
        void Delete(int customerID);
    }
}