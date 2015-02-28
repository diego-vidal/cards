using System.ComponentModel.DataAnnotations;

namespace Spellfire.Model
{
    public enum KindKey : byte
    {
        [Display(Name = "None", Description = "blank.gif")]
        None = 0,
        [Display(Name = "Ally", Description = "ally.gif")]
        Ally = 1,
        [Display(Name = "Artifact", Description = "artifact.gif")]
        Artifact = 2,
        [Display(Name = "Blood Ability", Description = "bloodAbility.gif")]
        BloodAbility = 3,
        [Display(Name = "Cleric Spell", Description = "clericSpell.gif")]
        ClericSpell = 4,
        [Display(Name = "Cleric", Description = "cleric.gif")]
        Cleric = 5,
        [Display(Name = "Event", Description = "event.gif")]
        Event = 6,
        [Display(Name = "Hero", Description = "hero.gif")]
        Hero = 7,
        [Display(Name = "Holding", Description = "holding.gif")]
        Holding = 8,
        [Display(Name = "Magical Item", Description = "magicalItem.gif")]
        MagicalItem = 9,
        [Display(Name = "Monster", Description = "monster.gif")]
        Monster = 10,
        [Display(Name = "Psionic Power", Description = "psionicPower.gif")]
        PsionicPower = 11,
        [Display(Name = "Psionicist", Description = "psionic.gif")]
        Psionicist = 12,
        [Display(Name = "Realm", Description = "realm.gif")]
        Realm = 13,
        [Display(Name = "Regent", Description = "regent.gif")]
        Regent = 14,
        [Display(Name = "Rule", Description = "blank.gif")]
        Rule = 15,
        [Display(Name = "Thief", Description = "thief.gif")]
        Thief = 16,
        [Display(Name = "Thief Skill", Description = "thiefSkill.gif")]
        ThiefSkill = 17,
        [Display(Name = "Unarmed Combat", Description = "unarmedCombat.gif")]
        UnarmedCombat = 18,
        [Display(Name = "Wizard Spell", Description = "wizardSpell.gif")]
        WizardSpell = 19,
        [Display(Name = "Wizard", Description = "wizard.gif")]
        Wizard = 20,
        [Display(Name = "Dungeon", Description = "blank.gif")]
        Dungeon = 21

    }
}
