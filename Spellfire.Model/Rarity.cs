namespace Spellfire.Model
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Rarity")]
    public partial class Rarity
    {
        public Rarity()
        {
            Cards = new HashSet<Card>();
        }

        public byte RarityId { get; set; }

        [Required]
        [StringLength(16)]
        public string Name { get; set; }

        [Required]
        [StringLength(2)]
        public string Abbreviation { get; set; }

        public virtual ICollection<Card> Cards { get; set; }
    }
}
