using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Spellfire.Dal
{
    public interface IRepository<TEntity>
    {
        TEntity Add(TEntity entity);
        IQueryable<TEntity> AsQueryable();
        TEntity Delete(TEntity entityToDelete);
        TEntity GetByKey(object key);
        TEntity GetSingleOrDefault(Func<TEntity, bool> predicate);
        TProperty LoadProperty<TProperty>(TEntity entity, Expression<Func<TEntity, TProperty>> propertyToLoad) where TProperty : class;
        ICollection<TCollection> LoadCollection<TCollection>(TEntity entity, Expression<Func<TEntity,
           ICollection<TCollection>>> collectionToLoad, params Expression<Func<TCollection, object>>[] includes) where TCollection : class;
        void Update(TEntity entity);
        ICollection<TResult> Query<TResult>(Expression<Func<TEntity, TResult>> selector, Expression<Func<TEntity, bool>> predicate);
        ICollection<TResult> Query<TResult>(Expression<Func<TEntity, TResult>> selector, Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includes);
    }
}
