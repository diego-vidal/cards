using Spellfire.BLL;
using Spellfire.Dal;
using Spellfire.Model;
using Spellfire.Web.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Spellfire.Web.Controllers
{
    public class CardController : BaseController
    {
        private const int MaxCardListCount = 100;
        private IDataAccess _dal;
        private ICardService _cardService;

        public CardController(IDataAccess dal, ICardService cardService)
        {
            _dal = dal;
            _cardService = cardService;
        }

        public ActionResult Index(string search)
        {
            var viewModel = new HomeViewModel()
            {
                SearchText = search,
            };

            return View(viewModel);
        }

        public ActionResult List(string search, bool includeOnlineBoosters)
        {
            var card = _cardService.GetCardByTag(search);

            var viewModel = new HomeViewModel()
            {
                SearchText = search,
                FilteredCards = card == null ? new List<Card>() : new List<Card> { card },
            };

            if (!viewModel.FilteredCards.Any())
            {
                var filteredCards = _dal.Cards.GetByName(search, includeOnlineBoosters, MaxCardListCount, x => x.CardKinds, x => x.Booster);

                foreach (var fc in filteredCards)
                {
                    _dal.Cards.LoadCollection(fc, c => c.CardKinds, c => c.Kind);
                }

                viewModel.MaxCardListCount = MaxCardListCount;
                viewModel.FilteredCards = filteredCards;
            }

            return PartialView("_CardList", viewModel);
        }

        public ActionResult Details(int id = 0)
        {
            var card = _dal.Cards.GetBySequenceNumber(id, c => c.Booster, c => c.Rarity, c => c.World);

            if (card != null)
            {
                _dal.Cards.LoadCollection(card, c => c.CardCharacteristics, c => c.Characteristic);
                _dal.Cards.LoadCollection(card, c => c.CardKinds, c => c.Kind);
                _dal.Cards.LoadCollection(card, c => c.CardPhases);
            }

            var viewModel = new HomeViewModel()
            {
                SelectedCard = card
            };

            return PartialView("_CardDetail", viewModel);
        }
    }
}