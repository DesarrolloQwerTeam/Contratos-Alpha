namespace Contratos_vers_beta.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modifieddatimeanull : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ManageAccounts", "LogoutHour", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ManageAccounts", "LogoutHour", c => c.DateTime(nullable: false));
        }
    }
}
