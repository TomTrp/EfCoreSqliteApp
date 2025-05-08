using Microsoft.AspNetCore.Mvc;
using EfCoreSqliteLibs.DTO;
using EfCoreSqliteLibs.Entities;
using EfCoreSqliteLibs.Service.Interfaces.Books;

namespace EfCoreSqliteServiceApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookController : ControllerBase
    {
        private readonly IBookService _service;
        public BookController(IBookService service)
        {
            _service = service;
        }

        [HttpGet("{bookId}")]
        public async Task<IActionResult> GetBook(int bookId)
        {
            Book? book = await _service.GetBookAsync(bookId);
            return Ok(book);
        }

        [HttpGet]
        public async Task<IActionResult> GetBooks()
        {
            List<Book> books = await _service.GetAllBooksAsync();
            return Ok(books);
        }

        [HttpPost]
        public async Task<IActionResult> AddBook([FromBody] BookCreateDto dto)
        {
            Book book = await _service.CreateBookAsync(dto);
            return Ok(book);
        }
    }
   
}
