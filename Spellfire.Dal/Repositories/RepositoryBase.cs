using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;

namespace Spellfire.Dal
{
    /// <summary>
    /// A generic, entity-specific, repository implementation for Entity Framework
    /// </summary>
    /// <typeparam name="TEntity">the type of the entity</typeparam>
    /// <typeparam name="TContext">the type of the context</typeparam>
    public abstract class RepositoryBase<TEntity, TContext> : IRepository<TEntity>
        where TEntity : class
        where TContext : DbContext
    {
        protected RepositoryBase(TContext context)
        {
            Context = context;
        }

        /// <summary>
        /// Gets the Entity Framework context associated with this repository.
        /// </summary>
        protected TContext Context { get; private set; }

        /// <summary>
        /// Adds a new entity to the repository
        /// </summary>
        /// <param name="entity">The entity to add</param>
        /// <returns>The entity that was added. Existing references to the entity should be updated with this value.</returns>
        public virtual TEntity Add(TEntity entity)
        {
            return Context.Set<TEntity>().Add(entity);
        }

        /// <summary>
        /// Returns a queryable collection for the entities related to this repository
        /// </summary>
        /// <returns>a queryable collection for the entities related to this repository</returns>
        public IQueryable<TEntity> AsQueryable()
        {
            return Context.Set<TEntity>();
        }

        /// <summary>
        /// Deletes an entity from the repository
        /// </summary>
        /// <param name="entityToDelete">the entity to delete</param>
        /// <returns>the entity</returns>
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

        /// <summary>
        /// Retrieves a specific entity based on its unique ID
        /// </summary>
        /// <param name="key">the unique ID of the entity</param>
        /// <returns>the entity with the given ID, or null if an entity could not be found</returns>
        /// <exception cref="InvalidOperationException">Thrown if the type of the ID value does not match the type of the ID value associated with <typeparamref name="TEntity"/>.</exception>
        public virtual TEntity GetByKey(object key)
        {
            return Context.Set<TEntity>().Find(key);
        }

        /// <summary>
        /// Retrieves a single element that satisfies the given condition
        /// </summary>
        /// <param name="predicate">the condition that must be satisfied</param>
        /// <returns>a single element that satisfies the given condition, or null if no element could be found</returns>
        /// <exception cref="ArgumentNullException">thrown if <paramref name="predicate"/> is null</exception>
        /// <exception cref="InvalidOperationException">thrown if more than element is found that satisfies the given condition</exception>
        public TEntity GetSingle(Func<TEntity, bool> predicate)
        {
            return Context.Set<TEntity>().SingleOrDefault(predicate);
        }

        /// <summary>
        /// Explicitly loads a related entity for the given entity instance
        /// </summary>
        /// <typeparam name="TProperty">the type of the related entity to load</typeparam>
        /// <param name="entity">the entity to load the related data for</param>
        /// <param name="propertyToLoad">an expression specifying which property the related entity should be loaded in to</param>
        /// <returns>the entity, with the related entity loaded, or null if the given entity is null</returns>
        public TProperty LoadProperty<TProperty>(TEntity entity, Expression<Func<TEntity, TProperty>> propertyToLoad) where TProperty : class
        {
            if (entity == null)
            {
                return null;
            }

            Context.Entry(entity).Reference(propertyToLoad).Load();

            return propertyToLoad.Compile().Invoke(entity);
        }

        /// <summary>
        /// Explicitly loads a collection of related entities for the given entity instance
        /// </summary>
        /// <typeparam name="TCollection">the type of the related entities to load</typeparam>
        /// <param name="entity">the entity to load the related data for</param>
        /// <param name="collectionToLoad">an expression specifying the collection that the related entities should be loaded in to</param>
        /// <param name="filterExpression">an optional expression that will filter the related entities that are loaded</param>
        /// <returns>the collection of related entities that was loaded, or null if the given entity is null</returns>
        public ICollection<TCollection> LoadCollection<TCollection>(
            TEntity entity,
            Expression<Func<TEntity, ICollection<TCollection>>> collectionToLoad,
            Expression<Func<TCollection, bool>> filterExpression = null,
            params Expression<Func<TCollection, object>>[] includes) where TCollection : class
        {
            if (entity == null)
            {
                return null;
            }

            var collectionEntry = Context.Entry(entity).Collection(collectionToLoad);

            if (filterExpression != null)
            {
                collectionEntry.Query().Where(filterExpression).AddIncludes(includes).Load();
            }
            else
            {
                collectionEntry.Query().AddIncludes(includes).Load();
            }

            return collectionToLoad.Compile().Invoke(entity);
        }

        /// <summary>
        /// Attaches an entity to the context and marks it as updated.
        /// </summary>
        /// <param name="entity">the entity to update</param>
        /// <remarks>
        /// <para>
        /// If the given entity is already attached to the context and has been marked as modified,
        /// this method will return without taking any action.
        /// </para>
        /// <para>
        /// This method will cause all properties of the given entity to be updated. In cases where
        /// only specific properties should be updated, it is recommended to either retrieve the existing
        /// entity first and apply the updates
        /// </para>
        /// </remarks>
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