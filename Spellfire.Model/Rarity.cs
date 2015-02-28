using System.ComponentModel.DataAnnotations;

namespace Spellfire.Model
{
    public class Rarity
    {
        [Key]
        public RarityKey RarityKey { get; set; }

        [Required, StringLength(16)]
        public string Name { get; set; }
        [Required, StringLength(2)]
        public string ShortName { get; set; }
    }
}
