using BrasserieOrdersysteem.Controllers;
using BrasserieOrdersysteem.DAL.Interfaces;
using BrasserieOrdersysteem.Models;
using Moq;
using Xunit;

namespace BrasserieOrdersysteem.Test
{
    public class CustomersControllerTest
    {
        [Fact]
        public void GetCustomer()
        {
            // Arrange
            var mockRepository = new Mock<ICustomerRepository>();
            mockRepository
                .Setup(m => m.GetByID(1))
                .Returns(new Customer("Elena Martinez") { Id = 1 });

            var controller = new CustomersController(mockRepository.Object);

            // Act
            var customer = controller.GetCustomer(1).Value;

            // Assert
            mockRepository.Verify(r => r.GetByID(1));
            Assert.Equal("Elena Martinez", customer.Name);
        }

        [Fact]
        public void GetCustomers()
        {
            // Arrange
            var mockRepository = new Mock<ICustomerRepository>();
            mockRepository
                .Setup(m => m.GetAll())
                .Returns(new Customer[]
                {
                    new("Elena Martinez") { Id = 1 },
                    new("Jonathan Turner") { Id = 2 },
                    new("Sophie Anderson") { Id = 3 }
                });

            var controller = new CustomersController(mockRepository.Object);

            // Act
            var customers = controller.GetCustomers().Value;

            // Assert
            mockRepository.Verify(r => r.GetAll());
            Assert.Equal("Elena Martinez", customers[0].Name);
            Assert.Equal("Jonathan Turner", customers[1].Name);
        }

        [Fact]
        public void CreateCustomer()
        {
            // Arrange
            var mockRepository = new Mock<ICustomerRepository>();
            var controller = new CustomersController(mockRepository.Object);

            // Act
            controller.CreateCustomer(new Customer("Sophie Anderson") { Id = 1 });

            // Assert
            mockRepository.Verify(r => r.Insert(It.IsAny<Customer>()));
            mockRepository.Verify(r => r.Save());
        }

        [Fact]
        public void UpdateCustomer()
        {
            // Arrange
            var mockRepository = new Mock<ICustomerRepository>();
            var controller = new CustomersController(mockRepository.Object);

            // Act
            controller.UpdateCustomer(1, new Customer("Elena Martinez") { Id = 1 });

            // Assert
            mockRepository.Verify(r => r.Update(It.IsAny<Customer>()));
            mockRepository.Verify(r => r.Save());
        }

        [Fact]
        public void DeleteCustomer()
        {
            // Arrange
            var mockRepository = new Mock<ICustomerRepository>();
            mockRepository
                .Setup(m => m.Delete(1))
                .Returns(true);

            var controller = new CustomersController(mockRepository.Object);

            // Act
            controller.DeleteCustomer(1);

            // Assert
            mockRepository.Verify(r => r.Delete(1));
            mockRepository.Verify(r => r.Save());
        }
    }
}
