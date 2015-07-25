using System;
using System.ComponentModel.DataAnnotations;

namespace Spellfire.Model
{
    public class User
    {
        [Key]
        public int UserKey { get; set; }
        [Required, StringLength(256)]
        public string Email { get; set; }
        [Required, StringLength(384)]
        public string PasswordHash { get; set; }
        [Required]
        public DateTime LastLogin { get; set; }
    }
}
