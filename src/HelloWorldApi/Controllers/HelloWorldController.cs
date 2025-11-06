using Microsoft.AspNetCore.Mvc;

namespace HelloWorldApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HelloWorldController : ControllerBase
    {
        private readonly ILogger<HelloWorldController> _logger;

        public HelloWorldController(ILogger<HelloWorldController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("GetHelloWorld")]
        public ActionResult<string> GetHelloWorld()
        {
            string result = "Hello World!";
            return Ok(result);
        }

        //[HttpGet]
        //[Route("GetGoodBye")]
        //public ActionResult<string> GetGoodBye()
        //{
        //    string result = "GoodBye World!";
        //    return Ok(result);
        //}
    }
}
