using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EfCoreSqliteLibs.Entities;

namespace EfCoreSqliteLibs
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Book> Books { get; set; }
        public DbSet<Borrow> Borrow { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
