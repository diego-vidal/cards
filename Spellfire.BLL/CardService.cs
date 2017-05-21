using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Spellfire.Model;
using Spellfire.Dal;
using Spellfire.Common.Extensions;

namespace Spellfire.BLL
{
    public class CardService : ICardService
    {
        private const string ChaseCharacter = "c";

        private IDataAccess _dal;

        public CardService(IDataAccess dal)
        {
            _dal = dal;
        }

        /// <summary>
        /// Returns a Card by its tag: booster name concatenated with its number (c for Chase)
        /// </summary>
        /// <param name="cardTag">[Booster][Number][c] i.e. 3rd400, ns3, dr67c, po100</param>
        /// <returns></returns>
        public Card GetCardByTag(string cardTag)
        {
            if (string.IsNullOrEmpty(cardTag))
            {
                return null;
            }

            var boosterLen = 2;
            var firstTwo = cardTag.Substring(0, boosterLen);
            var boosterKey = Enum.GetValues(typeof(BoosterKey)).Cast<BoosterKey>()
                                 .SingleOrDefault(x => string.Equals(x.GetDisplayShortName(), firstTwo, StringComparison.InvariantCultureIgnoreCase));

            // ToDo: Add BoosterKey.None = 0
            if (boosterKey == BoosterKey.NoEdition)
            {
                boosterLen = 3;

                var firstThree = cardTag.Substring(0, boosterLen);

                boosterKey = Enum.GetValues(typeof(BoosterKey)).Cast<BoosterKey>()
                                 .SingleOrDefault(x => string.Equals(x.GetDisplayShortName(), firstThree, StringComparison.InvariantCultureIgnoreCase));

                if (boosterKey == BoosterKey.NoEdition)
                {
                    return null;
                }
            }

            var cardNumberAsText = cardTag.Substring(boosterLen, cardTag.Length - boosterLen);
            var isChase = false;

            int cardNnumber;
            if (int.TryParse(cardNumberAsText, out cardNnumber))
            {
                return _dal.Cards.GetByBoosterAndNumber(boosterKey, cardNnumber, isChase, x => x.CardKinds, x => x.Booster);
            }

            var chaseNumberAsText = cardNumberAsText.Substring(0, cardNumberAsText.Length - 1);
            var isChaseCharacter = cardNumberAsText.Substring(cardNumberAsText.Length - 1, 1) == ChaseCharacter;

            if (isChaseCharacter && int.TryParse(chaseNumberAsText, out cardNnumber))
            {
                isChase = true;
                return _dal.Cards.GetByBoosterAndNumber(boosterKey, cardNnumber, isChase, x => x.CardKinds, x => x.Booster);
            }

            return null;
        }
    }
}
