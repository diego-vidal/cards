namespace Spellfire.Model
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("World")]
    public partial class World
    {
        public World()
        {
            Cards = new HashSet<Card>();
        }

        public byte WorldId { get; set; }

        [Required]
        [StringLength(32)]
        public string Name { get; set; }

        [Required]
        [StringLength(5)]
        public string Abbreviation { get; set; }

        [StringLength(32)]
        public string ImageName { get; set; }

        public virtual ICollection<Card> Cards { get; set; }
    }
}
