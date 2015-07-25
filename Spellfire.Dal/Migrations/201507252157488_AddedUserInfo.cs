namespace Spellfire.Dal
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedUserInfo : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserCards",
                c => new
                    {
                        UserCardKey = c.Int(nullable: false, identity: true),
                        UserKey = c.Int(nullable: false),
                        CardKey = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UserCardKey)
                .ForeignKey("dbo.Cards", t => t.CardKey, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserKey, cascadeDelete: true)
                .Index(t => t.UserKey)
                .Index(t => t.CardKey);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserKey = c.Int(nullable: false, identity: true),
                        Email = c.String(nullable: false, maxLength: 256),
                        PasswordHash = c.String(nullable: false, maxLength: 384),
                        LastLogin = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.UserKey);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserCards", "UserKey", "dbo.Users");
            DropForeignKey("dbo.UserCards", "CardKey", "dbo.Cards");
            DropIndex("dbo.UserCards", new[] { "CardKey" });
            DropIndex("dbo.UserCards", new[] { "UserKey" });
            DropTable("dbo.Users");
            DropTable("dbo.UserCards");
        }
    }
}
