using FluentAssertions;
using LineTen.Api.Requests;
using LineTen.Api.Responses;
using LineTen.Api.Services.Implementation;
using LineTen.Domain.Entities;
using LineTen.Domain.Repositories;
using Moq;

namespace LineTen.Test.ApiTests.ServicesTests
{
    public class ProductServiceTests
    {
        [Fact]
        public async Task testCreateProductAsync_ReturnsValidProductResponseWithNewlyCreatedId_WhenVaildRequestIsProvided()
        {
            // Arrange
            var repositoryMock = new Mock<IProductRepository>();
            var service = new ProductService(repositoryMock.Object);

            var productRequest = new ProductRequest
            {
                Name = "Test",
                Description = "Some description",
                Sku = "Some text"
            };

            repositoryMock
                .Setup(r => r.CreateProductAsync(It.IsAny<Product>()))
                .ReturnsAsync(Product);

            // Act
            var response = await service.CreateProductAsync(productRequest);

            // Assert
            response.Should().NotBeNull().And.BeEquivalentTo(ExpectedResponse);
        }

        [Fact]
        public async Task testGetAllProductsAsync_ReturnsValidListOfProductResponse()
        {
            // Arrange
            var repositoryMock = new Mock<IProductRepository>();
            var service = new ProductService(repositoryMock.Object);

            var expectedResponse = new List<ProductResponse>
            {
                ExpectedResponse
            };

            var Products = new List<Product>
            {
                Product
            };

            repositoryMock
                .Setup(r => r.GetAllProductsAsync())
                .ReturnsAsync(Products);

            // Act
            var response = await service.GetAllProductsAsync();

            // Assert
            response.Should().NotBeNull().And.BeEquivalentTo(expectedResponse);
        }

        [Fact]
        public async Task testGetProductByIdAsync_ReturnsValidProductResponse_WhenVaildIdIsProvided()
        {
            // Arrange
            var repositoryMock = new Mock<IProductRepository>();
            var service = new ProductService(repositoryMock.Object);

            repositoryMock
                .Setup(r => r.GetProductByIdAsync(It.IsAny<int>()))
                .ReturnsAsync(Product);

            // Act
            var response = await service.GetProductByIdAsync(1);

            // Assert
            response.Should().NotBeNull().And.BeEquivalentTo(ExpectedResponse);
        }

        [Fact]
        public async Task testUpdateProductByIdAsync_ReturnsUpdatedProductResponse_WhenVaildIdAndRequestIsProvided()
        {
            // Arrange
            var repositoryMock = new Mock<IProductRepository>();
            var service = new ProductService(repositoryMock.Object);

            var request = new ProductRequest
            {
                Name = "Testing",
                Description = "Some description",
                Sku = "Some text"
            };

            var expectedResponse = new ProductResponse
            {
                Id = 1,
                Name = "Testing",
                Description = "Some description",
                Sku = "Some text"
            };

            var product = new Product
            {
                Id = 1,
                Name = "Testing",
                Description = "Some description",
                Sku = "Some text"
            };

            repositoryMock
                .Setup(r => r.UpdateProductAsync(It.IsAny<int>(), It.IsAny<Product>()))
                .ReturnsAsync(product);

            // Act
            var response = await service.UpdateProductByIdAsync(1, request);

            // Assert
            response.Should().NotBeNull().And.BeEquivalentTo(expectedResponse);
        }

        [Fact]
        public async Task testDeleteProductByIdAsync_DeletesProduct_WhenVaildIdIsProvided()
        {
            // Arrange
            var repositoryMock = new Mock<IProductRepository>();
            var service = new ProductService(repositoryMock.Object);

            repositoryMock
                .Setup(r => r.DeleteProductByIdAsync(It.IsAny<int>()))
                .ReturnsAsync(true);

            // Act
            var response = await service.DeleteProductByIdAsync(1);

            // Assert
            response.Should().BeTrue();
        }

        private static ProductResponse ExpectedResponse => new()
        {
            Id = 1,
            Name = "Test",
            Description = "Some description",
            Sku = "Some text"
        };

        private static Product Product => new()
        {
            Id = 1,
            Name = "Test",
            Description = "Some description",
            Sku = "Some text"
        };
    }
}
