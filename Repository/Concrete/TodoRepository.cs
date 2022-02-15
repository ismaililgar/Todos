using ShoppingApi.Data.Abstract;
using ShoppingApi.DataAccess;
using ShoppingApi.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace ShoppingApi.Data.Concrete
{
    public class TodoRepository<TEntity> : ITodoRepository<TEntity> where TEntity : class
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<TEntity> _dbset;
        public TodoRepository(ApplicationDbContext context)
        {
            _context = context;
            _dbset = _context.Set<TEntity>();
        }

        public void Add(TEntity entity)
        {
            _dbset.Add(entity);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _dbset.ToList();
        }

        public TEntity GetById(long id)
        {
            return _dbset.Find(id);

        }

        public void Remove(long id)
        {
            _dbset.Remove(GetById(id));
        }       
    }
}
