using Microsoft.AspNetCore.Mvc;

namespace demoapi.Controllers
{
    [Route("api/[controller]")]
    public class HealthController : Controller
    {
        // GET: api/<controller>
        [HttpGet]
        public ActionResult GetHealth()
        {
            return Ok(new
            {
                Status = "ok"
            });
        }
    }
}
