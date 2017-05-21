namespace Spellfire.Dal
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IncreasedLevelLength : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Cards", "Level", c => c.String(nullable: false, maxLength: 11));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Cards", "Level", c => c.String(nullable: false, maxLength: 4));
        }
    }
}
