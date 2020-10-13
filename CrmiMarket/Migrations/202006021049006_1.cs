namespace CrmiMarket.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DayStocks",
                c => new
                    {
                        DayStockId = c.Int(nullable: false, identity: true),
                        Open = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Close = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Max = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Min = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Date = c.DateTime(nullable: false),
                        symbol_SymbolId = c.Int(),
                    })
                .PrimaryKey(t => t.DayStockId)
                .ForeignKey("dbo.Symbols", t => t.symbol_SymbolId)
                .Index(t => t.symbol_SymbolId);
            
            CreateTable(
                "dbo.Symbols",
                c => new
                    {
                        SymbolId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.SymbolId);
            
            CreateTable(
                "dbo.FourHours",
                c => new
                    {
                        FourHourId = c.Int(nullable: false, identity: true),
                        Open = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Close = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Max = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Min = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Date = c.DateTime(nullable: false),
                        symbol_SymbolId = c.Int(),
                    })
                .PrimaryKey(t => t.FourHourId)
                .ForeignKey("dbo.Symbols", t => t.symbol_SymbolId)
                .Index(t => t.symbol_SymbolId);
            
            CreateTable(
                "dbo.HalfHours",
                c => new
                    {
                        HalfHourId = c.Int(nullable: false, identity: true),
                        Open = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Close = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Max = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Min = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Date = c.DateTime(nullable: false),
                        symbol_SymbolId = c.Int(),
                    })
                .PrimaryKey(t => t.HalfHourId)
                .ForeignKey("dbo.Symbols", t => t.symbol_SymbolId)
                .Index(t => t.symbol_SymbolId);
            
            CreateTable(
                "dbo.Hours",
                c => new
                    {
                        HourId = c.Int(nullable: false, identity: true),
                        Open = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Close = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Max = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Min = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Date = c.DateTime(nullable: false),
                        symbol_SymbolId = c.Int(),
                    })
                .PrimaryKey(t => t.HourId)
                .ForeignKey("dbo.Symbols", t => t.symbol_SymbolId)
                .Index(t => t.symbol_SymbolId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Hours", "symbol_SymbolId", "dbo.Symbols");
            DropForeignKey("dbo.HalfHours", "symbol_SymbolId", "dbo.Symbols");
            DropForeignKey("dbo.FourHours", "symbol_SymbolId", "dbo.Symbols");
            DropForeignKey("dbo.DayStocks", "symbol_SymbolId", "dbo.Symbols");
            DropIndex("dbo.Hours", new[] { "symbol_SymbolId" });
            DropIndex("dbo.HalfHours", new[] { "symbol_SymbolId" });
            DropIndex("dbo.FourHours", new[] { "symbol_SymbolId" });
            DropIndex("dbo.DayStocks", new[] { "symbol_SymbolId" });
            DropTable("dbo.Hours");
            DropTable("dbo.HalfHours");
            DropTable("dbo.FourHours");
            DropTable("dbo.Symbols");
            DropTable("dbo.DayStocks");
        }
    }
}
