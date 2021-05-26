namespace SmartGroceryList2._0.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TenthMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ShoppingList",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    CartId = c.Int(),
                    ProductId = c.Int(),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cart", t => t.CartId)
                .ForeignKey("dbo.Product", t => t.ProductId)
                .Index(t => t.CartId)
                .Index(t => t.ProductId);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ShoppingList", "ProductId", "dbo.Product");
            DropForeignKey("dbo.ShoppingList", "CartId", "dbo.Cart");
            DropIndex("dbo.ShoppingList", new[] { "ProductId" });
            DropIndex("dbo.ShoppingList", new[] { "CartId" });
            DropTable("dbo.ShoppingList");
        }
    }
}
