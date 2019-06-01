namespace Contratos_vers_beta.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fecha : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Contratos", "FECHA", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Contratos", "FECHA", c => c.DateTime(nullable: false));
        }
    }
}
