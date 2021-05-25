namespace SmartGroceryList2._0.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SixthMigration : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Cart", "ProductId", "dbo.Product");
            DropForeignKey("dbo.Cart", "CustomerId", "dbo.Customer");
            DropForeignKey("dbo.ShoppingList", "ProductId", "dbo.Product");
            DropIndex("dbo.Cart", new[] { "ProductId" });
            DropIndex("dbo.Cart", new[] { "CustomerId" });
            DropIndex("dbo.ShoppingList", new[] { "ProductId" });
            RenameColumn(table: "dbo.ShoppingList", name: "CustomerId", newName: "Customer_CustomerId");
            RenameIndex(table: "dbo.ShoppingList", name: "IX_CustomerId", newName: "IX_Customer_CustomerId");
            AddColumn("dbo.Cart", "OwnerId", c => c.Guid(nullable: false));
            AddColumn("dbo.ShoppingList", "CartId", c => c.Int(nullable: false));
            AlterColumn("dbo.Cart", "CustomerId", c => c.Int(nullable: false));
            AlterColumn("dbo.ShoppingList", "ProductId", c => c.Int(nullable: false));
            CreateIndex("dbo.Cart", "CustomerId");
            CreateIndex("dbo.ShoppingList", "CartId");
            CreateIndex("dbo.ShoppingList", "ProductId");
            AddForeignKey("dbo.ShoppingList", "CartId", "dbo.Cart", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Cart", "CustomerId", "dbo.Customer", "CustomerId", cascadeDelete: true);
            AddForeignKey("dbo.ShoppingList", "ProductId", "dbo.Product", "Id", cascadeDelete: true);
            DropColumn("dbo.Cart", "ProductId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Cart", "ProductId", c => c.Int());
            DropForeignKey("dbo.ShoppingList", "ProductId", "dbo.Product");
            DropForeignKey("dbo.Cart", "CustomerId", "dbo.Customer");
            DropForeignKey("dbo.ShoppingList", "CartId", "dbo.Cart");
            DropIndex("dbo.ShoppingList", new[] { "ProductId" });
            DropIndex("dbo.ShoppingList", new[] { "CartId" });
            DropIndex("dbo.Cart", new[] { "CustomerId" });
            AlterColumn("dbo.ShoppingList", "ProductId", c => c.Int());
            AlterColumn("dbo.Cart", "CustomerId", c => c.Int());
            DropColumn("dbo.ShoppingList", "CartId");
            DropColumn("dbo.Cart", "OwnerId");
            RenameIndex(table: "dbo.ShoppingList", name: "IX_Customer_CustomerId", newName: "IX_CustomerId");
            RenameColumn(table: "dbo.ShoppingList", name: "Customer_CustomerId", newName: "CustomerId");
            CreateIndex("dbo.ShoppingList", "ProductId");
            CreateIndex("dbo.Cart", "CustomerId");
            CreateIndex("dbo.Cart", "ProductId");
            AddForeignKey("dbo.ShoppingList", "ProductId", "dbo.Product", "Id");
            AddForeignKey("dbo.Cart", "CustomerId", "dbo.Customer", "CustomerId");
            AddForeignKey("dbo.Cart", "ProductId", "dbo.Product", "Id");
        }
    }
}
