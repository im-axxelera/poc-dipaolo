using AXX_poc_DiPaolo.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AXX_poc_DiPaolo.Controllers
{
    [Authorize]
    [Route("tyredealer")]
    public class TyreDealerController : AuthenticatedController
    {
        private readonly TyreDealerService _service;

        public TyreDealerController(TyreDealerService service)
        {
            _service = service;
        }

        [HttpGet("")]
        public IActionResult Index()
        {
            return RedirectToAction("history");
        }

        [HttpGet("active")]
        public IActionResult GetActive()
        {
            var request = _service.CollectActiveRequests(CurrentUsername);
            return View(request);
        }

        [HttpGet("history")]
        public IActionResult GetHistory()
        {
            var requests = _service.CollectRequestHistory(CurrentUsername);
            return View(requests);
        }

        [HttpGet("getcreate")]
        public IActionResult Create(int quantity)
        {
            return View();
        }

        [HttpPost("postcreate")]
        public IActionResult PostCreate(int quantity)
        {
            _service.PublishRequest(CurrentUsername, quantity);

            return RedirectToAction("active");
        }
    }
}
