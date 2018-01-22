using demoapi.Models;
using demoapi.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace demoapi.Controllers
{
    public class RingControllerTest
    {
        [Fact]
        public void GetNext_Returns_Next_Available_Ring()
        {
            // Arrange
            var slotProviderMock = new Mock<IRingProvider>();

            slotProviderMock.Setup(x => x.GetNextAvailableRing()).Returns(new Ring
            {
                Number = 1,
                HallNumber = 2
            });

            var controller = new RingController(slotProviderMock.Object);

            // Act
            var result = controller.GetNext();

            // Assert
            var actual = Assert.IsType<OkObjectResult>(result);
            var ring = Assert.IsType<Ring>(actual.Value);
            Assert.Equal(2, ring.Number);
            Assert.Equal(1, ring.HallNumber);
        }
    }
}
