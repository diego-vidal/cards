using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace Spellfire.Dal
{
    public abstract class RepositoryBase<TEntity, TContext> : IRepository<TEntity>
        where TEntity : class
        where TContext : DbContext
    {
        protected RepositoryBase(TContext context)
        {
            Context = context;
        }

        protected TContext Context { get; private set; }

        public virtual TEntity Add(TEntity entity)
        {
            return Context.Set<TEntity>().Add(entity);
        }

        public IQueryable<TEntity> AsQueryable()
        {
            return Context.Set<TEntity>();
        }

        public virtual TEntity Delete(TEntity entityToDelete)
        {
            var entry = Context.Entry(entityToDelete);

            if (entry.State == EntityState.Deleted)
            {
                return entityToDelete;
            }

            Context.Set<TEntity>().Attach(entityToDelete);
            return Context.Set<TEntity>().Remove(entityToDelete);
        }

        public virtual TEntity GetByKey(object key)
        {
            return Context.Set<TEntity>().Find(key);
        }

        public TEntity GetSingleOrDefault(Func<TEntity, bool> predicate)
        {
            return Context.Set<TEntity>().SingleOrDefault(predicate);
        }

        public TProperty LoadProperty<TProperty>(TEntity entity, Expression<Func<TEntity, TProperty>> propertyToLoad)
            where TProperty : class
        {
            if (entity == null)
            {
                return null;
            }

            Context.Entry(entity).Reference(propertyToLoad).Load();

            return propertyToLoad.Compile().Invoke(entity);
        }

        public ICollection<TCollection> LoadCollection<TCollection>(TEntity entity, Expression<Func<TEntity,
            ICollection<TCollection>>> collectionToLoad, params Expression<Func<TCollection, object>>[] includes) where TCollection : class
        {
            if (entity == null)
            {
                return null;
            }

            var collectionEntry = Context.Entry(entity).Collection(collectionToLoad);

            //if (filterExpression != null)
            //{
            //    collectionEntry.Query().Where(filterExpression).AddIncludes(includes).Load();
            //}
            //else
            //{
                collectionEntry.Query().AddIncludes(includes).Load();
            //}

            return collectionToLoad.Compile().Invoke(entity);
        }

        public virtual void Update(TEntity entity)
        {
            var entry = Context.Entry(entity);

            if (entry.State == EntityState.Modified)
            {
                return;
            }

            Context.Set<TEntity>().Attach(entity);
            entry.State = EntityState.Modified;
        }

        public ICollection<TResult> Query<TResult>(Expression<Func<TEntity, TResult>> selector, Expression<Func<TEntity, bool>> predicate)
        {
            return Context.Set<TEntity>().Where(predicate).Select(selector).ToList();
        }

        public ICollection<TResult> Query<TResult>(Expression<Func<TEntity, TResult>> selector, Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includes)
        {
            return Context.Set<TEntity>().Where(predicate).AddIncludes(includes).Select(selector).ToList();
        }
    }
}