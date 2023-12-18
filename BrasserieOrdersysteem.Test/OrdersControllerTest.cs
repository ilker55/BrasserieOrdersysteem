using BrasserieOrdersysteem.Controllers;
using BrasserieOrdersysteem.DAL;
using BrasserieOrdersysteem.Models;
using Moq;
using System;
using Xunit;

namespace BrasserieOrdersysteem.Test
{
    public class OrdersControllerTest
    {
        [Fact]
        public void CreateOrder()
        {
            // Arrange
            var mockRepository = new Mock<IOrderRepository>();
            var controller = new OrdersController(mockRepository.Object);

            // Act
            controller.CreateOrder(new()
            {
                Id = 1,
                OrderAt = DateTime.Now,
                CustomerId = 1
            });

            // Assert
            mockRepository.Verify(r => r.AddOrder(It.IsAny<Order>()));
            mockRepository.Verify(r => r.Save());
        }

        [Fact]
        public void UpdateOrder()
        {
            // Arrange
            var mockRepository = new Mock<IOrderRepository>();
            var controller = new OrdersController(mockRepository.Object);

            // Act
            controller.UpdateOrder(1, new Order
            {
                Id = 1,
                OrderAt = DateTime.Now,
                CustomerId = 1
            });

            // Assert
            mockRepository.Verify(r => r.UpdateOrder(It.IsAny<Order>()));
            mockRepository.Verify(r => r.Save());
        }

        [Fact]
        public void DeleteOrder()
        {
            // Arrange
            var mockRepository = new Mock<IOrderRepository>();
            mockRepository
                .Setup(m => m.DeleteOrder(1))
                .Returns(true);

            var controller = new OrdersController(mockRepository.Object);

            // Act
            controller.DeleteOrder(1);

            // Assert
            mockRepository.Verify(r => r.DeleteOrder(1));
            mockRepository.Verify(r => r.Save());
        }
    }
}
