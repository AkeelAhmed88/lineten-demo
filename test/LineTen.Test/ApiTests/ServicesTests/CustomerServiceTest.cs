using FluentAssertions;
using LineTen.Api.Requests;
using LineTen.Api.Responses;
using LineTen.Api.Services.Implementation;
using LineTen.Domain.Entities;
using LineTen.Domain.Repositories;
using Moq;

namespace LineTen.Test.ApiTests.ServicesTests
{
    public class CustomerServiceTest
    {
        [Fact]
        public async Task testCreateCustomerAsync_ReturnsValidCustomerResponseWithNewlyCreatedId_WhenVaildRequestIsProvided()
        {
            // Arrange
            var repositoryMock = new Mock<ICustomerRepository>();
            var service = new CustomerService(repositoryMock.Object);

            var customerRequest = new CustomerRequest
            {
                FirstName = "Test",
                LastName = "Test",
                Phone = "07887887878",
                Email = "Test@test.com",
            };

            repositoryMock
                .Setup(r => r.CreateCustomerAsync(It.IsAny<Customer>()))
                .ReturnsAsync(Customer);

            // Act
            var response = await service.CreateCustomerAsync(customerRequest);

            // Assert
            response.Should().NotBeNull().And.BeEquivalentTo(ExpectedResponse);
        }

        [Fact]
        public async Task testGetAllCustomersAsync_ReturnsValidListOfCustomerResponse()
        {
            // Arrange
            var repositoryMock = new Mock<ICustomerRepository>();
            var service = new CustomerService(repositoryMock.Object);

            var expectedResponse = new List<CustomerResponse>
            {
                ExpectedResponse
            };

            var customers = new List<Customer>
            {
                Customer
            };

            repositoryMock
                .Setup(r => r.GetAllCustomersAsync())
                .ReturnsAsync(customers);

            // Act
            var response = await service.GetAllCustomersAsync();

            // Assert
            response.Should().NotBeNull().And.BeEquivalentTo(expectedResponse);
        }

        [Fact]
        public async Task testGetCustomerByIdAsync_ReturnsValidCustomerResponse_WhenVaildIdIsProvided()
        {
            // Arrange
            var repositoryMock = new Mock<ICustomerRepository>();
            var service = new CustomerService(repositoryMock.Object);

            repositoryMock
                .Setup(r => r.GetCustomerByIdAsync(It.IsAny<int>()))
                .ReturnsAsync(Customer);

            // Act
            var response = await service.GetCustomerByIdAsync(1);

            // Assert
            response.Should().NotBeNull().And.BeEquivalentTo(ExpectedResponse);
        }

        [Fact]
        public async Task testUpdateCustomerByIdAsync_ReturnsUpdatedCustomerResponse_WhenVaildIdAndRequestIsProvided()
        {
            // Arrange
            var repositoryMock = new Mock<ICustomerRepository>();
            var service = new CustomerService(repositoryMock.Object);

            var request = new CustomerRequest
            {
                FirstName = "FirstName",
                LastName = "LastName",
                Phone = "07887887090",
                Email = "TestUpdated@test.com",
            };

            var expectedResponse = new CustomerResponse
            {
                Id = 1,
                FirstName = "FirstName",
                LastName = "LastName",
                Phone = "07887887090",
                Email = "TestUpdated@test.com",
            };

            var customer = new Customer
            {
                Id = 1,
                FirstName = "FirstName",
                LastName = "LastName",
                Phone = "07887887090",
                Email = "TestUpdated@test.com",
            };

            repositoryMock
                .Setup(r => r.UpdateCustomerAsync(It.IsAny<int>(), It.IsAny<Customer>()))
                .ReturnsAsync(customer);

            // Act
            var response = await service.UpdateCustomerByIdAsync(1, request);

            // Assert
            response.Should().NotBeNull().And.BeEquivalentTo(expectedResponse);
        }

        [Fact]
        public async Task testDeleteCustomerByIdAsync_DeletesCustomer_WhenVaildIdIsProvided()
        {
            // Arrange
            var repositoryMock = new Mock<ICustomerRepository>();
            var service = new CustomerService(repositoryMock.Object);

            repositoryMock
                .Setup(r => r.DeleteCustomerByIdAsync(It.IsAny<int>()))
                .ReturnsAsync(true);

            // Act
            var response = await service.DeleteCustomerByIdAsync(1);

            // Assert
            response.Should().BeTrue();
        }

        private static CustomerResponse ExpectedResponse => new()
        {
            Id = 1,
            FirstName = "Test",
            LastName = "Test",
            Phone = "07887887878",
            Email = "Test@test.com",
        };

        private static Customer Customer => new()
        {
            Id = 1,
            FirstName = "Test",
            LastName = "Test",
            Phone = "07887887878",
            Email = "Test@test.com",
        };
    }
}
