using System;

namespace Spellfire.Dal
{
    /// <summary>
    /// Represents a single unit of work (i.e. a transaction)
    /// </summary>
    public interface IUnitOfWork : IDisposable
    {
        /// <summary>
        /// Attaches an object to a unit of work so that any further changes to it can be tracked.
        /// The object is assumed to already exist.
        /// </summary>
        /// <typeparam name="T">the type of the object to attach</typeparam>
        /// <param name="objectToAttach">the object to attach to the unit of work</param>
        /// <returns>the object that was attached</returns>
        T Attach<T>(T objectToAttach) where T : class;

        /// <summary>
        /// Saves all changes
        /// </summary>
        /// <returns>the number of changes saved</returns>
        int Save();

        /// <summary>
        /// Resets settings to their normal values, making large numbers of changes less efficient
        /// </summary>
        void DisableMassChanges();

        /// <summary>
        /// Temporarily modifies settings to allow large numbers of changes to be made efficiently
        /// </summary>
        void EnableMassChanges();
    }
}