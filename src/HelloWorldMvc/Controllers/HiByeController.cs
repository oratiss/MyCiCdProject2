using HelloWorldMvc.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using HelloWorldMvc.Configurations;
using Microsoft.Extensions.Options;

namespace HelloWorldMvc.Controllers
{
    public class HiByeController(
        ILogger<HiByeController> logger,
        IHttpClientFactory httpClientFactory,
        IOptions<ApiRelativeUrlConfig> relativeURlOptions)
        : Controller
    {
        private readonly ILogger<HiByeController> _logger = logger;
        private readonly ApiRelativeUrlConfig _relativeUrlConfig = relativeURlOptions.Value;

        [HttpGet]
        public IActionResult Index()
        {
            var model = new HiByeIndexViewModel
            {
                Message = "This is the message that will change by pressing below button."
            };

            return View(model);
        }

        /// <summary>
        /// Calls HelloWorld Api and returns its message. Message comes from api.
        /// </summary>
        /// <returns></returns>
        [HttpPost(Name = "Hello")]
        public async Task<IActionResult> Hello()
        {
            var client = httpClientFactory.CreateClient("ApiClient");
            var apiResult = await client.GetFromJsonAsync<string>(_relativeUrlConfig.HelloRelativeRoute);

            HiByeIndexViewModel model = new() { Message = apiResult };
            return View("Index", model);
        }

        [HttpPost(Name = "GoodBye")]
        public async Task<IActionResult> GoodBye()
        {
            var client = httpClientFactory.CreateClient("ApiClient");
            var apiResult = await client.GetFromJsonAsync<string>(_relativeUrlConfig.GoodByeRelativeRoute);

            HiByeIndexViewModel model = new() { Message = apiResult };
            return View("Index", model);
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
