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
    }
}