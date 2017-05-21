using System;
using System.Diagnostics.CodeAnalysis;

namespace Spellfire.Dal
{
    public class DataAccess : IDataAccess
    {
        private readonly IUnitOfWork _unitOfWork;
        private bool _disposed;

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

        public ILogRepository Logs
        {
            get { return LogsInitializer.Value; }
        }

        #endregion

        #region Repository Initializers

        public Lazy<ICardRepository> CardsInitializer { get; set; }
        public Lazy<ILogRepository> LogsInitializer { get; set; }

        #endregion

        #region Implementation of IUnitOfWork

        public T Attach<T>(T objectToAttach) where T : class
        {
            return _unitOfWork.Attach(objectToAttach);
        }

        public int Save()
        {
            return _unitOfWork.Save();
        }

        public void DisableMassChanges()
        {
            _unitOfWork.DisableMassChanges();
        }

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
        [SuppressMessage("StyleCop.CSharp.OrderingRules", "SA1202:ElementsMustBeOrderedByAccess", Justification = "Reviewed. Suppression is OK here.")]
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed && disposing)
            {
                _unitOfWork.Dispose();
            }

            _disposed = true;
        }

        #endregion
    }
}
