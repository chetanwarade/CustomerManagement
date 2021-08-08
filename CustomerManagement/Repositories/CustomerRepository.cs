using CustomerManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CustomerManagement.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        List<Customer> _customer = new List<Customer>
            {
                new Customer{ ID =1, FirstName="Teri", LastName="Grater", Email="Teri@nomail.com",PhoneNumber="2132521234"},
                new Customer{ ID =2, FirstName="Anne", LastName="Yew", Email="Anne@nomail.com",PhoneNumber="2132529874"}
            };
        public void Add(Customer customer)
        {
            _customer.Add(customer);
        }

        public void Delete(int customerID)
        {
            _customer.Remove(_customer.FirstOrDefault(c=>c.ID == customerID));
        }

        public IEnumerable<Customer> GetCustomers()
        {
            return _customer;
        }

        public Customer GetCustomers(int customerID)
        {
            return _customer.FirstOrDefault(c=>c.ID == customerID);
        }

        public void Update(Customer customer)
        {
            var existingCustomer = _customer.FirstOrDefault(c => c.ID == customer.ID);
            if (existingCustomer != null)
            {
                _customer[_customer.FindIndex(c => c.ID == customer.ID)] = customer;
            }
            
        }
    }
}