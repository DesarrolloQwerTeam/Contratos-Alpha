namespace Contratos_vers_beta.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class logoutbyinactivity : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ManageAccounts", "LogoutByInactivity", c => c.Boolean());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ManageAccounts", "LogoutByInactivity");
        }
    }
}
