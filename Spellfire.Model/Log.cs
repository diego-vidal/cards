using System.ComponentModel.DataAnnotations;
using System;

namespace Spellfire.Model
{
    public class Log
    {
        [Key]
        public int LogKey { get; set; }

        [Required]
        public DateTime Timestamp { get; set; }
        [Required, MaxLength(50)]
        public string Username { get; set; }
        [Required, MaxLength(50)]
        public string Title { get; set; }
        [Required, MaxLength(4000)]
        public string Description { get; set; }
    }
}
