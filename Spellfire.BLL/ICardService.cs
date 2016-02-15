using Spellfire.Model;

namespace Spellfire.BLL
{
    public interface ICardService
    {
        Card GetCardByTag(string cardTag);
    }
}
