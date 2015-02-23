namespace Spellfire.Model
{
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("CardAttribute")]
    public partial class CardAttribute
    {
        public int CardAttributeId { get; set; }

        public int CardId { get; set; }

        public byte AttributeId { get; set; }

        public virtual Attribute Attribute { get; set; }

        public virtual Card Card { get; set; }
    }
}
