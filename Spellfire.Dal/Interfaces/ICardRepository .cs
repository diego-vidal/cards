using Spellfire.Model;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Spellfire.Dal
{
    public interface ICardRepository : IRepository<Card>
    {
        ICollection<Card> GetByName(string name, params Expression<Func<Card, object>>[] includes);
        Card GetBySequenceNumber(int sequenceNumber, params Expression<Func<Card, object>>[] includes);
    }
}