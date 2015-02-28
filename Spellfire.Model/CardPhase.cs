using System.ComponentModel.DataAnnotations;

namespace Spellfire.Model
{
    public class CardPhase
    {
        [Key]
        public int CardPhaseKey { get; set; }

        [Required]
        public byte Number { get; set; }

        // Navigation
        public int CardKey { get; set; }
        public Card Card { get; set; }
    }
}
