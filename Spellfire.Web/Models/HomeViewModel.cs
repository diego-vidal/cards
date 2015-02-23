using Spellfire.Model;
using System.Collections.Generic;
using System.Linq;

namespace Spellfire.Web.Models
{
    public class HomeViewModel
    {
        public string SearchText { get; set; }
        public int SearchCount { get; set; }
        public IEnumerable<Card> FilteredCards { get; set; }
        public IOrderedEnumerable<Card> SortedCards
        {
            get
            {
                return FilteredCards.OrderBy(x => x.SequenceNumber);
            }
        }
        public Card SelectedCard { get; set; }
        public string GetTypesCsv
        {
            get
            {
                return string.Join(", ", SelectedCard.CardTypes.Select(x => x.Type.Name).ToArray());
            }
        }
        public string GetAttributesCsv
        {
            get
            {
                return string.Join(", ", SelectedCard.CardAttributes.Select(x => x.Attribute.Name).ToArray());
            }
        }
        public string GetPhasesCsv
        {
            get
            {
                return string.Join(", ", SelectedCard.CardPhases.Select(x => x.Number).ToArray());
            }
        }
        public string GetIcon
        {
            get
            {
                var cardType = SelectedCard.CardTypes.Where(x => x.IsIcon).SingleOrDefault();
                var icon = cardType != null && cardType.Type != null ? cardType.Type.Icon : "blank.gif";

                return icon;
            }
        }
    }
}