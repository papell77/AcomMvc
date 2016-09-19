namespace AcomMvc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class second : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.canals", "note", c => c.String(maxLength: 512));
            AddColumn("dbo.canals", "annull", c => c.Boolean(nullable: false));
            AddColumn("dbo.canals", "createdBy", c => c.String());
            AddColumn("dbo.canals", "createdDate", c => c.DateTime());
            AddColumn("dbo.canals", "updatedBy", c => c.String());
            AddColumn("dbo.canals", "updatedDate", c => c.DateTime());
            AddColumn("dbo.canals", "rowvers", c => c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"));
            AddColumn("dbo.clientOffices", "note", c => c.String(maxLength: 512));
            AddColumn("dbo.clientOffices", "annull", c => c.Boolean(nullable: false));
            AddColumn("dbo.clientOffices", "createdBy", c => c.String());
            AddColumn("dbo.clientOffices", "createdDate", c => c.DateTime());
            AddColumn("dbo.clientOffices", "updatedBy", c => c.String());
            AddColumn("dbo.clientOffices", "updatedDate", c => c.DateTime());
            AddColumn("dbo.clientOffices", "rowvers", c => c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"));
        }
        
        public override void Down()
        {
            DropColumn("dbo.clientOffices", "rowvers");
            DropColumn("dbo.clientOffices", "updatedDate");
            DropColumn("dbo.clientOffices", "updatedBy");
            DropColumn("dbo.clientOffices", "createdDate");
            DropColumn("dbo.clientOffices", "createdBy");
            DropColumn("dbo.clientOffices", "annull");
            DropColumn("dbo.clientOffices", "note");
            DropColumn("dbo.canals", "rowvers");
            DropColumn("dbo.canals", "updatedDate");
            DropColumn("dbo.canals", "updatedBy");
            DropColumn("dbo.canals", "createdDate");
            DropColumn("dbo.canals", "createdBy");
            DropColumn("dbo.canals", "annull");
            DropColumn("dbo.canals", "note");
        }
    }
}
