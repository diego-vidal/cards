namespace Spellfire.Dal
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initital : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Boosters",
                c => new
                    {
                        BoosterKey = c.Byte(nullable: false),
                        Name = c.String(nullable: false, maxLength: 32),
                        ShortName = c.String(nullable: false, maxLength: 4),
                        ImagePath = c.String(maxLength: 32),
                    })
                .PrimaryKey(t => t.BoosterKey);
            
            CreateTable(
                "dbo.CardCharacteristics",
                c => new
                    {
                        CardCharacteristicKey = c.Int(nullable: false, identity: true),
                        CardKey = c.Int(nullable: false),
                        CharacteristicKey = c.Byte(nullable: false),
                        Card_CardKey = c.Int(),
                        Card_CardKey1 = c.Int(),
                    })
                .PrimaryKey(t => t.CardCharacteristicKey)
                .ForeignKey("dbo.Cards", t => t.Card_CardKey)
                .ForeignKey("dbo.Cards", t => t.Card_CardKey1)
                .ForeignKey("dbo.Characteristics", t => t.CharacteristicKey, cascadeDelete: true)
                .Index(t => t.CharacteristicKey)
                .Index(t => t.Card_CardKey)
                .Index(t => t.Card_CardKey1);
            
            CreateTable(
                "dbo.Cards",
                c => new
                    {
                        CardKey = c.Int(nullable: false, identity: true),
                        BoosterKey = c.Byte(nullable: false),
                        KindKey = c.Byte(nullable: false),
                        CharacteristicKey = c.Byte(nullable: false),
                        CardPhaseKey = c.Int(nullable: false),
                        RarityKey = c.Byte(nullable: false),
                        WorldKey = c.Byte(nullable: false),
                        SequenceNumber = c.Int(nullable: false),
                        Number = c.Short(nullable: false),
                        NumberSet = c.Short(nullable: false),
                        Name = c.String(nullable: false, maxLength: 64),
                        Power = c.String(nullable: false, maxLength: 1024),
                        Blueline = c.String(maxLength: 256),
                        Level = c.String(nullable: false, maxLength: 4),
                        ImagePath = c.String(maxLength: 32),
                        CardCharacteristic_CardCharacteristicKey = c.Int(),
                        CardKind_CardKindKey = c.Int(),
                        CardPhase_CardPhaseKey = c.Int(),
                    })
                .PrimaryKey(t => t.CardKey)
                .ForeignKey("dbo.Boosters", t => t.BoosterKey, cascadeDelete: true)
                .ForeignKey("dbo.CardCharacteristics", t => t.CardCharacteristic_CardCharacteristicKey)
                .ForeignKey("dbo.CardKinds", t => t.CardKind_CardKindKey)
                .ForeignKey("dbo.CardPhases", t => t.CardPhase_CardPhaseKey)
                .ForeignKey("dbo.Rarities", t => t.RarityKey, cascadeDelete: true)
                .ForeignKey("dbo.Worlds", t => t.WorldKey, cascadeDelete: true)
                .Index(t => t.BoosterKey)
                .Index(t => t.RarityKey)
                .Index(t => t.WorldKey)
                .Index(t => t.CardCharacteristic_CardCharacteristicKey)
                .Index(t => t.CardKind_CardKindKey)
                .Index(t => t.CardPhase_CardPhaseKey);
            
            CreateTable(
                "dbo.CardKinds",
                c => new
                    {
                        CardKindKey = c.Int(nullable: false, identity: true),
                        CardKey = c.Int(nullable: false),
                        KindKey = c.Byte(nullable: false),
                        IsIcon = c.Boolean(nullable: false),
                        Card_CardKey = c.Int(),
                        Card_CardKey1 = c.Int(),
                    })
                .PrimaryKey(t => t.CardKindKey)
                .ForeignKey("dbo.Cards", t => t.Card_CardKey)
                .ForeignKey("dbo.Kinds", t => t.KindKey, cascadeDelete: true)
                .ForeignKey("dbo.Cards", t => t.Card_CardKey1)
                .Index(t => t.KindKey)
                .Index(t => t.Card_CardKey)
                .Index(t => t.Card_CardKey1);
            
            CreateTable(
                "dbo.Kinds",
                c => new
                    {
                        KindKey = c.Byte(nullable: false),
                        Name = c.String(nullable: false, maxLength: 50),
                        Icon = c.String(nullable: false, maxLength: 25),
                    })
                .PrimaryKey(t => t.KindKey);
            
            CreateTable(
                "dbo.CardPhases",
                c => new
                    {
                        CardPhaseKey = c.Int(nullable: false, identity: true),
                        CardKey = c.Int(nullable: false),
                        Number = c.Byte(nullable: false),
                        Card_CardKey = c.Int(),
                        Card_CardKey1 = c.Int(),
                    })
                .PrimaryKey(t => t.CardPhaseKey)
                .ForeignKey("dbo.Cards", t => t.Card_CardKey)
                .ForeignKey("dbo.Cards", t => t.Card_CardKey1)
                .Index(t => t.Card_CardKey)
                .Index(t => t.Card_CardKey1);
            
            CreateTable(
                "dbo.Rarities",
                c => new
                    {
                        RarityKey = c.Byte(nullable: false),
                        Name = c.String(nullable: false, maxLength: 16),
                        ShortName = c.String(nullable: false, maxLength: 2),
                    })
                .PrimaryKey(t => t.RarityKey);
            
            CreateTable(
                "dbo.Worlds",
                c => new
                    {
                        WorldKey = c.Byte(nullable: false),
                        Name = c.String(nullable: false, maxLength: 32),
                        ShortName = c.String(nullable: false, maxLength: 5),
                        ImagePath = c.String(maxLength: 32),
                    })
                .PrimaryKey(t => t.WorldKey);
            
            CreateTable(
                "dbo.Characteristics",
                c => new
                    {
                        CharacteristicKey = c.Byte(nullable: false),
                        Name = c.String(nullable: false, maxLength: 32),
                    })
                .PrimaryKey(t => t.CharacteristicKey);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CardCharacteristics", "CharacteristicKey", "dbo.Characteristics");
            DropForeignKey("dbo.CardCharacteristics", "Card_CardKey1", "dbo.Cards");
            DropForeignKey("dbo.Cards", "WorldKey", "dbo.Worlds");
            DropForeignKey("dbo.Cards", "RarityKey", "dbo.Rarities");
            DropForeignKey("dbo.CardPhases", "Card_CardKey1", "dbo.Cards");
            DropForeignKey("dbo.Cards", "CardPhase_CardPhaseKey", "dbo.CardPhases");
            DropForeignKey("dbo.CardPhases", "Card_CardKey", "dbo.Cards");
            DropForeignKey("dbo.CardKinds", "Card_CardKey1", "dbo.Cards");
            DropForeignKey("dbo.Cards", "CardKind_CardKindKey", "dbo.CardKinds");
            DropForeignKey("dbo.CardKinds", "KindKey", "dbo.Kinds");
            DropForeignKey("dbo.CardKinds", "Card_CardKey", "dbo.Cards");
            DropForeignKey("dbo.CardCharacteristics", "Card_CardKey", "dbo.Cards");
            DropForeignKey("dbo.Cards", "CardCharacteristic_CardCharacteristicKey", "dbo.CardCharacteristics");
            DropForeignKey("dbo.Cards", "BoosterKey", "dbo.Boosters");
            DropIndex("dbo.CardPhases", new[] { "Card_CardKey1" });
            DropIndex("dbo.CardPhases", new[] { "Card_CardKey" });
            DropIndex("dbo.CardKinds", new[] { "Card_CardKey1" });
            DropIndex("dbo.CardKinds", new[] { "Card_CardKey" });
            DropIndex("dbo.CardKinds", new[] { "KindKey" });
            DropIndex("dbo.Cards", new[] { "CardPhase_CardPhaseKey" });
            DropIndex("dbo.Cards", new[] { "CardKind_CardKindKey" });
            DropIndex("dbo.Cards", new[] { "CardCharacteristic_CardCharacteristicKey" });
            DropIndex("dbo.Cards", new[] { "WorldKey" });
            DropIndex("dbo.Cards", new[] { "RarityKey" });
            DropIndex("dbo.Cards", new[] { "BoosterKey" });
            DropIndex("dbo.CardCharacteristics", new[] { "Card_CardKey1" });
            DropIndex("dbo.CardCharacteristics", new[] { "Card_CardKey" });
            DropIndex("dbo.CardCharacteristics", new[] { "CharacteristicKey" });
            DropTable("dbo.Characteristics");
            DropTable("dbo.Worlds");
            DropTable("dbo.Rarities");
            DropTable("dbo.CardPhases");
            DropTable("dbo.Kinds");
            DropTable("dbo.CardKinds");
            DropTable("dbo.Cards");
            DropTable("dbo.CardCharacteristics");
            DropTable("dbo.Boosters");
        }
    }
}
