using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Todo.Domain.Infrastructure;

namespace Todo.Core.Repositories.RepositoryInterfaces
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        IQueryable<T> GetAll();
        IQueryable<T> GetAll(Expression<Func<T, bool>> predicate);
        T Get(int Id);
        T Get(Expression<Func<T, bool>> predicate);

        void Add(T entity);
        void Delete(T entity);

        int Commit();
    }
}
