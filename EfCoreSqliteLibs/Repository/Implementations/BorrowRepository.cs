using Microsoft.EntityFrameworkCore;
using EfCoreSqliteLibs.Entities;
using EfCoreSqliteLibs.Repository.Interfaces;

namespace EfCoreSqliteLibs.Repository.Implementations
{
    public class BorrowRepository : IBorrowRepository
    {
        private readonly AppDbContext _context;
        public BorrowRepository(AppDbContext context) 
        { 
            _context = context;
        }

        public async Task<bool> IsBookAvailableAsync(int bookId)
        {
            return !await _context.Borrow
                .AnyAsync(b => b.BookId == bookId && b.Status != "Returned");
        }

        public async Task<Borrow?> GetTrackedByIdAsync(int borrowId)
        {
            return await _context.Borrow
                .Include(b => b.Book)
                .Include(bu => bu.User)
                .FirstOrDefaultAsync(x => x.BorrowId == borrowId);
        }

        public async Task<Borrow?> GetAsync(int borrowId)
        {
            return await _context.Borrow
                .AsNoTracking()
                .Include(b => b.Book) // act like left join
                .Include(bu => bu.User)
                .FirstOrDefaultAsync(x => x.BorrowId == borrowId);
        }

        public async Task<List<Borrow>> GetAllAsync()
        {
            return await _context.Borrow
                .AsNoTracking()
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

        public async Task<List<Borrow>> AddMultipleAsync(List<Borrow> borrows)
        {
            await _context.Borrow.AddRangeAsync(borrows);
            await _context.SaveChangesAsync();
            return borrows;
        }

        public async Task<Borrow> UpdateAsync(Borrow data)
        {
            await _context.SaveChangesAsync();
            return data;
        }
        public async Task DeleteAsync(Borrow data)
        {
            _context.Borrow.Remove(data);
            await _context.SaveChangesAsync();
        }
    }
}
