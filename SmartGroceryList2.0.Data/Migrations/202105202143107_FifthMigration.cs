namespace SmartGroceryList2._0.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FifthMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ShoppingList", "OwnerId", c => c.Guid(nullable: false));
            DropColumn("dbo.Product", "Price");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Product", "Price", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            DropColumn("dbo.ShoppingList", "OwnerId");
        }
    }
}
