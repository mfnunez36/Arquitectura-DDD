namespace Datos.Persistencia.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class inicial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Casa",
                c => new
                    {
                        CasaID = c.Int(nullable: false, identity: true),
                        Numero = c.Int(nullable: false),
                        Calle = c.String(nullable: false, maxLength: 300),
                        NumeroHabitaciones = c.Int(nullable: false),
                        NumeroBaños = c.Int(nullable: false),
                        Pisos = c.Int(nullable: false),
                        MetrosCuadrados = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.CasaID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Casa");
        }
    }
}
