using BitTodo.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitTodo.Domain.Repositories
{
    public class EFCoreRepository<T> : IRepository<T> where T : EntityBase
    {
        private readonly AppDbContext _context;
        private readonly DbSet<T> _entities;
        public EFCoreRepository(AppDbContext context)
        {
            _context = context;
            _entities = context.Set<T>();
        }

        public IEnumerable<T> GetAll() => _entities.AsEnumerable();

        public T? Get(Guid id) => _entities.SingleOrDefault(s => s.Id == id);

        public void Insert(T entity)
        {
            if (entity == null) throw new ArgumentNullException("entity");
            _entities.Add(entity);
            _context.SaveChanges();
        }

        public void Update(T entity)
        {
            if (entity == null) throw new ArgumentNullException("entity");
            _context.SaveChanges();
        }

        public void Delete(T entity)
        {
            if (entity == null) throw new ArgumentNullException("entity");
            _entities.Remove(entity);
            _context.SaveChanges();
        }

        public IEnumerable<T> GetWhere(Func<T, bool> predicate)=> _entities.Where(predicate);
    }
}
