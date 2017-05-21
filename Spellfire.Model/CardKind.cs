using System.ComponentModel.DataAnnotations;

namespace Spellfire.Model
{
    public class CardKind
    {
        [Key]
        public int CardKindKey { get; set; }

        [Required]
        public bool IsIcon { get; set; }

        public int CardKey { get; set; }
        public Card Card { get; set; }

        public KindKey KindKey { get; set; }
        public Kind Kind { get; set; }
    }
}
