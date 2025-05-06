using LibraryApp.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LibraryApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequestDetailController : ControllerBase
    {
        private readonly IBookBorrowingRequestDetailService _service;

        public RequestDetailController(IBookBorrowingRequestDetailService service)
        {
            _service = service;
        }

        [HttpGet("request/{requestId}")]
        public async Task<IActionResult> GetDetailsByRequestId(Guid requestId)
        {
            var details = await _service.GetDetailsByRequestIdAsync(requestId);
            if (details == null || details.Count == 0)
            {

                return NotFound();
            }

            return Ok(details);
        }
    }
}
