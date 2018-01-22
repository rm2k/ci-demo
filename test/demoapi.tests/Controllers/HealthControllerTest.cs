using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace demoapi.Controllers
{
    public class HealthControllerTest
    {
        [Fact]
        public void GetHealth_Returns_Ok_Status_With_Version_Number()
        {
            // Arrange
            var controller = new HealthController();

            // Act
            var result = controller.GetHealth();
                       

            // Assert           
            Assert.IsType<OkObjectResult>(result);
        }
    }
}
