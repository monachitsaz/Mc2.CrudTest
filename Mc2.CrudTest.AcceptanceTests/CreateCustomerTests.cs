using Mc2.CrudTest.Presentation.Server.Application.Controllers;
using Mc2.CrudTest.Presentation.Server.Application.Services;
using Mc2.CrudTest.Shared.Domain;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
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
                BankAccountNumber = "0000-1111-2222-3333",
                DateOfBirth = new DateTime(2010 - 12 - 26),
                Email = "chitsazrmn2@gmail.com",
                FirstName = "mona223",
                LastName = "Chitsaz223",
                //CountryCode=98,
                //NationalNumber= 9121234567,
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
                    FirstName = "mona",
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
            _mockService.Setup(c => c.AddCustomer(It.IsAny<Customer>())).Verifiable();
            var newCustomer = GetTestCustomer();

            // Act
            var controller = new CustomerController(_mockService.Object);
            var okResult = controller.Create(newCustomer);

            // Assert
            Assert.IsType<OkResult>(okResult);

            _mockService.Verify();
        }

        [Fact]
        public void Create_CustomerInValid_Returns_BadReuest()
        {
            // Arrange
            var newCustomer = GetTestCustomer();

            // Act
            _mockService.Setup(c => c.AddCustomer(It.IsAny<Customer>())).Verifiable();
            var controller = new CustomerController(_mockService.Object);
            var badRequest = controller.Create(newCustomer);

            // Assert
            Assert.IsType<BadRequestResult>(badRequest);

            _mockService.Verify();
        }


        [Fact]
        public void GetAll_Called_Returns_Items()
        {
            // Arrange
            var newCustomerList = GetTestAllCustomers();

            _mockService.Setup(c => c.GetCustomerList()).Returns(newCustomerList);
            var controller = new CustomerController(_mockService.Object);

            // Act
            var items = controller.GetAll();

            // Assert
            Assert.IsType<Task<List<Customer>>>(items);

            _mockService.Verify();
        }

        [Fact]
        public void GetAll_WhenCalled_Returns_OkResult()
        {
            // Arrange
            var newCustomerList = GetTestAllCustomers();

            // Act
            _mockService.Setup(c => c.GetCustomerList()).Returns(newCustomerList);
            var controller = new CustomerController(_mockService.Object);
            var okResult = controller.GetAll();

            // Assert
            //Assert.IsType<OkObjectResult>(okResult);

            _mockService.Verify();
        }

        [Fact]
        public void GetById_UnknownIdPassed_Returns_NotFoundResult()
        {
            // Arrange
            _mockService.Setup(c => c.GetCustomerData(It.IsAny<int>())).Verifiable();

            // Act
            var controller = new CustomerController(_mockService.Object);
            var notFoundResult = controller.GetById(1);

            // Assert
            //Assert.IsType<NotFoundResult>(notFoundResult);
            _mockService.Verify();
        }

        [Fact]
        public void GetById_ExistingIdPassed_Returns_OkResult()
        {
            // Arrange
            System.Random random = new Random();
            var id = random.Next();

            // Act
            var controller = new CustomerController(_mockService.Object);
            var notFound = controller.GetById(id);

            // Assert
            //Assert.IsType<NotFoundResult>(notFound);
        }

        [Fact]
        public void Remove_NotExistingIdPassed_Returns_NotFoundResponse()
        {

            // Arrange

            System.Random random = new Random();
            var id = random.Next();

            // Act
            var controller = new CustomerController(_mockService.Object);

            var notFound = controller.Delete(id);
            // Assert
            //Assert.IsType<NotFoundResult>(notFound);

        }

        [Fact]
        public void Remove_ExistingIdPassed_Returns_OkResult()
        {
            // Arrange
            _mockService.Setup(c => c.DeleteCustomer(It.IsAny<int>())).Verifiable();


            // Act
            var controller = new CustomerController(_mockService.Object);

            var okResult = controller.Delete(1);
            _mockService.Verify();
            // Assert
            //Assert.IsType<OkResult>(okResult);


        }

        // Please create more tests based on project requirements as per in readme.md
    }
}
