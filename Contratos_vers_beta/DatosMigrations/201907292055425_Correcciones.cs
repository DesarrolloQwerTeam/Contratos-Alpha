namespace Contratos_vers_beta.DatosMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Correcciones : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Contratos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CLAVE_DEL_CONTRATO = c.String(maxLength: 250),
                        FECHA = c.DateTime(),
                        Contrato_Convenio = c.Boolean(nullable: false),
                        Tipo_Contrato_Convenio = c.String(nullable: false, maxLength: 200),
                        EMPRESA = c.String(nullable: false, maxLength: 250),
                        APODERADO = c.String(nullable: false, maxLength: 500),
                        FIRMADO = c.Boolean(nullable: false),
                        EMPRESA_1 = c.String(nullable: false, maxLength: 250),
                        APODERADO_1 = c.String(nullable: false, maxLength: 500),
                        FIRMADO_1 = c.Boolean(nullable: false),
                        EMPRESA_2 = c.String(maxLength: 250),
                        APODERADO_2 = c.String(maxLength: 500),
                        FIRMADO_2 = c.Boolean(nullable: false),
                        CONTRAPRESTACION_IVA_INCLUIDO = c.String(nullable: false, maxLength: 250),
                        VIGENCIA_TAL_CUAL_ESTIPULA_EL_CONTRATO = c.String(nullable: false, maxLength: 250),
                        ORIGINAL_O_COPIA = c.Boolean(nullable: false),
                        ANIO_DE_FIRMA = c.String(nullable: false, maxLength: 20),
                        OBSERVACIONES = c.String(maxLength: 250),
                        FINALIZADO = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PDFContratos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NameFile = c.String(maxLength: 250),
                        File = c.Binary(),
                        Contratos_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Contratos", t => t.Contratos_Id, cascadeDelete: true)
                .Index(t => t.Contratos_Id);
            
            CreateTable(
                "dbo.ManageAccounts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LoginHour = c.DateTime(nullable: false),
                        LogoutHour = c.DateTime(),
                        LogoutByInactivity = c.Boolean(),
                        EmailUser = c.String(maxLength: 256),
                        IdUser = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ModifiedContratos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IdUser = c.String(maxLength: 128),
                        EmailUser = c.String(maxLength: 256),
                        ExecutedAction = c.String(maxLength: 50),
                        ActionHour = c.DateTime(nullable: false),
                        ClaveContrato = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PDFContratos", "Contratos_Id", "dbo.Contratos");
            DropIndex("dbo.PDFContratos", new[] { "Contratos_Id" });
            DropTable("dbo.ModifiedContratos");
            DropTable("dbo.ManageAccounts");
            DropTable("dbo.PDFContratos");
            DropTable("dbo.Contratos");
        }
    }
}
