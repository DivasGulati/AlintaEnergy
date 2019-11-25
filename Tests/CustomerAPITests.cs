using AlintaEnergy.Application.Abstractions.Services;
using AlintaEnergy.Application.Dto;
using AlintaEnergy.IntergrationTests;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Customer.Tests
{
    [TestClass]
    public class CustomerAPITests : BaseTest
    {
        [TestMethod]
        public void CUSTOMER_API_ADD_NEW_CUSTOMER_ID_123_FIRSTNAME_SMITH_LASTNAME_JOHN()
        {
            //Arrange
            var customerService = _serviceProvider.GetService<ICustomerService>();
            var customers = (customerService.GetAllCustomer()).ToList();
            int intialCount = customers.Count;
                  
            var customerDto = new CustomerDto()
            {
                Id = 123,
                FirstName = "SMITH",
                LastName = "JOHN",
                DateOfBirth = new DateTime(1986, 1, 1)
            };

            ///Act
            customerService.CreateCustomer(customerDto);

            customers = (customerService.GetAllCustomer()).ToList();
            var customer = customerService.GetCustomer(123);

            //Assert
            Assert.AreEqual<int>(customers.Count, intialCount + 1);
            Assert.AreEqual<string>(customer.FirstName, "SMITH");
            Assert.AreEqual<string>(customer.LastName, "JOHN");
            Assert.AreEqual<DateTime>(customer.DateOfBirth, new DateTime(1986, 1, 1));
        }


        [TestMethod]
        public void CUSTOMER_API_REMOVECUSTOMER_FIRSTNAME_JOHN_LASTNAME_MARTIN()
        {
            //Arrange
            var mapper = _serviceProvider.GetService<IMapper>();
            var customerService = _serviceProvider.GetService<ICustomerService>();
            var customers = (customerService.GetAllCustomer()).ToList();
            int intialCount = customers.Count;

            var customerDto = new CustomerDto()
            {
                Id = 1,
                FirstName = "John",
                LastName = "Martin",
                DateOfBirth = new DateTime(1975, 1, 1)
            };

            ///Act
            var customerBeforeDeleting = customerService.GetCustomer(customerDto.Id.Value);
            customerService.RemoveCustomer(customerDto.Id.Value);

            customers = (customerService.GetAllCustomer()).ToList();
            var customer = customerService.GetCustomer(customerDto.Id.Value);

            //Assert
            Assert.AreEqual<int>(customers.Count, intialCount - 1);
            Assert.AreNotEqual<CustomerDto>(customerBeforeDeleting, null);
            Assert.AreEqual<string>(customerBeforeDeleting.FirstName, "John");
            Assert.AreEqual<CustomerDto>(customer, null);           
        }
    }
}
