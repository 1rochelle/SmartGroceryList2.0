namespace SmartGroceryList2._0.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeventhMigration : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Store", "Store_StoreId", "dbo.Store");
            DropIndex("dbo.Store", new[] { "Store_StoreId" });
            DropColumn("dbo.Store", "Store_StoreId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Store", "Store_StoreId", c => c.Int());
            CreateIndex("dbo.Store", "Store_StoreId");
            AddForeignKey("dbo.Store", "Store_StoreId", "dbo.Store", "StoreId");
        }
    }
}
