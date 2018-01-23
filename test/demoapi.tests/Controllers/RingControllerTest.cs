using demoapi.Models;
using demoapi.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Collections.Generic;
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
            Assert.Equal(1, ring.Number);
            Assert.Equal(2, ring.HallNumber);
        }

        [Fact]
        public void GetNext_Returns_NotFound_When_There_Is_No_Available_Ring()
        {
            // Arrange
            var slotProviderMock = new Mock<IRingProvider>();

            slotProviderMock.Setup(x => x.GetNextAvailableRing()).Returns(() => null);

            var controller = new RingController(slotProviderMock.Object);

            // Act
            var result = controller.GetNext();

            // Assert
            var actual = Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public void GetAll_Returns_All_Available_Rings()
        {
            // Arrange
            var slotProviderMock = new Mock<IRingProvider>();

            slotProviderMock.Setup(x => x.GetAllAvailableRings()).Returns(() => new List<Ring>
            {
                new Ring
                {
                    Number = 1,
                    HallNumber = 2
                }
            });

            var controller = new RingController(slotProviderMock.Object);

            // Act
            var result = controller.GetAll();

            // Assert
            var actual = Assert.IsType<OkObjectResult>(result);
            var rings = Assert.IsAssignableFrom<IEnumerable<Ring>>(actual.Value);
        }
    }
}
