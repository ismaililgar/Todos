using Microsoft.EntityFrameworkCore;
using ShoppingApi.Models;

namespace ShoppingApi.DataAccess
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        { 
        }
        public DbSet<TodoItem> Todoitems { get; set; } = null!;
      

    }

}

