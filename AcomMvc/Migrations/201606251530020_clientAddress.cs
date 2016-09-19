namespace AcomMvc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class clientAddress : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.clients", "cityLegalID", "dbo.cities");
            DropForeignKey("dbo.clients", "cityOperativeID", "dbo.cities");
            DropForeignKey("dbo.clients", "countyLegalID", "dbo.counties");
            DropForeignKey("dbo.clients", "countyOperativeID", "dbo.counties");
            DropIndex("dbo.clients", new[] { "countyLegalID" });
            DropIndex("dbo.clients", new[] { "countyOperativeID" });
            DropIndex("dbo.clients", new[] { "cityLegalID" });
            DropIndex("dbo.clients", new[] { "cityOperativeID" });
            RenameColumn(table: "dbo.clients", name: "city_ID", newName: "cityID");
            RenameColumn(table: "dbo.clients", name: "county_ID", newName: "countyID");
            RenameIndex(table: "dbo.clients", name: "IX_county_ID", newName: "IX_countyID");
            RenameIndex(table: "dbo.clients", name: "IX_city_ID", newName: "IX_cityID");
            AddColumn("dbo.clients", "clientCap", c => c.String(maxLength: 5));
            AddColumn("dbo.clients", "clientAddress", c => c.String(maxLength: 512));
            DropColumn("dbo.clients", "clientLegalCap");
            DropColumn("dbo.clients", "clientLegalAddress");
            DropColumn("dbo.clients", "clientOperativeCap");
            DropColumn("dbo.clients", "clientOperativeAddress");
            DropColumn("dbo.clients", "countyLegalID");
            DropColumn("dbo.clients", "countyOperativeID");
            DropColumn("dbo.clients", "cityLegalID");
            DropColumn("dbo.clients", "cityOperativeID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.clients", "cityOperativeID", c => c.Int());
            AddColumn("dbo.clients", "cityLegalID", c => c.Int());
            AddColumn("dbo.clients", "countyOperativeID", c => c.Int());
            AddColumn("dbo.clients", "countyLegalID", c => c.Int());
            AddColumn("dbo.clients", "clientOperativeAddress", c => c.String(maxLength: 512));
            AddColumn("dbo.clients", "clientOperativeCap", c => c.String(maxLength: 5));
            AddColumn("dbo.clients", "clientLegalAddress", c => c.String(maxLength: 512));
            AddColumn("dbo.clients", "clientLegalCap", c => c.String(maxLength: 5));
            DropColumn("dbo.clients", "clientAddress");
            DropColumn("dbo.clients", "clientCap");
            RenameIndex(table: "dbo.clients", name: "IX_cityID", newName: "IX_city_ID");
            RenameIndex(table: "dbo.clients", name: "IX_countyID", newName: "IX_county_ID");
            RenameColumn(table: "dbo.clients", name: "countyID", newName: "county_ID");
            RenameColumn(table: "dbo.clients", name: "cityID", newName: "city_ID");
            CreateIndex("dbo.clients", "cityOperativeID");
            CreateIndex("dbo.clients", "cityLegalID");
            CreateIndex("dbo.clients", "countyOperativeID");
            CreateIndex("dbo.clients", "countyLegalID");
            AddForeignKey("dbo.clients", "countyOperativeID", "dbo.counties", "ID");
            AddForeignKey("dbo.clients", "countyLegalID", "dbo.counties", "ID");
            AddForeignKey("dbo.clients", "cityOperativeID", "dbo.cities", "ID");
            AddForeignKey("dbo.clients", "cityLegalID", "dbo.cities", "ID");
        }
    }
}
