namespace Spellfire.Model
{
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("CardType")]
    public partial class CardType
    {
        public int CardTypeId { get; set; }

        public int CardId { get; set; }

        public byte TypeId { get; set; }

        public bool IsIcon { get; set; }

        public virtual Card Card { get; set; }

        public virtual Type Type { get; set; }
    }
}
