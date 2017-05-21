using System;

namespace Spellfire.Dal
{
    /// <summary>
    public interface IUnitOfWork : IDisposable
    {
        T Attach<T>(T objectToAttach) where T : class;
        int Save();
        void DisableMassChanges();
        void EnableMassChanges();
    }
}