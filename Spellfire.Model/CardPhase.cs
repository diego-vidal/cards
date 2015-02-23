namespace Spellfire.Model
{
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("CardPhase")]
    public partial class CardPhase
    {
        public int CardPhaseId { get; set; }

        public int CardId { get; set; }

        public byte Number { get; set; }

        public virtual Card Card { get; set; }
    }
}
