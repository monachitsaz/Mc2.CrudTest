using Mc2.CrudTest.Presentation.Server.Application.Controllers;
using Mc2.CrudTest.Presentation.Server.Application.Services;
using Mc2.CrudTest.Shared.Domain;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using Xunit;

namespace Mc2.CrudTest.AcceptanceTests
{
    public class CustomerTest
    {
        Mock<ICustomerService> _mockService = new Mock<ICustomerService>();


        private Customer GetTestCustomer()
        {
 
            return new Customer()
            {       
                BankAccountNumber = "0000-9999-8888-6666",
                DateOfBirth = new DateTime(2023 - 01 - 14),
                Email = "chitsazrmn2@gmail.com",
                FirstName = "mona",
                LastName = "Chitsaz223",
                PhoneNumber = "+989121234567"
            };
        }

        private List<Customer> GetTestAllCustomers()
        {
            return new List<Customer>
            {
                new Customer{
                    BankAccountNumber = "",
                    DateOfBirth = new DateTime(2010, 12, 25),
                    Email = "chitsazmn@gmail.com",
                    FirstName = "mona23",
                    LastName = "Chitsaz",
                    PhoneNumber = "+989121234567"
                },
                new Customer{
                    BankAccountNumber = "",
                    DateOfBirth = new DateTime(2010, 12, 25),
                    Email = "chitsazmn2@gmail.com",
                    FirstName = "mona2",
                    LastName = "Chitsaz2",
                    PhoneNumber = "+989121234567"
                },
                    new Customer{
                    BankAccountNumber = "",
                    DateOfBirth = new DateTime(2010, 12, 25),
                    Email = "chitsazmn3@gmail.com",
                    FirstName = "mona3",
                    LastName = "Chitsaz3",
                    PhoneNumber = "+989121234567"
                },
            };
        }


        [Fact]
        public void Create_CustomerValid_Returns_OkResult()
        {
            // Arrange
             var newCustomer = GetTestCustomer();

            // Act
            var controller = new CustomerController(_mockService.Object);
            var okResult = controller.Create(newCustomer);

            // Assert
            Assert.IsType<OkResult>(okResult);

            //_mockService.Verify();
        }

        [Fact]
        public void Create_CustomerInValid_Returns_BadReuest()
        {
            // Arrange
            var newCustomer = GetTestCustomer();

            // Act
            var controller = new CustomerController(_mockService.Object);
            var badRequest = controller.Create(newCustomer);

            // Assert
            Assert.IsType<BadRequestResult>(badRequest);

        }


        [Fact]
        public void GetAll_WhenCalled_Returns_OkResult()
        {
            // Arrange
            var newCustomerList = GetTestAllCustomers();

            // Act
            var controller = new CustomerController(_mockService.Object);
            var okResult = controller.GetAll() as OkObjectResult;

            // Assert
            Assert.IsType<OkObjectResult>(okResult);

        }

        [Fact]
        public void GetById_UnknownIdPassed_Returns_NotFoundResult()
        {
         
            // Act
            var controller = new CustomerController(_mockService.Object);
            var notFoundResult = controller.GetById(1);

            // Assert
            Assert.IsType<NotFoundResult>(notFoundResult);
        }

        [Fact]
        public void GetById_ExistingIdPassed_Returns_OkResult()
        {       
            // Act
            var controller = new CustomerController(_mockService.Object);
            var okResult = controller.GetById(1);

            // Assert
            Assert.IsType<OkObjectResult>(okResult);

        }


        [Fact]
        public void Remove_IdPassed_Returns_OkResult()
        {
            // Act
            var controller = new CustomerController(_mockService.Object);
            var okResult = controller.Delete(1);

            // Assert
            Assert.IsType<OkResult>(okResult);


        }


    }
}
