using ShoppingApi.Models;
using System.Linq.Expressions;

namespace ShoppingApi.Data.Abstract
{
    public interface ITodoRepository<TEntity> where TEntity : class
    {
        TEntity GetById(long id);
        IEnumerable<TEntity> GetAll();

        void Add(TEntity entity);   
        void Remove(long id);     
    }
}
