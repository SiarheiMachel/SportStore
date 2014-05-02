using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace SportsStore.DataAccess.Repositories
{
    public abstract class EntityFrameworkRepository<T> : IRepository<T> 
        where T:class 
    {
        protected DbContext DbContext { get; private set; }

        protected DbSet<T> DbSet { get; private set; }

        protected EntityFrameworkRepository(DbContext context)
        {
            DbContext = context;
            DbSet = context.Set<T>();
        }

        IQueryable<T> IRepository<T>.GetAll(Expression<Func<T, bool>> filter)
        {
            return DbSet;
        }
    }
}
