using Microsoft.AspNetCore.Mvc;
using EfCoreSqliteLibs.DTO;
using EfCoreSqliteLibs.Entities;
using EfCoreSqliteLibs.Service.Interfaces;

namespace EfCoreSqliteServiceApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BorrowController : ControllerBase
    {
        private readonly IBorrowService _service;
        public BorrowController(IBorrowService service)
        {
            _service = service;
        }

        [HttpGet("{borrowId}")]
        public async Task<IActionResult> GetBorrow(int borrowId)
        {
            BorrowReadDto? borrow = await _service.GetBorrowAsync(borrowId);
            return Ok(borrow);
        }

        [HttpGet]
        public async Task<IActionResult> GetBorrows()
        {
            List<BorrowReadDto> borrowed = await _service.GetAllBorrowedAsync();
            return Ok(borrowed);
        }

        [HttpPost]
        public async Task<IActionResult> AddBook([FromBody] BorrowCreateDto dto)
        {
            Borrow borrow = await _service.CreateBorrowAsync(dto);
            return Ok(borrow);
        }
    }
   
}
