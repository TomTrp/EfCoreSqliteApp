﻿using Microsoft.EntityFrameworkCore;
using EfCoreSqliteLibs.Entities;
using EfCoreSqliteLibs.Repository.Interfaces.Books;

namespace EfCoreSqliteLibs.Repository.Implementations.Books
{
    public class BookRepository : IBookRepository
    {
        private readonly AppDbContext _context;
        public BookRepository(AppDbContext context) 
        { 
            _context = context;
        }

        public async Task<Book?> GetAsync(int bookId)
        {
            return await _context.Books.FirstOrDefaultAsync(x => x.BookId == bookId);
        }

        public async Task<List<Book>> GetAllAsync()
        {
            return await _context.Books.ToListAsync();
        }

        public async Task<Book> AddAsync(Book data)
        {
            _context.Books.Add(data);
            await _context.SaveChangesAsync();
            return data;
        }
    }
}
