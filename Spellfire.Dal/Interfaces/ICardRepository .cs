using Spellfire.Model;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Spellfire.Dal
{
    public interface ICardRepository : IRepository<Card>
    {
        ICollection<Card> GetByName(string name, bool includeOnlineBoosters, params Expression<Func<Card, object>>[] includes);
        Card GetBySequenceNumber(int sequenceNumber, params Expression<Func<Card, object>>[] includes);
        Card GetByBoosterAndNumber(BoosterKey boosterKey, int number, bool isChase, params Expression<Func<Card, object>>[] includes);
    }
}