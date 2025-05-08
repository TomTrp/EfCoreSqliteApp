using Microsoft.EntityFrameworkCore;
using EfCoreSqliteLibs.Entities;
using EfCoreSqliteLibs.Repository.Interfaces.Borrowed;

namespace EfCoreSqliteLibs.Repository.Implementations.Borrowed
{
    public class BorrowRepository : IBorrowRepository
    {
        private readonly AppDbContext _context;
        public BorrowRepository(AppDbContext context) 
        { 
            _context = context;
        }

        public async Task<Borrow?> GetAsync(int borrowId)
        {
            return await _context.Borrow
                .Include(b => b.Book)
                .Include(bu => bu.User)
                .FirstOrDefaultAsync(x => x.BorrowId == borrowId);
        }

        public async Task<List<Borrow>> GetAllAsync()
        {
            return await _context.Borrow
                .Include(b => b.Book)
                .Include(bu => bu.User)
                .ToListAsync();
        }

        public async Task<Borrow> AddAsync(Borrow data)
        {
            _context.Borrow.Add(data);
            await _context.SaveChangesAsync();
            return data;
        }
    }
}
