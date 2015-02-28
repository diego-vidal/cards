using System.ComponentModel.DataAnnotations;

namespace Spellfire.Model
{
    public class CardPhase
    {
        [Key]
        public int CardPhaseKey { get; set; }
        public int CardKey { get; set; }

        public byte Number { get; set; }

        // Navigation
        public Card Card { get; set; }
    }
}
