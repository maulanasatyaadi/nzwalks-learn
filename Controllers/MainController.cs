using Microsoft.AspNetCore.Mvc;

namespace NZWalks.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MainController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return Ok(new
            {
                Timestamp = DateTime.Now,
            });
        }
    }
}
