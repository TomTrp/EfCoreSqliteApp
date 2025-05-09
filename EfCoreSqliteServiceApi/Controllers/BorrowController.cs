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
            BorrowReadDto? res = await _service.GetBorrowAsync(borrowId);
            return Ok(res);
        }

        [HttpGet]
        public async Task<IActionResult> GetBorrows()
        {
            List<BorrowReadDto> res = await _service.GetAllBorrowsAsync();
            return Ok(res);
        }

        [HttpPost]
        public async Task<IActionResult> AddBorrow([FromBody] BorrowCreateDto dto)
        {
            Borrow res = await _service.CreateBorrowAsync(dto);
            return Ok(res);
        }

        [HttpPost("multiple")]
        public async Task<IActionResult> AddMultipleBorrow([FromBody] BorrowCreateManyDto dto)
        {
            List<Borrow> res = await _service.CreateMultipleBorrowAsync(dto);
            return Ok(res);
        }


        [HttpPut("{borrowId}")]
        public async Task<IActionResult> UpdateBorrow(int borrowId)
        {
            Borrow res = await _service.UpdateBorrowAsync(borrowId);
            return Ok(res);
        }

        [HttpDelete("{borrowId}")]
        public async Task<IActionResult> DeleteBorrow(int borrowId)
        {
            bool res = await _service.DeleteBorrowAsync(borrowId);
            return Ok(res);
        }
    }
   
}
