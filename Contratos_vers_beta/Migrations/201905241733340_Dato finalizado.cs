namespace Contratos_vers_beta.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Datofinalizado : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Contratos", "FINALIZADO", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Contratos", "FINALIZADO");
        }
    }
}
