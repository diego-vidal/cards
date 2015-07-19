using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Spellfire.Common.Extensions;

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
        [Required, StringLength(11)]
        public string Level { get; set; }
        [StringLength(32)]
        public string ImagePath { get; set; }
        public string KindsCsv
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
        public string WorldPath
        {
            get
            {
                if (this.World.WorldKey != WorldKey.DarkSun)
                {
                    return this.World.ImagePath;
                }

                // Darksun's logo was changed for 4th Edition, Draconomicon, Nightstalker and Dungeons. Online boosters used old logo.
                var hasDarksunNewLogo = this.Booster.SortOrder >= 13 && this.Booster.SortOrder <= 16;

                // If the new logo needed, convert "ds.png" into "ds2.png"
                return hasDarksunNewLogo ? this.World.ImagePath.Insert(2, "2") : this.World.ImagePath;
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
