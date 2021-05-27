namespace SmartGroceryList2._0.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedStoreIdToCustomerTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customer", "StoreId", c => c.Int(nullable: false));
            CreateIndex("dbo.Customer", "StoreId");
            AddForeignKey("dbo.Customer", "StoreId", "dbo.Store", "StoreId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Customer", "StoreId", "dbo.Store");
            DropIndex("dbo.Customer", new[] { "StoreId" });
            DropColumn("dbo.Customer", "StoreId");
        }
    }
}
