using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Todo.Core.Repositories.RepositoryInterfaces;
using Todo.Domain.Infrastructure;

namespace Todo.Core.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly DbContext _dbContext;
        private readonly DbSet<T> _dbset;

        public GenericRepository()
        {
            _dbContext = new TodoContext();
            _dbset = _dbContext.Set<T>();
        }

        public void Add(T entity)
        {
            _dbset.Add(entity);
        }

        public int Commit()
        {
            return _dbContext.SaveChanges();
        }

        public void Delete(T entity)
        {
            _dbset.Remove(entity);
        }

        public T Get(int Id)
        {
            return _dbset.Find(Id);
        }

        public T Get(Expression<Func<T, bool>> predicate)
        {
            return _dbset.SingleOrDefault(predicate);
        }

        public IQueryable<T> GetAll()
        {
            return _dbset;
        }

        public IQueryable<T> GetAll(Expression<Func<T, bool>> predicate)
        {
            return _dbset.Where(predicate);
        }        
    }
}
