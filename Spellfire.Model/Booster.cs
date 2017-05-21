using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Spellfire.Model
{
    public class Booster
    {
        [Key]
        public BoosterKey BoosterKey { get; set; }

        [Required, StringLength(32)]
        public string Name { get; set; }
        [Required, StringLength(3)]
        public string ShortName { get; set; }
        [StringLength(32)]
        public string ImagePath { get; set; }
        [Required]
        public int SortOrder { get; set; }
    }
}
