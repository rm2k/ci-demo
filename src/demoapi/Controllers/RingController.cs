using System;
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

            if(ring == null)
            {
                return NotFound();
            }

            return Ok(ring);
        }

        public IActionResult GetAll()
        {
            var rings = _provider.GetAllAvailableRings();

            return Ok(rings);
        }

        public IActionResult IsAvailable(int hallNumber, int ringNumber)
        {
            var result = _provider.IsRingAvailable(hallNumber,ringNumber);

            if(result)
            {
                return Ok();                
            }
            
            return StatusCode(423, new 
            {
                Error = "The ring is currently in use"
            });
        }
    }
}
