using System;
using System.Diagnostics.CodeAnalysis;

namespace Spellfire.Dal
{
    public class DataAccess : IDataAccess
    {
        private readonly IUnitOfWork _unitOfWork;
        private bool _disposed;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:System.Object"/> class.
        /// </summary>
        /// <param name="unitOfWork">A unit of work that will be used to save any changes</param>
        public DataAccess(IUnitOfWork unitOfWork)
        {
            if (unitOfWork == null)
            {
                throw new ArgumentNullException("unitOfWork");
            }

            if (unitOfWork is DataAccess)
            {
                throw new ArgumentException("The unit of work must not be an instance of the DataAccess class", "unitOfWork");
            }

            _unitOfWork = unitOfWork;
        }

        #region Repository Properties

        public ICardRepository Cards
        {
            get { return CardsInitializer.Value; }
        }

        #endregion
        
        #region Repository Initializers

        public Lazy<ICardRepository> CardsInitializer { get; set; }

        #endregion

        #region Implementation of IUnitOfWork

        /// <summary>
        /// Attaches an object to a unit of work so that any further changes to it can be tracked.
        /// The object is assumed to already exist.
        /// </summary>
        /// <typeparam name="T">the type of the object to attach</typeparam>
        /// <param name="objectToAttach">the object to attach to the unit of work</param>
        /// <returns>the object that was attached</returns>
        public T Attach<T>(T objectToAttach) where T : class
        {
            return _unitOfWork.Attach(objectToAttach);
        }

        /// <summary>
        /// Saves all changes
        /// </summary>
        /// <returns>the number of changes saved</returns>
        public int Save()
        {
            return _unitOfWork.Save();
        }

        /// <summary>
        /// Resets settings to their normal values, making large numbers of changes less efficient
        /// </summary>
        public void DisableMassChanges()
        {
            _unitOfWork.DisableMassChanges();
        }

        /// <summary>
        /// Temporarily modifies settings to allow large numbers of changes to be made efficiently
        /// </summary>
        public void EnableMassChanges()
        {
            _unitOfWork.EnableMassChanges();
        }

        #endregion

        #region Implementation of IDisposable

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        [SuppressMessage("StyleCop.CSharp.OrderingRules", "SA1202:ElementsMustBeOrderedByAccess", Justification = "Reviewed. Suppression is OK here.")]
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Disposes the unit of work
        /// </summary>
        /// <param name="disposing">If true, then the object is currently disposing</param>
        [SuppressMessage("StyleCop.CSharp.OrderingRules", "SA1202:ElementsMustBeOrderedByAccess", Justification = "Reviewed. Suppression is OK here.")]
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _unitOfWork.Dispose();
                }
            }

            _disposed = true;
        }

        #endregion
    }
}
