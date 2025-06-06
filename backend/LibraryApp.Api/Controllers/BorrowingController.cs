using LibraryApp.Application.DTOs.BookBorrowing;
using LibraryApp.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LibraryApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BorrowingController : ControllerBase
    {
        private readonly IBookBorrowingRequestService _service;

        public BorrowingController(IBookBorrowingRequestService service)
        {
            _service = service;
        }

        [HttpPost("Borrow")]
        public async Task<IActionResult> BorrowBooks([FromBody] BookBorrowingRequestCreateDto dto)
        {
            try
            {
                var result = await _service.BorrowBooksAsync(dto);
                return Ok(result);
            }
            catch (Exception ex)
            {

                return BadRequest(new { error = ex.Message });
            }
        }

        [HttpGet("User/{id}/requests")]
        public async Task<IActionResult> GetAllRequestsForUser(Guid id)
        {
            var requests = await _service.GetAllRequestsForUserAsync(id);

            return Ok(requests);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("admin/requests")]
        public async Task<IActionResult> GetAllRequestsForAdmin()
        {
            var requests = await _service.GetAllRequestsAsync();

            return Ok(requests);
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("admin/requests/{id}/status")]
        public async Task<IActionResult> UpdateRequestStatus(Guid id, [FromBody] BookBorrowingRequestUpdateStatusDto dto)
        {
            try
            {
                var updatedRequest = await _service.UpdateRequestStatusAsync(id, dto);
                return Ok(updatedRequest);
            }
            catch (Exception ex)
            {

                return BadRequest(new { Message = ex.Message });
            }
        }
    }
}
