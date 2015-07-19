using System.ComponentModel.DataAnnotations;

namespace Spellfire.Model
{
    public enum WorldKey : byte
    {
        [Display(Name = "AD&D 2nd Ed.", ShortName = "AD&D2", Description = "add2.png")]
        ADnD2 = 0,
        [Display(Name = "Forgotten Realms", ShortName = "FR", Description = "fr.png")]
        ForgottenRealms = 1,
        [Display(Name = "Greyhawk", ShortName = "GH", Description = "gh.png")]
        Greyhawk = 2,
        [Display(Name = "Ravenloft", ShortName = "RL", Description = "rl.png")]
        Ravenloft = 3,
        [Display(Name = "Dark Sun", ShortName = "DS", Description = "ds.png")]
        DarkSun = 4,
        [Display(Name = "DragonLance", ShortName = "DL", Description = "dl.png")]
        DragonLance = 5,
        [Display(Name = "Birthright", ShortName = "BR", Description = "br.png")]
        Birthright = 6,
        [Display(Name = "AD&D", ShortName = "AD&D", Description = "add.png")]
        ADnD = 7,
        [Display(Name = "TSR", ShortName = "TSR", Description = "tsr.png")]
        TSR = 8,
        [Display(Name = "None", ShortName = "NO", Description = "blank.gif")]
        None = 9
    }
}