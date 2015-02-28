using System.ComponentModel.DataAnnotations;

namespace Spellfire.Model
{
    public class CardCharacteristic
    {
        [Key]
        public int CardCharacteristicKey { get; set; }

        // Navigation
        public int CardKey { get; set; }
        public Card Card { get; set; }

        public CharacteristicKey CharacteristicKey { get; set; }
        public Characteristic Characteristic { get; set; }
    }
}
