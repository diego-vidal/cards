using System.ComponentModel.DataAnnotations;

namespace Spellfire.Model
{
    public class UserCard
    {
        [Key]
        public int UserCardKey { get; set; }

        // Navigation
        public int UserKey { get; set; }
        public User User { get; set; }

        public int CardKey { get; set; }
        public Card Card { get; set; }
    }
}
