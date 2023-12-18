using BrasserieOrdersysteem.Controllers;
using BrasserieOrdersysteem.DAL;
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
                .Setup(m => m.GetCustomerByID(1))
                .Returns(new Customer
                {
                    Id = 1,
                    Name = "Elena Martinez"
                });

            var controller = new CustomersController(mockRepository.Object);

            // Act
            var customer = controller.GetCustomer(1).Value;

            // Assert
            mockRepository.Verify(r => r.GetCustomerByID(1));
            Assert.Equal("Elena Martinez", customer.Name);
        }

        [Fact]
        public void GetCustomers()
        {
            // Arrange
            var mockRepository = new Mock<ICustomerRepository>();
            mockRepository
                .Setup(m => m.GetCustomers())
                .Returns(new Customer[]
                {
                    new() {
                        Id = 1,
                        Name = "Elena Martinez"
                    },
                    new() {
                        Id = 2,
                        Name = "Jonathan Turner"
                    },
                    new() {
                        Id = 3,
                        Name = "Sophie Anderson"
                    }
                });

            var controller = new CustomersController(mockRepository.Object);

            // Act
            var customers = controller.GetCustomers().Value;

            // Assert
            mockRepository.Verify(r => r.GetCustomers());
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
            controller.CreateCustomer(new Customer
            {
                Id = 1,
                Name = "Sophie Anderson"
            });

            // Assert
            mockRepository.Verify(r => r.AddCustomer(It.IsAny<Customer>()));
            mockRepository.Verify(r => r.Save());
        }

        [Fact]
        public void UpdateCustomer()
        {
            // Arrange
            var mockRepository = new Mock<ICustomerRepository>();
            var controller = new CustomersController(mockRepository.Object);

            // Act
            controller.UpdateCustomer(1, new Customer
            {
                Id = 1,
                Name = "Elena Martinez"
            });

            // Assert
            mockRepository.Verify(r => r.UpdateCustomer(It.IsAny<Customer>()));
            mockRepository.Verify(r => r.Save());
        }

        [Fact]
        public void DeleteCustomer()
        {
            // Arrange
            var mockRepository = new Mock<ICustomerRepository>();
            mockRepository
                .Setup(m => m.DeleteCustomer(1))
                .Returns(true);

            var controller = new CustomersController(mockRepository.Object);

            // Act
            controller.DeleteCustomer(1);

            // Assert
            mockRepository.Verify(r => r.DeleteCustomer(1));
            mockRepository.Verify(r => r.Save());
        }
    }
}
