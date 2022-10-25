using BitTodo.Domain.Models;

namespace BitTodo.Domain.Repositories
{
    public interface IRepository<T> where T : EntityBase
    {
        T? Get(Guid id);
        IEnumerable<T> GetAll();
        IEnumerable<T> GetWhere(Func<T, bool> predicate);
        void Delete(T entity);
        void Insert(T entity);
        void Update(T entity);
    }
}