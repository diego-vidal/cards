namespace Spellfire.Model
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Booster")]
    public partial class Booster
    {
        public Booster()
        {
            Cards = new HashSet<Card>();
        }

        public byte BoosterId { get; set; }

        [Required]
        [StringLength(32)]
        public string Name { get; set; }

        [Required]
        [StringLength(4)]
        public string Abbreviation { get; set; }

        [StringLength(32)]
        public string ImageName { get; set; }

        public virtual ICollection<Card> Cards { get; set; }
    }
}
