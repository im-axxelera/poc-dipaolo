using AXX_poc_DiPaolo.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AXX_poc_DiPaolo.Controllers
{
    [Authorize]
    [Route("backoffice")]
    public class BackOfficeController : Controller
    {
        private readonly BackOfficeService _service;
        public BackOfficeController(BackOfficeService service)
        {
            _service = service;
        }

        [HttpGet("")]
        public IActionResult Index()
        {
            return RedirectToAction("all");
        }

        [HttpGet("all")]
        public IActionResult GetAll()
        {
            var requests = _service.CollectAllRequests();
            return View(requests);
        }

        [HttpGet("inprogress")]
        public IActionResult GetInProgress()
        {
            var requests = _service.CollectInProgressRequests();
            return View(requests);
        }

        [HttpGet("available")]
        public IActionResult GetAvailable()
        {
            var requests = _service.CollectAvailableRequests();
            return View(requests);
        }

        [HttpGet("completed")]
        public IActionResult GetCompleted()
        {
            var requests = _service.CollectCompletedRequests();
            return View(requests);
        }

        [HttpPost("validate")]
        public IActionResult UpdateValidate(Guid id, int quantity)
        {
            _service.ValidateRequest(id, quantity);
            return RedirectToAction("completed");
        }
    }
}
