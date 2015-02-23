namespace Spellfire.Dal
{   
    public interface IDataAccess : IUnitOfWork
    {
        ICardRepository Cards { get; }
    }
}
