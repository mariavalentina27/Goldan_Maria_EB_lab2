using Goldan_Maria_EB_lab2.Models;
using Microsoft.EntityFrameworkCore;

namespace Goldan_Maria_EB_lab2.Data
{
    public class LibraryContext:DbContext
    {
        public LibraryContext(DbContextOptions<LibraryContext> options) : base(options) { }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Book> Books { get; set; }
    }
}
