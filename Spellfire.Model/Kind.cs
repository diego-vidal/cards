using System.ComponentModel.DataAnnotations;

namespace Spellfire.Model
{
    public class Kind
    {
        [Key]
        public KindKey KindKey { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [Required]
        [StringLength(25)]
        public string Icon { get; set; }
    }
}
