namespace Spellfire.Dal
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateDatabase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Boosters",
                c => new
                    {
                        BoosterKey = c.Byte(nullable: false),
                        Name = c.String(nullable: false, maxLength: 32),
                        ShortName = c.String(nullable: false, maxLength: 3),
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
                    })
                .PrimaryKey(t => t.CardCharacteristicKey)
                .ForeignKey("dbo.Cards", t => t.CardKey, cascadeDelete: true)
                .ForeignKey("dbo.Characteristics", t => t.CharacteristicKey, cascadeDelete: true)
                .Index(t => t.CardKey)
                .Index(t => t.CharacteristicKey);
            
            CreateTable(
                "dbo.Cards",
                c => new
                    {
                        CardKey = c.Int(nullable: false, identity: true),
                        SequenceNumber = c.Int(nullable: false),
                        Number = c.Short(nullable: false),
                        NumberSet = c.Short(nullable: false),
                        Name = c.String(nullable: false, maxLength: 64),
                        Power = c.String(nullable: false, maxLength: 1024),
                        Blueline = c.String(maxLength: 256),
                        Level = c.String(nullable: false, maxLength: 4),
                        ImagePath = c.String(maxLength: 32),
                        BoosterKey = c.Byte(nullable: false),
                        RarityKey = c.Byte(nullable: false),
                        WorldKey = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.CardKey)
                .ForeignKey("dbo.Boosters", t => t.BoosterKey, cascadeDelete: true)
                .ForeignKey("dbo.Rarities", t => t.RarityKey, cascadeDelete: true)
                .ForeignKey("dbo.Worlds", t => t.WorldKey, cascadeDelete: true)
                .Index(t => t.BoosterKey)
                .Index(t => t.RarityKey)
                .Index(t => t.WorldKey);
            
            CreateTable(
                "dbo.CardKinds",
                c => new
                    {
                        CardKindKey = c.Int(nullable: false, identity: true),
                        IsIcon = c.Boolean(nullable: false),
                        CardKey = c.Int(nullable: false),
                        KindKey = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.CardKindKey)
                .ForeignKey("dbo.Cards", t => t.CardKey, cascadeDelete: true)
                .ForeignKey("dbo.Kinds", t => t.KindKey, cascadeDelete: true)
                .Index(t => t.CardKey)
                .Index(t => t.KindKey);
            
            CreateTable(
                "dbo.Kinds",
                c => new
                    {
                        KindKey = c.Byte(nullable: false),
                        Name = c.String(nullable: false, maxLength: 32),
                        IconPath = c.String(nullable: false, maxLength: 32),
                    })
                .PrimaryKey(t => t.KindKey);
            
            CreateTable(
                "dbo.CardPhases",
                c => new
                    {
                        CardPhaseKey = c.Int(nullable: false, identity: true),
                        Number = c.Byte(nullable: false),
                        CardKey = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CardPhaseKey)
                .ForeignKey("dbo.Cards", t => t.CardKey, cascadeDelete: true)
                .Index(t => t.CardKey);
            
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
                        ShortName = c.String(nullable: false, maxLength: 8),
                        ImagePath = c.String(nullable: false, maxLength: 32),
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
            DropForeignKey("dbo.Cards", "WorldKey", "dbo.Worlds");
            DropForeignKey("dbo.Cards", "RarityKey", "dbo.Rarities");
            DropForeignKey("dbo.CardPhases", "CardKey", "dbo.Cards");
            DropForeignKey("dbo.CardKinds", "KindKey", "dbo.Kinds");
            DropForeignKey("dbo.CardKinds", "CardKey", "dbo.Cards");
            DropForeignKey("dbo.CardCharacteristics", "CardKey", "dbo.Cards");
            DropForeignKey("dbo.Cards", "BoosterKey", "dbo.Boosters");
            DropIndex("dbo.CardPhases", new[] { "CardKey" });
            DropIndex("dbo.CardKinds", new[] { "KindKey" });
            DropIndex("dbo.CardKinds", new[] { "CardKey" });
            DropIndex("dbo.Cards", new[] { "WorldKey" });
            DropIndex("dbo.Cards", new[] { "RarityKey" });
            DropIndex("dbo.Cards", new[] { "BoosterKey" });
            DropIndex("dbo.CardCharacteristics", new[] { "CharacteristicKey" });
            DropIndex("dbo.CardCharacteristics", new[] { "CardKey" });
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
