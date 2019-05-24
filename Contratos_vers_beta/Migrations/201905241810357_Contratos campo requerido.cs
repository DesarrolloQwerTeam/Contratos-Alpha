namespace Contratos_vers_beta.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Contratoscamporequerido : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Contratos", "FECHA", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Contratos", "EMPRESA", c => c.String(nullable: false, maxLength: 250));
            AlterColumn("dbo.Contratos", "APODERADO", c => c.String(nullable: false, maxLength: 500));
            AlterColumn("dbo.Contratos", "EMPRESA_1", c => c.String(nullable: false, maxLength: 250));
            AlterColumn("dbo.Contratos", "APODERADO_1", c => c.String(nullable: false, maxLength: 500));
            AlterColumn("dbo.Contratos", "CONTRAPRESTACION_IVA_INCLUIDO", c => c.String(nullable: false, maxLength: 250));
            AlterColumn("dbo.Contratos", "VIGENCIA_TAL_CUAL_ESTIPULA_EL_CONTRATO", c => c.String(nullable: false, maxLength: 250));
            AlterColumn("dbo.Contratos", "ANIO_DE_FIRMA", c => c.String(nullable: false, maxLength: 20));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Contratos", "ANIO_DE_FIRMA", c => c.String(maxLength: 20));
            AlterColumn("dbo.Contratos", "VIGENCIA_TAL_CUAL_ESTIPULA_EL_CONTRATO", c => c.String(maxLength: 250));
            AlterColumn("dbo.Contratos", "CONTRAPRESTACION_IVA_INCLUIDO", c => c.String(maxLength: 250));
            AlterColumn("dbo.Contratos", "APODERADO_1", c => c.String(maxLength: 500));
            AlterColumn("dbo.Contratos", "EMPRESA_1", c => c.String(maxLength: 250));
            AlterColumn("dbo.Contratos", "APODERADO", c => c.String(maxLength: 500));
            AlterColumn("dbo.Contratos", "EMPRESA", c => c.String(maxLength: 250));
            AlterColumn("dbo.Contratos", "FECHA", c => c.DateTime());
        }
    }
}
