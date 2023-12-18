using BrasserieOrdersysteem.Controllers;
using BrasserieOrdersysteem.DAL;
using BrasserieOrdersysteem.Models;
using Moq;
using Xunit;

namespace BrasserieOrdersysteem.Test
{
    public class CustomerTests
    {
        [Fact]
        public void GetCustomer()
        {
            // Arrange
            var mock = new Mock<ICustomerRepository>();
            mock.Setup(m => m.GetCustomerByID(1))
                .Returns(new Customer
                {
                    Id = 1,
                    Name = "Elena Martinez"
                });

            var controller = new CustomersController(mock.Object);

            // Act
            var customer = controller.GetCustomer(1).Value;

            // Assert
            mock.Verify(r => r.GetCustomerByID(1));
            Assert.Equal("Elena Martinez", customer.Name);
        }

        [Fact]
        public void GetCustomers()
        {
            // Arrange
            var mock = new Mock<ICustomerRepository>();
            mock.Setup(m => m.GetCustomers())
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

            var controller = new CustomersController(mock.Object);

            // Act
            var customers = controller.GetCustomers().Value;

            // Assert
            mock.Verify(r => r.GetCustomers());
            Assert.Equal("Elena Martinez", customers[0].Name);
            Assert.Equal("Jonathan Turner", customers[1].Name);
        }
    }
}
