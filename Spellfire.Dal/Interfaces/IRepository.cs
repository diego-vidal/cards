using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Spellfire.Dal
{
    /// <summary>
    /// A generic interface for an entity-specific repository
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity associated with the repository</typeparam>
    public interface IRepository<TEntity>
    {
        /// <summary>
        /// Adds a new entity to the repository
        /// </summary>
        /// <param name="entity">The entity to add</param>
        /// <returns>The entity that was added. Existing references to the entity should be updated with this value.</returns>
        TEntity Add(TEntity entity);

        /// <summary>
        /// Returns a queryable collection for the entities related to this repository
        /// </summary>
        /// <returns>a queryable collection for the entities related to this repository</returns>
        IQueryable<TEntity> AsQueryable();

        /// <summary>
        /// Deletes an entity from the repository
        /// </summary>
        /// <param name="entityToDelete">the entity to delete</param>
        /// <returns>the entity</returns>
        TEntity Delete(TEntity entityToDelete);

        /// <summary>
        /// Retrieves a specific entity based on its unique ID
        /// </summary>
        /// <param name="key">the unique ID of the entity</param>
        /// <returns>the entity with the given ID, or null if an entity could not be found</returns>
        /// <exception cref="InvalidOperationException">Thrown if the type of the ID value does not match the type of the ID value associated with <typeparamref name="TEntity"/>.</exception>
        TEntity GetByKey(object key);

        /// <summary>
        /// Retrieves a single element that satisfies the given condition
        /// </summary>
        /// <param name="predicate">the condition that must be satisfied</param>
        /// <returns>a single element that satisfies the given condition, or null if no element could be found</returns>
        /// <exception cref="ArgumentNullException">thrown if <paramref name="predicate"/> is null</exception>
        /// <exception cref="InvalidOperationException">thrown if more than element is found that satisfies the given condition</exception>
        TEntity GetSingle(Func<TEntity, bool> predicate);

        /// <summary>
        /// Explicitly loads a related entity for the given entity instance
        /// </summary>
        /// <typeparam name="TProperty">the type of the related entity to load</typeparam>
        /// <param name="entity">the entity to load the related data for</param>
        /// <param name="propertyToLoad">an expression specifying which property the related entity should be loaded in to</param>
        /// <returns>the related entity that was loaded, or null if the given entity is null</returns>
        TProperty LoadProperty<TProperty>(TEntity entity, Expression<Func<TEntity, TProperty>> propertyToLoad) where TProperty : class;

        /// <summary>
        /// Explicitly loads a collection of related entities for the given entity instance
        /// </summary>
        /// <typeparam name="TCollection">the type of the related entities to load</typeparam>
        /// <param name="entity">the entity to load the related data for</param>
        /// <param name="collectionToLoad">an expression specifying the collection that the related entities should be loaded in to</param>
        /// <param name="filterExpression">an optional expression that will filter the related entities that are loaded</param>
        /// <returns>the collection of related entities that was loaded, or null if the given entity is null</returns>
        ICollection<TCollection> LoadCollection<TCollection>(
            TEntity entity,
            Expression<Func<TEntity, ICollection<TCollection>>> collectionToLoad,
            Expression<Func<TCollection, bool>> filterExpression = null,
            params Expression<Func<TCollection, object>>[] includes) where TCollection : class;

        /// <summary>
        /// Updates an existing entity in the repository
        /// </summary>
        /// <param name="entity">the entity to update</param>
        void Update(TEntity entity);

        ICollection<TResult> Query<TResult>(Expression<Func<TEntity, TResult>> selector, Expression<Func<TEntity, bool>> predicate);

        ICollection<TResult> Query<TResult>(Expression<Func<TEntity, TResult>> selector, Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includes);
    }
}
