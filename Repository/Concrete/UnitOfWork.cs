using ShoppingApi.Data.Concrete;
using ShoppingApi.DataAccess;
using ShoppingApi.Models;
using Todos.Repository.Abstract;

namespace Todos.Repository.Concrete
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        public UnitOfWork(ApplicationDbContext context) => _context = context;  
        
        public ShoppingApi.Data.Abstract.ITodoRepository<TodoItem> todorep => 
            new TodoRepository<TodoItem>(_context);

        public async Task<bool> SaveAsync()
        {
            return await _context.SaveChangesAsync()>0;
        }
    }
}
