using FluentAssertions;
using LineTen.Api.Requests;
using LineTen.Api.Responses;
using LineTen.Api.Services.Implementation;
using LineTen.Domain.Entities;
using LineTen.Domain.Repositories;
using Moq;

namespace LineTen.Test.ApiTests.ServicesTests
{
    public class OrderServiceTests
    {
        private static readonly DateTime CreatedDatetime = DateTime.Today.AddDays(-1);
        private static readonly DateTime UpdatedDatetime = DateTime.Today;

        [Fact]
        public async Task testCreateOrderAsync_ReturnsValidOrderResponseWithNewlyCreatedId_WhenVaildRequestIsProvided()
        {
            // Arrange
            var repositoryMock = new Mock<IOrderRepository>();
            var service = new OrderService(repositoryMock.Object);

            var orderRequest = new OrderCreateRequest
            {
                ProductId = 1,
                CustomerId = 1,
            };

            repositoryMock
                .Setup(r => r.CreateOrderAsync(It.IsAny<Order>()))
                .ReturnsAsync(Order);

            // Act
            var response = await service.CreateOrderAsync(orderRequest);

            // Assert
            response.Should().NotBeNull().And.BeEquivalentTo(ExpectedResponse);
        }

        [Fact]
        public async Task testGetAllOrdersAsync_ReturnsValidListOfOrderResponse()
        {
            // Arrange
            var repositoryMock = new Mock<IOrderRepository>();
            var service = new OrderService(repositoryMock.Object);

            var expectedResponse = new List<OrderResponse>
            {
                ExpectedResponse
            };

            var Orders = new List<Order>
            {
                Order
            };

            repositoryMock
                .Setup(r => r.GetAllOrdersAsync())
                .ReturnsAsync(Orders);

            // Act
            var response = await service.GetAllOrdersAsync();

            // Assert
            response.Should().NotBeNull().And.BeEquivalentTo(expectedResponse);
        }

        [Fact]
        public async Task testGetOrderByIdAsync_ReturnsValidOrderResponse_WhenVaildIdIsProvided()
        {
            // Arrange
            var repositoryMock = new Mock<IOrderRepository>();
            var service = new OrderService(repositoryMock.Object);

            repositoryMock
                .Setup(r => r.GetOrderByIdAsync(It.IsAny<int>()))
                .ReturnsAsync(Order);

            // Act
            var response = await service.GetOrderByIdAsync(1);

            // Assert
            response.Should().NotBeNull().And.BeEquivalentTo(ExpectedResponse);
        }

        [Fact]
        public async Task testUpdateOrderByIdAsync_ReturnsUpdatedOrderResponse_WhenVaildIdAndRequestIsProvided()
        {
            // Arrange
            var repositoryMock = new Mock<IOrderRepository>();
            var service = new OrderService(repositoryMock.Object);

            var request = new OrderUpdateRequest
            {
                ProductId = 1,
                CustomerId = 1,
                Status = "Cancelled"
            };

            var expectedResponse = new OrderResponse
            {
                Id = 1,
                Product = new ProductResponse
                {
                    Id = 1,
                    Name = "test",
                    Description = "test",
                    Sku = "test"
                },
                Customer = new CustomerResponse
                {
                    Id = 1,
                    FirstName = "test",
                    LastName = "test",
                    Phone = "07887887878",
                    Email = "test@test.com"
                },
                Status = "Cancelled",
                CreatedDate = CreatedDatetime,
                UpdatedDate = UpdatedDatetime
            };

            var order = new Order
            {
                Id = 1,
                ProductId = 1,
                Product = new Product
                {
                    Id = 1,
                    Name = "test",
                    Description = "test",
                    Sku = "test"
                },
                CustomerId = 1,
                Customer = new Customer
                {
                    Id = 1,
                    FirstName = "test",
                    LastName = "test",
                    Phone = "07887887878",
                    Email = "test@test.com"
                },
                Status = "Cancelled",
                CreatedDate = CreatedDatetime,
                UpdatedDate = UpdatedDatetime
            };

            repositoryMock
                .Setup(r => r.UpdateOrderAsync(It.IsAny<int>(), It.IsAny<Order>()))
                .ReturnsAsync(order);

            // Act
            var response = await service.UpdateOrderByIdAsync(1, request);

            // Assert
            response.Should().NotBeNull().And.BeEquivalentTo(expectedResponse);
        }

        [Fact]
        public async Task testDeleteOrderByIdAsync_DeletesOrder_WhenVaildIdIsProvided()
        {
            // Arrange
            var repositoryMock = new Mock<IOrderRepository>();
            var service = new OrderService(repositoryMock.Object);

            repositoryMock
                .Setup(r => r.DeleteOrderByIdAsync(It.IsAny<int>()))
                .ReturnsAsync(true);

            // Act
            var response = await service.DeleteOrderByIdAsync(1);

            // Assert
            response.Should().BeTrue();
        }

        private static OrderResponse ExpectedResponse => new()
        {
            Id = 1,
            Product = new ProductResponse
            {
                Id = 1,
                Name = "test",
                Description = "test",
                Sku = "test"
            },
            Customer = new CustomerResponse
            {
                Id = 1,
                FirstName = "test",
                LastName = "test",
                Phone = "07887887878",
                Email = "test@test.com"
            },
            Status = "Created",
            CreatedDate = CreatedDatetime
        };

        private static Order Order => new()
        {
            Id = 1,
            ProductId = 1,
            Product = new Product
            {
                Id = 1,
                Name = "test",
                Description = "test",
                Sku = "test"
            },
            CustomerId = 1,
            Customer = new Customer
            {
                Id = 1,
                FirstName = "test",
                LastName = "test",
                Phone = "07887887878",
                Email = "test@test.com"
            },
            Status = "Created",
            CreatedDate = CreatedDatetime
        };
    }
}
