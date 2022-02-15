using ShoppingApi.Data.Abstract;
using ShoppingApi.Models;

namespace Todos.Repository.Abstract
{
    public interface IUnitOfWork
    {
        ITodoRepository<TodoItem>todorep { get; }
        Task<bool> SaveAsync();
    }
}
