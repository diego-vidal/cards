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
                return string.Join(", ", SelectedCard.CardKinds.Select(x => x.Kind.Name).ToArray());
            }
        }
        public string GetAttributesCsv
        {
            get
            {
                return string.Join(", ", SelectedCard.CardCharacteristics.Select(x => x.Characteristic.Name).ToArray());
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
                var cardType = SelectedCard.CardKinds.Where(x => x.IsIcon).SingleOrDefault();
                var icon = cardType != null && cardType.Kind != null ? cardType.Kind.Icon : "blank.gif";

                return icon;
            }
        }
    }
}