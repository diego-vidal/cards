using Spellfire.Dal;
using Spellfire.Model;
using Spellfire.Web.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Spellfire.Web.Controllers
{
    public class HandController : BaseController
    {
        private IDataAccess _dal;
        public enum HandType
        {
            Rules, Dungeons, OneCharLevel, TwoCharLevel, ThreeCharLevel, FourCharLevel
        }

        public HandController(IDataAccess dal)
        {
            _dal = dal;
        }

        public ActionResult Index(HandType id)
        {
            var sequenceNumbers = new List<int>();

            switch (id)
            {
                case HandType.Rules:
                    // SmallText: 2613, ADD:2196, ADD2:none, BR:3140, DS:2258, DR:none, DL:2370,  FR:2552, GH:1694, NS:none, RL:2259
                    sequenceNumbers = new List<int>() { 2613, 2196, 3140, 2258, 2370, 2552, 1694, 2259 };
                    break;
                case HandType.Dungeons:
                    // ADD:3444, ADD2:none, BR:3445, DS:3446, DR:none, DL:3447,  FR:3448, GH:3449, NS:none, RL:3450
                    sequenceNumbers = new List<int>() { 3444, 3445, 3446, 3447, 3448, 3449, 3450 };
                    break;
                case HandType.OneCharLevel:
                    // Cleric:1992, Hero:2325, Holding*:36 Monster:3300, Psionicist:2723, Realm:3473, Regent:3160, Thief:3361, Wizard:3222
                    // * TODO: fix the database for some holdings without "+"
                    sequenceNumbers = new List<int>() { 1992, 2325, 36, 3300, 2723, 3473, 3160, 3361, 3222 };
                    break;
                case HandType.TwoCharLevel:
                    // Ally:2677, Artifact:2440, BloodAbility:3103, ClericSpell:2102, Holding:1508, MagItem:3096, PsionicPower:2791, ThiefSkill:3533, UnarmedCombat:3038, WizardSpell:1371
                    // Cleric:3488, Hero:2181, Monster:2194, Psionicist:3564, Realm:3478, Realm:1773, Regent:3159, Thief:3363, Wizard:3439
                    sequenceNumbers = new List<int>() { 2677, 2440, 3103, 2102, 1508, 3096, 2791, 3478, 1773, 3159, 3363, 3038, 1371, 3488, 2181, 2194, 3564, 3439 };
                    break;
                case HandType.ThreeCharLevel:
                    // Ally:3044, 3566, 3665, Artifact:2225, 2165, MagItem:2562, 3176, 3633, UnarmedCombat:3765, Hero:824, Monster:2903
                    sequenceNumbers = new List<int>() { 3044, 3566, 3665, 2225, 2165, 2562, 3176, 3633, 3765, 824, 2903 };
                    break;
                case HandType.FourCharLevel:
                    // MagItem: 1893, 3510, Artifact:156, 556, 1001, 1421, 2158
                    sequenceNumbers = new List<int>() { 1893, 3510, 156, 556, 1001, 1421, 2158 };
                    break;
                default:
                    break;
            }

            var viewModel = new HandViewModel()
            {
                Cards = GetFullCards(sequenceNumbers)
            };

            return View(viewModel);
        }

        private List<Card> GetFullCards(List<int> sequenceNumbers)
        {
            var cards = new List<Card>();

            foreach (var sequenceNumber in sequenceNumbers)
            {
                var card = GetFullCard(sequenceNumber);

                if (card != null)
                {
                    cards.Add(card);
                }
            }

            return cards;
        }

        private Card GetFullCard(int sequenceNumber)
        {
            var card = _dal.Cards.GetBySequenceNumber(sequenceNumber, c => c.Booster, c => c.Rarity, c => c.World);

            if (card == null)
            {
                return null;
            }

            _dal.Cards.LoadCollection(card, c => c.CardKinds, null, c => c.Kind);

            return card;
        }
    }
}