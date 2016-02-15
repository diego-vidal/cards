using System.ComponentModel.DataAnnotations;

namespace Spellfire.Model
{
    public enum BoosterKey : byte
    {
        [Display(Name = "No Edition", ShortName = "NO")]
        NoEdition = 0,
        [Display(Name = "1st Edition", ShortName = "1st")]
        FirstEdition = 1,
        [Display(Name = "2nd Edition", ShortName = "2nd")]
        SecondEdition = 2,
        [Display(Name = "3rd Edition", ShortName = "3rd")]
        ThirdEdition = 3,
        [Display(Name = "4th Edition", ShortName = "4th")]
        FourthEdition = 4,
        [Display(Name = "Promo", ShortName = "PR")]
        Promo = 5,
        [Display(Name = "Ravenloft", ShortName = "RL")]
        Ravenloft = 6,
        [Display(Name = "DragonLance", ShortName = "DL")]
        DragonLance = 7,
        [Display(Name = "Forgotten Realms", ShortName = "FR")]
        ForgottenRealms = 8,
        [Display(Name = "Artifacts", ShortName = "AR")]
        Artifacts = 9,
        [Display(Name = "Powers", ShortName = "PO")]
        Powers = 10,
        [Display(Name = "The Underdark", ShortName = "TU")]
        TheUnderdark = 11,
        [Display(Name = "Runes & Ruins", ShortName = "RR")]
        RunesAndRuins = 12,
        [Display(Name = "Birthright", ShortName = "BR")]
        Birthright = 13,
        [Display(Name = "Draconomicon", ShortName = "DR")]
        Draconomicon = 14,
        [Display(Name = "Night Stalkers", ShortName = "NS")]
        NightStalkers = 15,
        [Display(Name = "Dungeons", ShortName = "DU")]
        Dungeons = 16,
        [Display(Name = "Inquisition", ShortName = "IQ")]
        Inquisition = 17,
        [Display(Name = "Millennium", ShortName = "MI")]
        Millennium = 18,
        [Display(Name = "Chaos", ShortName = "CH")]
        Chaos = 19,
        [Display(Name = "Conquest", ShortName = "CQ")]
        Conquest = 20,

        None = 21,
    }
}
