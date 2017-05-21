namespace Spellfire.Dal
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedBoosterSortOrder : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Boosters", "SortOrder", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Boosters", "SortOrder");
        }
    }
}
