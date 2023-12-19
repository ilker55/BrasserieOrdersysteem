using BrasserieOrdersysteem.Controllers;
using BrasserieOrdersysteem.DAL.Interfaces;
using BrasserieOrdersysteem.Models;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace BrasserieOrdersysteem.Test
{
    public class ProductsControllerTest
    {
        [Fact]
        public void GetProduct()
        {
            // Arrange
            var mockRepository = new Mock<IProductRepository>();
            mockRepository
                .Setup(m => m.GetByID(1))
                .Returns(new Product("Moules Frites", 16.99m) { Id = 1 });

            var controller = new ProductsController(mockRepository.Object);

            // Act
            var product = controller.GetProduct(1).Value;

            // Assert
            mockRepository.Verify(r => r.GetByID(1));
            Assert.Equal("Moules Frites", product.Name);
        }

        [Fact]
        public void GetProducts()
        {
            // Arrange
            var mockRepository = new Mock<IProductRepository>();
            mockRepository
                .Setup(m => m.GetAll())
                .Returns(new Product[]
                {
                    new ("Moules Frites", 16.99m) { Id = 1 },
                    new ("Quiche Lorraine", 14.99m) { Id = 2 },
                    new ("Bouillabaisse", 22.99m) { Id = 3 }
                });

            var controller = new ProductsController(mockRepository.Object);

            // Act
            var products = controller.GetProducts().Value;

            // Assert
            mockRepository.Verify(r => r.GetAll());
            Assert.Equal("Moules Frites", products.First()?.Name);
            Assert.Equal("Bouillabaisse", products.Last()?.Name);
        }
    }
}
