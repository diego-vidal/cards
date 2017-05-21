using System.ComponentModel.DataAnnotations;
using Spellfire.Common.Extensions;

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

        public Kind()
        {
            KindKey = KindKey.None;
            Name = KindKey.GetDisplayName();
        }
    }
}
