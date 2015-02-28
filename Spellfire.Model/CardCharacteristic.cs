using System.ComponentModel.DataAnnotations;

namespace Spellfire.Model
{
    public class CardCharacteristic
    {
        [Key]
        public int CardCharacteristicKey { get; set; }
        public int CardKey { get; set; }
        public CharacteristicKey CharacteristicKey { get; set; }

        // Navigation
        public Card Card { get; set; }
        public Characteristic Characteristic { get; set; }
    }
}
