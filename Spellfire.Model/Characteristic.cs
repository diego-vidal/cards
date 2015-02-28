using System.ComponentModel.DataAnnotations;

namespace Spellfire.Model
{
    public class Characteristic
    {
        [Key]
        public CharacteristicKey CharacteristicKey { get; set; }

        [Required, StringLength(32)]
        public string Name { get; set; }
    }
}
