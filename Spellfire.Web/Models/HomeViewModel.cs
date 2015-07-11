using Spellfire.Model;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Spellfire.Web.Models
{
    public class HomeViewModel
    {
        [Display(Prompt = "Type to search")]
        public string SearchText { get; set; }
        [Display(Name = "Include Online Boosters")]
        public bool IncludeOnlineBoosters { get; set; }
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