using Microsoft.AspNetCore.Mvc;

namespace HelloWorldApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HelloWorldController(ILogger<HelloWorldController> logger) : ControllerBase
    {
        private readonly ILogger<HelloWorldController> _logger = logger;

        [HttpGet]
        [Route("GetHelloWorld")]
        public ActionResult<string> GetHelloWorld()
        {
            string result = "Hello World!";
            return Ok(result);
        }

        [HttpGet]
        [Route("GetGoodBye")]
        public ActionResult<string> GetGoodBye()
        {
            string result = "GoodBye World!";
            return Ok(result);
        }
    }
}
