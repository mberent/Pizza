namespace Pizzeria.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PizzaToppizngs : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Pizzas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        PriceForSmall = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PriceForMedium = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PriceForLarge = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Thickness = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PizzaToppings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PizzaToppingPizzas",
                c => new
                    {
                        PizzaTopping_Id = c.Int(nullable: false),
                        Pizza_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.PizzaTopping_Id, t.Pizza_Id })
                .ForeignKey("dbo.PizzaToppings", t => t.PizzaTopping_Id, cascadeDelete: true)
                .ForeignKey("dbo.Pizzas", t => t.Pizza_Id, cascadeDelete: true)
                .Index(t => t.PizzaTopping_Id)
                .Index(t => t.Pizza_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PizzaToppingPizzas", "Pizza_Id", "dbo.Pizzas");
            DropForeignKey("dbo.PizzaToppingPizzas", "PizzaTopping_Id", "dbo.PizzaToppings");
            DropIndex("dbo.PizzaToppingPizzas", new[] { "Pizza_Id" });
            DropIndex("dbo.PizzaToppingPizzas", new[] { "PizzaTopping_Id" });
            DropTable("dbo.PizzaToppingPizzas");
            DropTable("dbo.PizzaToppings");
            DropTable("dbo.Pizzas");
        }
    }
}
