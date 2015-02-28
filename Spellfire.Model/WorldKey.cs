using System.ComponentModel.DataAnnotations;

namespace Spellfire.Model
{
    public enum WorldKey : byte
    {
        [Display(Name = "AD&D 2nd Ed.", ShortName = "AD&D2", Description = "add2.gif")]
        ADnD2 = 0,
        [Display(Name = "Forgotten Realms", ShortName = "FR", Description = "fr.gif")]
        ForgottenRealms = 1,
        [Display(Name = "Greyhawk", ShortName = "GH", Description = "gh.gif")]
        Greyhawk = 2,
        [Display(Name = "Ravenloft", ShortName = "RL", Description = "rl.gif")]
        Ravenloft = 3,
        [Display(Name = "Dark Sun", ShortName = "DS", Description = "ds.gif")]
        DarkSun = 4,
        [Display(Name = "DragonLance", ShortName = "DL", Description = "dl.gif")]
        DragonLance = 5,
        [Display(Name = "Birthright", ShortName = "BR", Description = "br.gif")]
        Birthright = 6,
        [Display(Name = "AD&D", ShortName = "AD&D", Description = "add.gif")]
        ADnD = 7,
        [Display(Name = "TSR", ShortName = "TSR", Description = "tsr.gif")]
        TSR = 8,
        [Display(Name = "None", ShortName = "NO", Description = "na.gif")]
        None = 9
    }
}