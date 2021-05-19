namespace SmartGroceryList2._0.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FourthMigration : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Customer", "ProductId", "dbo.Product");
            DropIndex("dbo.Customer", new[] { "ProductId" });
            RenameColumn(table: "dbo.Customer", name: "ProductId", newName: "Product_Id");
            AlterColumn("dbo.Customer", "Product_Id", c => c.Int());
            CreateIndex("dbo.Customer", "Product_Id");
            AddForeignKey("dbo.Customer", "Product_Id", "dbo.Product", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Customer", "Product_Id", "dbo.Product");
            DropIndex("dbo.Customer", new[] { "Product_Id" });
            AlterColumn("dbo.Customer", "Product_Id", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.Customer", name: "Product_Id", newName: "ProductId");
            CreateIndex("dbo.Customer", "ProductId");
            AddForeignKey("dbo.Customer", "ProductId", "dbo.Product", "Id", cascadeDelete: true);
        }
    }
}
