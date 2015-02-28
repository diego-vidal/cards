using System.ComponentModel.DataAnnotations;

namespace Spellfire.Model
{
    public enum RarityKey : byte
    {
        [Display(Name = "None", ShortName = "NA")]
        None = 0,
        [Display(Name = "Common", ShortName = "C")]
        Common = 1,
        [Display(Name = "Uncommon", ShortName = "UC")]
        Uncommon = 2,
        [Display(Name = "Rare", ShortName = "R")]
        Rare = 3,
        [Display(Name = "Very Rare", ShortName = "VR")]
        VeryRare = 4,
        [Display(Name = "Special", ShortName = "S")]
        Special = 5,
        [Display(Name = "Virtual", ShortName = "V")]
        Virtual = 6
    }
}
