namespace Spellfire.Dal
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddLogging : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Logs",
                c => new
                    {
                        LogKey = c.Int(nullable: false, identity: true),
                        Timestamp = c.DateTime(nullable: false),
                        Username = c.String(nullable: false, maxLength: 50),
                        Title = c.String(nullable: false, maxLength: 50),
                        Description = c.String(nullable: false, maxLength: 4000),
                    })
                .PrimaryKey(t => t.LogKey);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Logs");
        }
    }
}
