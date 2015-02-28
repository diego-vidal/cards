using Spellfire.Common.Extensions;
using Spellfire.Model;
using System.Data.Entity.Migrations;

namespace Spellfire.Dal
{
    internal sealed class Configuration : DbMigrationsConfiguration<SpellfireContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            CommandTimeout = 600;
        }

        protected override void Seed(SpellfireContext context)
        {
            SeedAttributeLookup(context);
            SeedBoosterLookup(context);
            SeedRarityLookup(context);
            SeedTypeLookup(context);
            SeedWorldLookup(context);

            context.SaveChanges();
            //base.Seed(context);
        }

        private void SeedAttributeLookup(SpellfireContext context)
        {
            context.Characteristics.AddOrUpdate(
                x => x.CharacteristicKey,
                new Characteristic { CharacteristicKey = CharacteristicKey.Adventurer, Name = CharacteristicKey.Adventurer.GetDisplayName() },
                new Characteristic { CharacteristicKey = CharacteristicKey.Avatar, Name = CharacteristicKey.Avatar.GetDisplayName() },
                new Characteristic { CharacteristicKey = CharacteristicKey.Awnshegh, Name = CharacteristicKey.Awnshegh.GetDisplayName() },
                new Characteristic { CharacteristicKey = CharacteristicKey.Beholder, Name = CharacteristicKey.Beholder.GetDisplayName() },
                new Characteristic { CharacteristicKey = CharacteristicKey.BlackWizard, Name = CharacteristicKey.BlackWizard.GetDisplayName() },
                new Characteristic { CharacteristicKey = CharacteristicKey.Champion, Name = CharacteristicKey.Champion.GetDisplayName() },
                new Characteristic { CharacteristicKey = CharacteristicKey.Coastal, Name = CharacteristicKey.Coastal.GetDisplayName() },
                new Characteristic { CharacteristicKey = CharacteristicKey.Defensive, Name = CharacteristicKey.Defensive.GetDisplayName() },
                new Characteristic { CharacteristicKey = CharacteristicKey.Draconian, Name = CharacteristicKey.Draconian.GetDisplayName() },
                new Characteristic { CharacteristicKey = CharacteristicKey.Dragon, Name = CharacteristicKey.Dragon.GetDisplayName() },
                new Characteristic { CharacteristicKey = CharacteristicKey.DragonUnarmedCombat, Name = CharacteristicKey.DragonUnarmedCombat.GetDisplayName() },
                new Characteristic { CharacteristicKey = CharacteristicKey.Drow, Name = CharacteristicKey.Drow.GetDisplayName() },
                new Characteristic { CharacteristicKey = CharacteristicKey.Duergar, Name = CharacteristicKey.Duergar.GetDisplayName() },
                new Characteristic { CharacteristicKey = CharacteristicKey.Dwarf, Name = CharacteristicKey.Dwarf.GetDisplayName() },
                new Characteristic { CharacteristicKey = CharacteristicKey.Earthwalker, Name = CharacteristicKey.Earthwalker.GetDisplayName() },
                new Characteristic { CharacteristicKey = CharacteristicKey.Elf, Name = CharacteristicKey.Elf.GetDisplayName() },
                new Characteristic { CharacteristicKey = CharacteristicKey.Familiar, Name = CharacteristicKey.Familiar.GetDisplayName() },
                new Characteristic { CharacteristicKey = CharacteristicKey.Flyer, Name = CharacteristicKey.Flyer.GetDisplayName() },
                new Characteristic { CharacteristicKey = CharacteristicKey.Giant, Name = CharacteristicKey.Giant.GetDisplayName() },
                new Characteristic { CharacteristicKey = CharacteristicKey.Gnome, Name = CharacteristicKey.Gnome.GetDisplayName() },
                new Characteristic { CharacteristicKey = CharacteristicKey.Golem, Name = CharacteristicKey.Golem.GetDisplayName() },
                new Characteristic { CharacteristicKey = CharacteristicKey.HalfElf, Name = CharacteristicKey.HalfElf.GetDisplayName() },
                new Characteristic { CharacteristicKey = CharacteristicKey.Halfling, Name = CharacteristicKey.Halfling.GetDisplayName() },
                new Characteristic { CharacteristicKey = CharacteristicKey.Harmful, Name = CharacteristicKey.Harmful.GetDisplayName() },
                new Characteristic { CharacteristicKey = CharacteristicKey.Helpful, Name = CharacteristicKey.Helpful.GetDisplayName() },
                new Characteristic { CharacteristicKey = CharacteristicKey.Kender, Name = CharacteristicKey.Kender.GetDisplayName() },
                new Characteristic { CharacteristicKey = CharacteristicKey.Kobold, Name = CharacteristicKey.Kobold.GetDisplayName() },
                new Characteristic { CharacteristicKey = CharacteristicKey.Mul, Name = CharacteristicKey.Mul.GetDisplayName() },
                new Characteristic { CharacteristicKey = CharacteristicKey.Offensive, Name = CharacteristicKey.Offensive.GetDisplayName() },
                new Characteristic { CharacteristicKey = CharacteristicKey.Orc, Name = CharacteristicKey.Orc.GetDisplayName() },
                new Characteristic { CharacteristicKey = CharacteristicKey.RedWizard, Name = CharacteristicKey.RedWizard.GetDisplayName() },
                new Characteristic { CharacteristicKey = CharacteristicKey.Spear, Name = CharacteristicKey.Spear.GetDisplayName() },
                new Characteristic { CharacteristicKey = CharacteristicKey.Svirfneblin, Name = CharacteristicKey.Svirfneblin.GetDisplayName() },
                new Characteristic { CharacteristicKey = CharacteristicKey.Swimmer, Name = CharacteristicKey.Swimmer.GetDisplayName() },
                new Characteristic { CharacteristicKey = CharacteristicKey.Sword, Name = CharacteristicKey.Sword.GetDisplayName() },
                new Characteristic { CharacteristicKey = CharacteristicKey.Undead, Name = CharacteristicKey.Undead.GetDisplayName() },
                new Characteristic { CharacteristicKey = CharacteristicKey.UndeadUnarmedCombat, Name = CharacteristicKey.UndeadUnarmedCombat.GetDisplayName() },
                new Characteristic { CharacteristicKey = CharacteristicKey.Underdark, Name = CharacteristicKey.Underdark.GetDisplayName() },
                new Characteristic { CharacteristicKey = CharacteristicKey.UseBloodAbility, Name = CharacteristicKey.UseBloodAbility.GetDisplayName() },
                new Characteristic { CharacteristicKey = CharacteristicKey.UseClericSpell, Name = CharacteristicKey.UseClericSpell.GetDisplayName() },
                new Characteristic { CharacteristicKey = CharacteristicKey.UseDragonUnarmedCombat, Name = CharacteristicKey.UseDragonUnarmedCombat.GetDisplayName() },
                new Characteristic { CharacteristicKey = CharacteristicKey.UsePsionicPower, Name = CharacteristicKey.UsePsionicPower.GetDisplayName() },
                new Characteristic { CharacteristicKey = CharacteristicKey.UseThiefSkill, Name = CharacteristicKey.UseThiefSkill.GetDisplayName() },
                new Characteristic { CharacteristicKey = CharacteristicKey.UseUnarmedCombat, Name = CharacteristicKey.UseUnarmedCombat.GetDisplayName() },
                new Characteristic { CharacteristicKey = CharacteristicKey.UseUndeadUnarmedCombat, Name = CharacteristicKey.UseUndeadUnarmedCombat.GetDisplayName() },
                new Characteristic { CharacteristicKey = CharacteristicKey.UseWizardSpell, Name = CharacteristicKey.UseWizardSpell.GetDisplayName() },
                new Characteristic { CharacteristicKey = CharacteristicKey.Vampire, Name = CharacteristicKey.Vampire.GetDisplayName() },
                new Characteristic { CharacteristicKey = CharacteristicKey.Weapon, Name = CharacteristicKey.Weapon.GetDisplayName() },
                new Characteristic { CharacteristicKey = CharacteristicKey.Werebeast, Name = CharacteristicKey.Werebeast.GetDisplayName() },
                new Characteristic { CharacteristicKey = CharacteristicKey.WhiteWizard, Name = CharacteristicKey.WhiteWizard.GetDisplayName() }
            );
        }

        private void SeedBoosterLookup(SpellfireContext context)
        {
            context.Boosters.AddOrUpdate(
                x => x.BoosterKey,
                    new Booster { BoosterKey = BoosterKey.NoEdition, ShortName = BoosterKey.NoEdition.GetDisplayShortName(), Name = BoosterKey.NoEdition.GetDisplayName() },
                    new Booster { BoosterKey = BoosterKey.FirstEdition, ShortName = BoosterKey.FirstEdition.GetDisplayShortName(), Name = BoosterKey.FirstEdition.GetDisplayName() },
                    new Booster { BoosterKey = BoosterKey.SecondEdition, ShortName = BoosterKey.SecondEdition.GetDisplayShortName(), Name = BoosterKey.SecondEdition.GetDisplayName() },
                    new Booster { BoosterKey = BoosterKey.ThirdEdition, ShortName = BoosterKey.ThirdEdition.GetDisplayShortName(), Name = BoosterKey.ThirdEdition.GetDisplayName() },
                    new Booster { BoosterKey = BoosterKey.FourthEdition, ShortName = BoosterKey.FourthEdition.GetDisplayShortName(), Name = BoosterKey.FourthEdition.GetDisplayName() },
                    new Booster { BoosterKey = BoosterKey.Promo, ShortName = BoosterKey.Promo.GetDisplayShortName(), Name = BoosterKey.Promo.GetDisplayName() },
                    new Booster { BoosterKey = BoosterKey.Ravenloft, ShortName = BoosterKey.Ravenloft.GetDisplayShortName(), Name = BoosterKey.Ravenloft.GetDisplayName() },
                    new Booster { BoosterKey = BoosterKey.DragonLance, ShortName = BoosterKey.DragonLance.GetDisplayShortName(), Name = BoosterKey.DragonLance.GetDisplayName() },
                    new Booster { BoosterKey = BoosterKey.ForgottenRealms, ShortName = BoosterKey.ForgottenRealms.GetDisplayShortName(), Name = BoosterKey.ForgottenRealms.GetDisplayName() },
                    new Booster { BoosterKey = BoosterKey.Artifacts, ShortName = BoosterKey.Artifacts.GetDisplayShortName(), Name = BoosterKey.Artifacts.GetDisplayName() },
                    new Booster { BoosterKey = BoosterKey.Powers, ShortName = BoosterKey.Powers.GetDisplayShortName(), Name = BoosterKey.Powers.GetDisplayName() },
                    new Booster { BoosterKey = BoosterKey.TheUnderdark, ShortName = BoosterKey.TheUnderdark.GetDisplayShortName(), Name = BoosterKey.TheUnderdark.GetDisplayName() },
                    new Booster { BoosterKey = BoosterKey.RunesAndRuins, ShortName = BoosterKey.RunesAndRuins.GetDisplayShortName(), Name = BoosterKey.RunesAndRuins.GetDisplayName() },
                    new Booster { BoosterKey = BoosterKey.Birthright, ShortName = BoosterKey.Birthright.GetDisplayShortName(), Name = BoosterKey.Birthright.GetDisplayName() },
                    new Booster { BoosterKey = BoosterKey.Draconomicon, ShortName = BoosterKey.Draconomicon.GetDisplayShortName(), Name = BoosterKey.Draconomicon.GetDisplayName() },
                    new Booster { BoosterKey = BoosterKey.NightStalkers, ShortName = BoosterKey.NightStalkers.GetDisplayShortName(), Name = BoosterKey.NightStalkers.GetDisplayName() },
                    new Booster { BoosterKey = BoosterKey.Dungeons, ShortName = BoosterKey.Dungeons.GetDisplayShortName(), Name = BoosterKey.Dungeons.GetDisplayName() },
                    new Booster { BoosterKey = BoosterKey.Inquisition, ShortName = BoosterKey.Inquisition.GetDisplayShortName(), Name = BoosterKey.Inquisition.GetDisplayName() },
                    new Booster { BoosterKey = BoosterKey.Millennium, ShortName = BoosterKey.Millennium.GetDisplayShortName(), Name = BoosterKey.Millennium.GetDisplayName() },
                    new Booster { BoosterKey = BoosterKey.Chaos, ShortName = BoosterKey.Chaos.GetDisplayShortName(), Name = BoosterKey.Chaos.GetDisplayName() },
                    new Booster { BoosterKey = BoosterKey.Conquest, ShortName = BoosterKey.Conquest.GetDisplayShortName(), Name = BoosterKey.Conquest.GetDisplayName() }
                );
        }

        private void SeedRarityLookup(SpellfireContext context)
        {
            context.Rarities.AddOrUpdate(
                x => x.RarityKey,
                 new Rarity { RarityKey = RarityKey.None, ShortName = RarityKey.None.GetDisplayShortName(), Name = RarityKey.None.GetDisplayName() },
                 new Rarity { RarityKey = RarityKey.Common, ShortName = RarityKey.Common.GetDisplayShortName(), Name = RarityKey.Common.GetDisplayName() },
                 new Rarity { RarityKey = RarityKey.Uncommon, ShortName = RarityKey.Uncommon.GetDisplayShortName(), Name = RarityKey.Uncommon.GetDisplayName() },
                 new Rarity { RarityKey = RarityKey.Rare, ShortName = RarityKey.Rare.GetDisplayShortName(), Name = RarityKey.Rare.GetDisplayName() },
                 new Rarity { RarityKey = RarityKey.VeryRare, ShortName = RarityKey.VeryRare.GetDisplayShortName(), Name = RarityKey.VeryRare.GetDisplayName() },
                 new Rarity { RarityKey = RarityKey.Special, ShortName = RarityKey.Special.GetDisplayShortName(), Name = RarityKey.Special.GetDisplayName() },
                 new Rarity { RarityKey = RarityKey.Virtual, ShortName = RarityKey.Virtual.GetDisplayShortName(), Name = RarityKey.Virtual.GetDisplayName() }
            );
        }

        private void SeedTypeLookup(SpellfireContext context)
        {
            context.Kinds.AddOrUpdate(
                x => x.KindKey,
                    new Kind { KindKey = KindKey.None, Icon = KindKey.None.GetDisplayDescription(), Name = KindKey.None.GetDisplayName() },
                    new Kind { KindKey = KindKey.Ally, Icon = KindKey.Ally.GetDisplayDescription(), Name = KindKey.Ally.GetDisplayName() },
                    new Kind { KindKey = KindKey.Artifact, Icon = KindKey.Artifact.GetDisplayDescription(), Name = KindKey.Artifact.GetDisplayName() },
                    new Kind { KindKey = KindKey.BloodAbility, Icon = KindKey.BloodAbility.GetDisplayDescription(), Name = KindKey.BloodAbility.GetDisplayName() },
                    new Kind { KindKey = KindKey.ClericSpell, Icon = KindKey.ClericSpell.GetDisplayDescription(), Name = KindKey.ClericSpell.GetDisplayName() },
                    new Kind { KindKey = KindKey.Cleric, Icon = KindKey.Cleric.GetDisplayDescription(), Name = KindKey.Cleric.GetDisplayName() },
                    new Kind { KindKey = KindKey.Event, Icon = KindKey.Event.GetDisplayDescription(), Name = KindKey.Event.GetDisplayName() },
                    new Kind { KindKey = KindKey.Hero, Icon = KindKey.Hero.GetDisplayDescription(), Name = KindKey.Hero.GetDisplayName() },
                    new Kind { KindKey = KindKey.Holding, Icon = KindKey.Holding.GetDisplayDescription(), Name = KindKey.Holding.GetDisplayName() },
                    new Kind { KindKey = KindKey.MagicalItem, Icon = KindKey.MagicalItem.GetDisplayDescription(), Name = KindKey.MagicalItem.GetDisplayName() },
                    new Kind { KindKey = KindKey.Monster, Icon = KindKey.Monster.GetDisplayDescription(), Name = KindKey.Monster.GetDisplayName() },
                    new Kind { KindKey = KindKey.PsionicPower, Icon = KindKey.PsionicPower.GetDisplayDescription(), Name = KindKey.PsionicPower.GetDisplayName() },
                    new Kind { KindKey = KindKey.Psionicist, Icon = KindKey.Psionicist.GetDisplayDescription(), Name = KindKey.Psionicist.GetDisplayName() },
                    new Kind { KindKey = KindKey.Realm, Icon = KindKey.Realm.GetDisplayDescription(), Name = KindKey.Realm.GetDisplayName() },
                    new Kind { KindKey = KindKey.Regent, Icon = KindKey.Regent.GetDisplayDescription(), Name = KindKey.Regent.GetDisplayName() },
                    new Kind { KindKey = KindKey.Rule, Icon = KindKey.Rule.GetDisplayDescription(), Name = KindKey.Rule.GetDisplayName() },
                    new Kind { KindKey = KindKey.Thief, Icon = KindKey.Thief.GetDisplayDescription(), Name = KindKey.Thief.GetDisplayName() },
                    new Kind { KindKey = KindKey.ThiefSkill, Icon = KindKey.ThiefSkill.GetDisplayDescription(), Name = KindKey.ThiefSkill.GetDisplayName() },
                    new Kind { KindKey = KindKey.UnarmedCombat, Icon = KindKey.UnarmedCombat.GetDisplayDescription(), Name = KindKey.UnarmedCombat.GetDisplayName() },
                    new Kind { KindKey = KindKey.WizardSpell, Icon = KindKey.WizardSpell.GetDisplayDescription(), Name = KindKey.WizardSpell.GetDisplayName() },
                    new Kind { KindKey = KindKey.Wizard, Icon = KindKey.Wizard.GetDisplayDescription(), Name = KindKey.Wizard.GetDisplayName() },
                    new Kind { KindKey = KindKey.Dungeon, Icon = KindKey.Dungeon.GetDisplayDescription(), Name = KindKey.Dungeon.GetDisplayName() }
                 );
        }

        private void SeedWorldLookup(SpellfireContext context)
        {
            context.Worlds.AddOrUpdate(
                x => x.WorldKey,
                    new World { WorldKey = WorldKey.ADnD2, ShortName = WorldKey.ADnD2.GetDisplayShortName(), Name = WorldKey.ADnD2.GetDisplayName(), ImagePath = WorldKey.ADnD2.GetDisplayDescription() },
                    new World { WorldKey = WorldKey.ForgottenRealms, ShortName = WorldKey.ForgottenRealms.GetDisplayShortName(), Name = WorldKey.ForgottenRealms.GetDisplayName(), ImagePath = WorldKey.ForgottenRealms.GetDisplayDescription() },
                    new World { WorldKey = WorldKey.Greyhawk, ShortName = WorldKey.Greyhawk.GetDisplayShortName(), Name = WorldKey.Greyhawk.GetDisplayName(), ImagePath = WorldKey.Greyhawk.GetDisplayDescription() },
                    new World { WorldKey = WorldKey.Ravenloft, ShortName = WorldKey.Ravenloft.GetDisplayShortName(), Name = WorldKey.Ravenloft.GetDisplayName(), ImagePath = WorldKey.Ravenloft.GetDisplayDescription() },
                    new World { WorldKey = WorldKey.DarkSun, ShortName = WorldKey.DarkSun.GetDisplayShortName(), Name = WorldKey.DarkSun.GetDisplayName(), ImagePath = WorldKey.DarkSun.GetDisplayDescription() },
                    new World { WorldKey = WorldKey.DragonLance, ShortName = WorldKey.DragonLance.GetDisplayShortName(), Name = WorldKey.DragonLance.GetDisplayName(), ImagePath = WorldKey.DragonLance.GetDisplayDescription() },
                    new World { WorldKey = WorldKey.Birthright, ShortName = WorldKey.Birthright.GetDisplayShortName(), Name = WorldKey.Birthright.GetDisplayName(), ImagePath = WorldKey.Birthright.GetDisplayDescription() },
                    new World { WorldKey = WorldKey.ADnD, ShortName = WorldKey.ADnD.GetDisplayShortName(), Name = WorldKey.ADnD.GetDisplayName(), ImagePath = WorldKey.ADnD.GetDisplayDescription() },
                    new World { WorldKey = WorldKey.TSR, ShortName = WorldKey.TSR.GetDisplayShortName(), Name = WorldKey.TSR.GetDisplayName(), ImagePath = WorldKey.TSR.GetDisplayDescription() },
                    new World { WorldKey = WorldKey.None, ShortName = WorldKey.None.GetDisplayShortName(), Name = WorldKey.None.GetDisplayName(), ImagePath = WorldKey.None.GetDisplayDescription() }
                );
        }
    }
}
