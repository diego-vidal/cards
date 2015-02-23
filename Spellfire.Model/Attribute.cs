namespace Spellfire.Model
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Attribute")]
    public partial class Attribute
    {
        public Attribute()
        {
            CardAttributes = new HashSet<CardAttribute>();
        }

        public byte AttributeId { get; set; }

        [Required]
        [StringLength(32)]
        public string Name { get; set; }

        public virtual ICollection<CardAttribute> CardAttributes { get; set; }
    }
}
