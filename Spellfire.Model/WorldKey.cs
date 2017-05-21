using System.ComponentModel.DataAnnotations;

namespace Spellfire.Model
{
    public enum WorldKey : byte
    {
        [Display(Name = "AD&D 2nd Ed.", ShortName = "add2", Description = "add2.png")]
        ADnD2 = 0,
        [Display(Name = "Forgotten Realms", ShortName = "fr", Description = "fr.png")]
        ForgottenRealms = 1,
        [Display(Name = "Greyhawk", ShortName = "gh", Description = "gh.png")]
        Greyhawk = 2,
        [Display(Name = "Ravenloft", ShortName = "rl", Description = "rl.png")]
        Ravenloft = 3,
        [Display(Name = "Dark Sun", ShortName = "ds", Description = "ds.png")]
        DarkSun = 4,
        [Display(Name = "DragonLance", ShortName = "dl", Description = "dl.png")]
        DragonLance = 5,
        [Display(Name = "Birthright", ShortName = "br", Description = "br.png")]
        Birthright = 6,
        [Display(Name = "AD&D", ShortName = "add", Description = "add.png")]
        ADnD = 7,
        [Display(Name = "TSR", ShortName = "tsr", Description = "tsr.png")]
        TSR = 8,
        [Display(Name = "None", ShortName = "no", Description = "blank.gif")]
        None = 9
    }
}