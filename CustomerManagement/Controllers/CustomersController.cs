using CustomerManagement.Models;
using CustomerManagement.Repositories;
using System.Collections.Generic;
using System.Web.Http;

namespace CustomerManagement.Controllers
{
    public class CustomersController : ApiController
    {
        private ICustomerRepository _customerRepository;
        public CustomersController(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }
        public IEnumerable<Customer> Get()
        {
            return _customerRepository.GetCustomers();
        }
        public Customer Get(int id)
        {
            return _customerRepository.GetCustomers(id);
        }
        public IHttpActionResult Post(Customer customer)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            _customerRepository.Add(customer);
            return Ok();
        }
        public IHttpActionResult Put(Customer customer)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var exisingCustomer = _customerRepository.GetCustomers(customer.ID);
            if (exisingCustomer == null)
                return NotFound();

            _customerRepository.Update(customer);

            return Ok();
        }
        public IHttpActionResult Delete(int id)
        {
            var customer = _customerRepository.GetCustomers(id);
            if (customer == null)
                return NotFound();

            _customerRepository.Delete(id);

            return Ok();
        }
    }
}
