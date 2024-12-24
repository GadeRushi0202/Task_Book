using BookTask.Models;
using Microsoft.EntityFrameworkCore;

namespace BookTask.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { } 
        public DbSet<Book>Books { get; set; }   
    }
}
