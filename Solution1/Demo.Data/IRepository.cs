using Demo.Core;
using System.Collections.Generic;
using System.Linq;

namespace Demo.Data
{
    public interface IRepository<T> where T : BaseEntity
    {
        T GetById(object key);

        void Create(T entity);

        void Create(IEnumerable<T> entities);

        void Update(T entity);

        void Update(IEnumerable<T> entities);

        void Delete(T entity);

        void Delete(IEnumerable<T> entities);

        IQueryable<T> Table { get; }

        IQueryable<T> TableNoTracking { get; }
    }
}
