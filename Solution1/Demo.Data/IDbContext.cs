using Demo.Core;
using System.Collections.Generic;
using System.Data.Entity;

namespace Demo.Data
{
    public interface IDbContext
    {
        IDbSet<T> Set<T>() where T : BaseEntity;

        int SaveChanges();

        IEnumerable<TElement> SqlQuery<TElement>(string sql, params object[] parameters);

        int ExecuteSqlCommand(string sql, bool doNotEnsureTransaction = false, params object[] parameters);

        bool ProxyCreationEnabled { get; set; }

        bool AutoDetectChangesEnabled { get; set; }

        bool LazyLoadingEnabled { get; set; }
    }
}
