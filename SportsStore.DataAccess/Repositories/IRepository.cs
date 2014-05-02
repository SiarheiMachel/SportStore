using System;
using System.Linq;
using System.Linq.Expressions;

namespace SportsStore.DataAccess.Repositories
{
    public interface IRepository<T>
    {
        IQueryable<T> GetAll(Expression<Func<T, bool>> filter);
    }
}
