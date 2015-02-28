using System.ComponentModel.DataAnnotations;

namespace Spellfire.Model
{
    public class World
    {
        [Key]
        public WorldKey WorldKey { get; set; }

        [Required]
        [StringLength(32)]
        public string Name { get; set; }
        [Required]
        [StringLength(5)]
        public string ShortName { get; set; }
        [StringLength(32)]
        public string ImagePath { get; set; }
    }
}
