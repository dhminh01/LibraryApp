using LibraryApp.Application.DTOs.Book;
using LibraryApp.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LibraryApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var books = await _bookService.GetAllAsync();

            return Ok(books);
        }

        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var book = await _bookService.GetByIdAsync(id);
            if (book == null)

                return NotFound();

            return Ok(book);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] CreateBookDto dto)
        {
            if (!ModelState.IsValid)

                return BadRequest(ModelState);

            var book = await _bookService.CreateAsync(dto);

            return CreatedAtAction(nameof(GetById), new { id = book.Id }, book);
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("Update/{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateBookDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var updatedBook = await _bookService.UpdateAsync(id, dto);
            if (updatedBook == null)
                return NotFound();

            return Ok(updatedBook);
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _bookService.DeleteAsync(id);
            if (!result)

                return NotFound();

            return NoContent();
        }
    }
}

