using System.ComponentModel.DataAnnotations;

namespace Spellfire.Model
{
    public class Kind
    {
        [Key]
        public KindKey KindKey { get; set; }

        [Required, StringLength(32)]
        public string Name { get; set; }
        [Required, StringLength(32)]
        public string IconPath { get; set; }
    }
}
