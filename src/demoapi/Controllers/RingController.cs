using demoapi.Services;
using Microsoft.AspNetCore.Mvc;

namespace demoapi.Controllers
{
    [Route("api/[controller]")]
    public class RingController : Controller
    {
        private readonly IRingProvider _provider;

        public RingController(IRingProvider provider)
        {
            _provider = provider;
        }

        public IActionResult GetNext()
        {
            var ring = _provider.GetNextAvailableRing();

            return Ok(ring);
        }
    }
}
