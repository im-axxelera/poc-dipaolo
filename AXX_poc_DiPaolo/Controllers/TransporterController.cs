using AXX_poc_DiPaolo.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AXX_poc_DiPaolo.Controllers
{
    [Authorize]
    [Route("transporter")]
    public class TransporterController : AuthenticatedController
    {
        private readonly TransporterService _service;

        public TransporterController(TransporterService service)
        {
            _service = service;
        }

        [HttpGet("")]
        public IActionResult Index()
        {
            return RedirectToAction("history");
        }

        [HttpGet("available")]
        public IActionResult GetAvailable()
        {
            var requests = _service.CollectAvailableRequests();
            return View(requests);
        }

        [HttpGet("inprogress")]
        public IActionResult GetInProgress()
        {
            var requests = _service.CollectActiveRequests(CurrentUsername);
            return View(requests);
        }

        [HttpGet("history")]
        public IActionResult GetHistory()
        {
            var requests = _service.CollectRequestHistory(CurrentUsername);
            return View(requests);
        }

        [HttpPost("assign")]
        public IActionResult PostAssign(Guid id, DateTime pickupDate)
        {
            _service.AssignRequest(id, CurrentUsername, pickupDate);

            return RedirectToAction("inprogress");
        }
    }
}