using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

// ReSharper disable InconsistentNaming
namespace Spellfire.Dal
{
    /// <summary>
    /// Entity-framework extension methods 
    /// </summary>
    public static class IQueryableExtensions
    {
        /// <summary>
        /// Explicitly includes zero or more related entities in a given queryable collection
        /// </summary>
        /// <typeparam name="TEntity">the type of the entity being queried</typeparam>
        /// <param name="query">The queryable collection to include related entities in</param>
        /// <param name="includes">Expressions specifying the navigation properties for the related entities to include</param>
        public static IQueryable<TEntity> AddIncludes<TEntity>(this IQueryable<TEntity> query, params Expression<Func<TEntity, object>>[] includes)
            where TEntity : class
        {
            if (includes == null)
            {
                return query;
            }

            return includes.Aggregate(query, (current, action) => current.Include(action));
        }
    }
}
// ReSharper restore InconsistentNaming