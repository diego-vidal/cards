namespace Spellfire.Model
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Type")]
    public partial class Type
    {
        public Type()
        {
            CardTypes = new HashSet<CardType>();
        }

        public byte TypeId { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [StringLength(25)]
        public string Icon { get; set; }

        public virtual ICollection<CardType> CardTypes { get; set; }
    }
}
