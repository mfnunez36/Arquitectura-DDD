namespace Datos.Persistencia.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class inicial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Asistencia",
                c => new
                    {
                        AsistenciaID = c.Int(nullable: false, identity: true),
                        id_trabajador_obra = c.Int(),
                        fecha = c.DateTime(),
                        hora = c.Time(precision: 7),
                        vigente = c.Boolean(),
                        TrabajadorObra_TrabajadorObraID = c.Int(),
                    })
                .PrimaryKey(t => t.AsistenciaID)
                .ForeignKey("dbo.TrabajadorObra", t => t.TrabajadorObra_TrabajadorObraID)
                .Index(t => t.TrabajadorObra_TrabajadorObraID);
            
            CreateTable(
                "dbo.TrabajadorObra",
                c => new
                    {
                        TrabajadorObraID = c.Int(nullable: false, identity: true),
                        id_trabajador = c.Int(),
                        id_obra = c.Int(),
                        vigente = c.Boolean(),
                        Obra_ObraID = c.Int(),
                        Trabajador_TrabajadorID = c.Int(),
                    })
                .PrimaryKey(t => t.TrabajadorObraID)
                .ForeignKey("dbo.Obra", t => t.Obra_ObraID)
                .ForeignKey("dbo.Trabajador", t => t.Trabajador_TrabajadorID)
                .Index(t => t.Obra_ObraID)
                .Index(t => t.Trabajador_TrabajadorID);
            
            CreateTable(
                "dbo.Obra",
                c => new
                    {
                        ObraID = c.Int(nullable: false, identity: true),
                        nombre = c.String(maxLength: 150),
                        vigente = c.Boolean(),
                    })
                .PrimaryKey(t => t.ObraID);
            
            CreateTable(
                "dbo.Perfil",
                c => new
                    {
                        PerfilID = c.Int(nullable: false, identity: true),
                        nombre = c.String(maxLength: 150),
                        descripcion = c.String(maxLength: 150),
                        vigente = c.Boolean(),
                    })
                .PrimaryKey(t => t.PerfilID);
            
            CreateTable(
                "dbo.Trabajador",
                c => new
                    {
                        TrabajadorID = c.Int(nullable: false, identity: true),
                        nombre = c.String(maxLength: 150),
                        apellido = c.String(maxLength: 150),
                        telefono = c.Int(),
                        correo = c.String(maxLength: 100),
                        password = c.String(maxLength: 20),
                        valorhra = c.Int(nullable: false),
                        disponible = c.Boolean(),
                        id_perfil = c.Int(),
                        vigente = c.Boolean(),
                        Perfil_PerfilID = c.Int(),
                    })
                .PrimaryKey(t => t.TrabajadorID)
                .ForeignKey("dbo.Perfil", t => t.Perfil_PerfilID)
                .Index(t => t.Perfil_PerfilID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TrabajadorObra", "Trabajador_TrabajadorID", "dbo.Trabajador");
            DropForeignKey("dbo.Trabajador", "Perfil_PerfilID", "dbo.Perfil");
            DropForeignKey("dbo.TrabajadorObra", "Obra_ObraID", "dbo.Obra");
            DropForeignKey("dbo.Asistencia", "TrabajadorObra_TrabajadorObraID", "dbo.TrabajadorObra");
            DropIndex("dbo.Trabajador", new[] { "Perfil_PerfilID" });
            DropIndex("dbo.TrabajadorObra", new[] { "Trabajador_TrabajadorID" });
            DropIndex("dbo.TrabajadorObra", new[] { "Obra_ObraID" });
            DropIndex("dbo.Asistencia", new[] { "TrabajadorObra_TrabajadorObraID" });
            DropTable("dbo.Trabajador");
            DropTable("dbo.Perfil");
            DropTable("dbo.Obra");
            DropTable("dbo.TrabajadorObra");
            DropTable("dbo.Asistencia");
        }
    }
}
