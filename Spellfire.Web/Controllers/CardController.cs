using Spellfire.Dal;
using Spellfire.Web.Models;
using System.Linq;
using System.Web.Mvc;

namespace Spellfire.Web.Controllers
{
    public class CardController : BaseController
    {
        private IDataAccess _dal;

        public CardController(IDataAccess dal)
        {
            _dal = dal;
        }

        public ActionResult Index(string searchText)
        {
            var viewModel = new HomeViewModel()
            {
                SearchText = searchText ?? "spellfire",
            };

            return View(viewModel);
        }

        public ActionResult List(string searchText)
        {
            var cards = _dal.Cards.GetByName(searchText, x => x.CardKinds, x => x.Booster);
            var filteredCards = cards.Take(10);

            foreach(var card in filteredCards){
                _dal.Cards.LoadCollection(card, c => c.CardKinds, null, c => c.Kind);
            }

            var viewModel = new HomeViewModel()
            {
                SearchText = searchText,
                SearchCount = cards.Count(),
                FilteredCards = filteredCards
            };

            return PartialView("_CardList", viewModel);
        }

        public ActionResult Details(int id = 0, string searchText = null)
        {
            var card = _dal.Cards.GetBySequenceNumber(id);

            _dal.Cards.LoadProperty(card, c => c.Booster);
            _dal.Cards.LoadProperty(card, c => c.Rarity);
            _dal.Cards.LoadProperty(card, c => c.World);

            _dal.Cards.LoadCollection(card, c => c.CardCharacteristics, null, c => c.Characteristic);
            _dal.Cards.LoadCollection(card, c => c.CardKinds, null, c => c.Kind);
            _dal.Cards.LoadCollection(card, c => c.CardPhases);

            var viewModel = new HomeViewModel()
            {
                SearchText = searchText,
                SelectedCard = card
            };

            return PartialView("_CardDetail", viewModel);
        }
    }
}