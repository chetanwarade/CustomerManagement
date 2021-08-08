using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using CustomerManagement.Controllers;
using CustomerManagement.Models;
using CustomerManagement.Repositories;
using Moq;
using System.Net.Http;
using System.Collections.Generic;
using System.Net;
using System.Web.Http.Results;

namespace CustomerManagement.Tests
{
    [TestClass]
    public class CustomersControllerTests
    {
        private CustomersController _customersController;
        private Mock<ICustomerRepository> _mockCustomerRepository;

        [TestInitialize]
        public void TestInitialize()
        {
            _mockCustomerRepository = new Mock<ICustomerRepository>();
            _customersController = new CustomersController(_mockCustomerRepository.Object);
        }
        [TestMethod]
        public void Put_InvalidIDToUpdate_ShouldReturnNotFound()
        {
            // Arrange
            var customer = new Customer { ID = 103, FirstName = "Anne", LastName = "Yew", Email = "Anne@nomail.com", PhoneNumber = "2132529874" };
            _mockCustomerRepository.Setup(r => r.GetCustomers(It.IsAny<int>()))
                           .Returns((Customer)null);

            //Act
            var result = _customersController.Put(customer);

            //Assert
            Assert.IsInstanceOfType(result, typeof(NotFoundResult));
        }
        [TestMethod]
        public void Put_ValidIDToUpdate_ShouldReturnOkResult()
        {
            // Arrange
            var customer = new Customer { ID = 103, FirstName = "Anne", LastName = "Yew", Email = "Anne@nomail.com", PhoneNumber = "2132529874" };
            _mockCustomerRepository.Setup(r => r.GetCustomers(103))
                           .Returns(new Customer { ID = 103, FirstName = "Anne", LastName = "Yew", Email = "Anne.Yew@nomail.com", PhoneNumber = "2132529874" });

            //Act
            var result = _customersController.Put(customer);

            //Assert
            Assert.IsInstanceOfType(result, typeof(OkResult));
        }
    }
}
