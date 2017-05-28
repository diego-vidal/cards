using Spellfire.Model;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Spellfire.Web.Models
{
    public class HomeViewModel
    {
        private const int _maxCardCount = 100;

        [Display(Prompt = "Type to search")]
        public string SearchText { get; set; }
        [Display(Name = "Include Online Boosters")]
        public bool IncludeOnlineBoosters { get; set; }
        public int MaxCardCount { get { return _maxCardCount; } }
        public IEnumerable<Card> FilteredCards { get; set; }
        public IOrderedEnumerable<Card> SortedCards
        {
            get
            {
                return FilteredCards.OrderBy(x => x.SequenceNumber);
            }
        }
        public Card SelectedCard { get; set; }

        public HomeViewModel()
        {
            FilteredCards = new List<Card>();
        }
    }
}