using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Spellfire.Model
{
    public class Card
    {
        [Key]
        public int CardKey { get; set; }
        [Required]
        public int SequenceNumber { get; set; }
        [Required]
        public short Number { get; set; }
        [Required]
        public short NumberSet { get; set; }
        [Required, StringLength(64)]
        public string Name { get; set; }
        [Required, StringLength(1024)]
        public string Power { get; set; }
        [StringLength(256)]
        public string Blueline { get; set; }
        [Required, StringLength(4)]
        public string Level { get; set; }
        [StringLength(32)]
        public string ImagePath { get; set; }
        public string TypesCsv
        {
            get { return string.Join(", ", this.CardKinds.Select(x => x.Kind.Name).ToArray()); }
        }
        public string AttributesCsv
        {
            get { return string.Join(", ", this.CardCharacteristics.Select(x => x.Characteristic.Name).ToArray()); }
        }
        public string PhasesCsv
        {
            get { return string.Join(", ", this.CardPhases.Select(x => x.Number).ToArray()); }
        }
        public string IconPath
        {
            get
            {
                var cardType = this.CardKinds.Where(x => x.IsIcon).SingleOrDefault();
                var iconPath = cardType != null && cardType.Kind != null ? cardType.Kind.IconPath : "blank.gif";

                return iconPath;
            }
        }

        public ICollection<CardCharacteristic> CardCharacteristics { get; set; }
        public ICollection<CardKind> CardKinds { get; set; }
        public ICollection<CardPhase> CardPhases { get; set; }

        // Navigation
        public BoosterKey BoosterKey { get; set; }
        public Booster Booster { get; set; }

        public RarityKey RarityKey { get; set; }
        public Rarity Rarity { get; set; }

        public WorldKey WorldKey { get; set; }
        public World World { get; set; }

        public Card()
        {
            CardCharacteristics = new List<CardCharacteristic>();
            CardKinds = new List<CardKind>();
            CardPhases = new List<CardPhase>();
        }
    }
}
