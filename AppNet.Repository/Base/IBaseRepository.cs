using AppNet.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AppNet.Repository.Base
{
    public interface IBaseRepository<T> where T : class, IEntity
    {
        T Get(int Id);
        IQueryable<T> GetAll(Expression<Func<T, bool>> predicate = null);

        T Create(T entity);
        bool Update(T entity);
        bool Delete(T entity);
        bool Delete(int Id);
        bool Activate(T entity);
        bool Activate(int Id);
        bool Deactivate(T entity);
        bool Deactivate(int Id);

        bool SaveChanges();
    }
}
