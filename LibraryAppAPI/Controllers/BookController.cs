using LibraryAppAPI.Dto;
using LibraryAppAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LibraryAppAPI.Controllers
{
    [Route("api/[controller]")]
    
    [ApiController]
    public class BookController : Controller
    {

        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        //[Authorize]
        [HttpGet("GetAllBooks")]
        
        public async Task<IActionResult> Index()
        {
            var booksDto = await _bookService.GetAllBooksAsync();
            return Ok(booksDto);
        }

        //[Authorize(Roles = "Admin")]
        //[Authorize]
        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromForm] BookCreateDto movieDto)
        {
            await _bookService.AddBookAsync(movieDto);
            return Ok();
        }


        [HttpGet("GetById")]
        public async Task<IActionResult> GetMovieById(int id)
        {
            var movieDto = await _bookService.GetBookAsync(id);
            return Ok(movieDto);
        }

        [HttpPost("Edit")]
        public async Task<IActionResult> Edit([FromForm] BookUpdateDto movieDto)
        {
           
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            await _bookService.UpdateBookAsync(movieDto);
            return Ok();
        }
        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            await _bookService.DeleteBookAsync(id);
            return Ok();
        }
    }
}
      
       

            

