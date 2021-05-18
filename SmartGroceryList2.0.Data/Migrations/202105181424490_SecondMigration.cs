namespace SmartGroceryList2._0.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SecondMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customer", "PurchaseDate", c => c.DateTimeOffset(nullable: false, precision: 7));
            AddColumn("dbo.Product", "OwnerId", c => c.Guid(nullable: false));
            AddColumn("dbo.Product", "ModifiedUtc", c => c.DateTimeOffset(nullable: false, precision: 7));
            AlterColumn("dbo.Store", "StoreAddressNumber", c => c.String(nullable: false));
            DropColumn("dbo.Product", "ItemId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Product", "ItemId", c => c.Guid(nullable: false));
            AlterColumn("dbo.Store", "StoreAddressNumber", c => c.Int(nullable: false));
            DropColumn("dbo.Product", "ModifiedUtc");
            DropColumn("dbo.Product", "OwnerId");
            DropColumn("dbo.Customer", "PurchaseDate");
        }
    }
}
