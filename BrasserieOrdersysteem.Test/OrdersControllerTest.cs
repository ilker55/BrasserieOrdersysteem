using BrasserieOrdersysteem.Controllers;
using BrasserieOrdersysteem.DAL.Interfaces;
using BrasserieOrdersysteem.Models;
using Moq;
using System;
using Xunit;

namespace BrasserieOrdersysteem.Test
{
    public class OrdersControllerTest
    {
        [Fact]
        public void GetOrder()
        {
            // Arrange
            var mockRepository = new Mock<IOrderRepository>();
            mockRepository
                .Setup(m => m.GetByID(1))
                .Returns(new Order() { Id = 1 });

            var controller = new OrdersController(mockRepository.Object);

            // Act
            var order = controller.GetOrder(1).Value;

            // Assert
            mockRepository.Verify(r => r.GetByID(1));
            Assert.Equal(1, order.Id);
        }

        [Fact]
        public void GetOrders()
        {
            // Arrange
            var mockRepository = new Mock<IOrderRepository>();
            mockRepository
                .Setup(m => m.GetAll())
                .Returns(new Order[]
                {
                    new() { Id = 1 },
                    new() { Id = 2 },
                    new() { Id = 3 }
                });

            var controller = new OrdersController(mockRepository.Object);

            // Act
            var orders = controller.GetOrders().Value;

            // Assert
            mockRepository.Verify(r => r.GetAll());
            Assert.Equal(1, orders[0].Id);
            Assert.Equal(2, orders[1].Id);
        }

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
            mockRepository.Verify(r => r.Insert(It.IsAny<Order>()));
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
            mockRepository.Verify(r => r.Update(It.IsAny<Order>()));
            mockRepository.Verify(r => r.Save());
        }

        [Fact]
        public void DeleteOrder()
        {
            // Arrange
            var mockRepository = new Mock<IOrderRepository>();
            mockRepository
                .Setup(m => m.Delete(1))
                .Returns(true);

            var controller = new OrdersController(mockRepository.Object);

            // Act
            controller.DeleteOrder(1);

            // Assert
            mockRepository.Verify(r => r.Delete(1));
            mockRepository.Verify(r => r.Save());
        }
    }
}
