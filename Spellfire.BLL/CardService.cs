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
        private IDataAccess _dal;

        public CardService(IDataAccess dal)
        {
            _dal = dal;
        }

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

            int cardNnumber;
            var strNumber = cardTag.Substring(boosterLen, cardTag.Length - boosterLen);

            if (!int.TryParse(strNumber, out cardNnumber))
            {
                return null;
            }

            return _dal.Cards.GetByBoosterAndNumber(boosterKey, cardNnumber, x => x.CardKinds, x => x.Booster);
        }
    }
}
