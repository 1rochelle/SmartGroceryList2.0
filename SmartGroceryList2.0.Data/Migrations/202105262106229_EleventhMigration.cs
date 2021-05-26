namespace SmartGroceryList2._0.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EleventhMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ShoppingList", "OwnerId", c => c.Guid(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ShoppingList", "OwnerId");
        }
    }
}
