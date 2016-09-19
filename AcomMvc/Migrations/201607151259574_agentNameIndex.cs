namespace AcomMvc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class agentNameIndex : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.agents", "agentName", unique: true);
        }
        
        public override void Down()
        {
            DropIndex("dbo.agents", new[] { "agentName" });
        }
    }
}
