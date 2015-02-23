namespace Spellfire.Model
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Card")]
    public partial class Card
    {
        public Card()
        {
            CardAttributes = new HashSet<CardAttribute>();
            CardPhases = new HashSet<CardPhase>();
            CardTypes = new HashSet<CardType>();
        }

        public int CardId { get; set; }

        public int SequenceNumber { get; set; }

        public byte BoosterId { get; set; }

        public short Number { get; set; }

        public short NumberSet { get; set; }

        [Required]
        [StringLength(64)]
        public string Name { get; set; }

        [Required]
        [StringLength(1024)]
        public string Power { get; set; }

        [StringLength(256)]
        public string Blueline { get; set; }

        [Required]
        [StringLength(4)]
        public string Level { get; set; }

        public byte RarityId { get; set; }

        public byte WorldId { get; set; }

        [StringLength(32)]
        public string ImageName { get; set; }

        public virtual Booster Booster { get; set; }

        public virtual Rarity Rarity { get; set; }

        public virtual World World { get; set; }

        public virtual ICollection<CardAttribute> CardAttributes { get; set; }

        public virtual ICollection<CardPhase> CardPhases { get; set; }

        public virtual ICollection<CardType> CardTypes { get; set; }
    }
}
