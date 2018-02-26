namespace gestionmateriales.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Entrada",
                c => new
                    {
                        idEntrada = c.Int(nullable: false, identity: true),
                        fecha = c.DateTime(nullable: false, precision: 0),
                        cantidad = c.Int(nullable: false),
                        codigoMaterial = c.String(nullable: false, maxLength: 15, storeType: "nvarchar"),
                        codigoDocumento = c.String(nullable: false, maxLength: 15, storeType: "nvarchar"),
                        idMaterial = c.Int(nullable: false),
                        idTipoEntrada = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.idEntrada)
                .ForeignKey("dbo.Material", t => t.idMaterial, cascadeDelete: true)
                .ForeignKey("dbo.TipoEntrada", t => t.idTipoEntrada, cascadeDelete: true)
                .Index(t => t.idMaterial)
                .Index(t => t.idTipoEntrada);
            
            CreateTable(
                "dbo.Material",
                c => new
                    {
                        idMaterial = c.Int(nullable: false, identity: true),
                        codigo = c.String(nullable: false, maxLength: 15, storeType: "nvarchar"),
                        nombre = c.String(nullable: false, maxLength: 75, storeType: "nvarchar"),
                        stockActual = c.Int(nullable: false),
                        stockMinimo = c.Int(nullable: false),
                        idUnidad = c.Int(nullable: false),
                        idProveedor = c.Int(nullable: false),
                        idTipoMaterial = c.Int(nullable: false),
                        estado = c.String(nullable: false, maxLength: 12, storeType: "nvarchar"),
                        detalle = c.String(maxLength: 100, storeType: "nvarchar"),
                        hab = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.idMaterial)
                .ForeignKey("dbo.Proveedor", t => t.idProveedor, cascadeDelete: true)
                .ForeignKey("dbo.TipoMaterial", t => t.idTipoMaterial, cascadeDelete: true)
                .ForeignKey("dbo.Unidad", t => t.idUnidad, cascadeDelete: true)
                .Index(t => t.idUnidad)
                .Index(t => t.idProveedor)
                .Index(t => t.idTipoMaterial);
            
            CreateTable(
                "dbo.Proveedor",
                c => new
                    {
                        idProveedor = c.Int(nullable: false, identity: true),
                        nombre = c.String(nullable: false, maxLength: 45, storeType: "nvarchar"),
                        direccion = c.String(nullable: false, maxLength: 100, storeType: "nvarchar"),
                        cuit = c.String(nullable: false, maxLength: 20, storeType: "nvarchar"),
                        telefono = c.String(nullable: false, maxLength: 20, storeType: "nvarchar"),
                        email = c.String(nullable: false, maxLength: 50, storeType: "nvarchar"),
                        razonSocial = c.String(nullable: false, maxLength: 15, storeType: "nvarchar"),
                        nombreContacto = c.String(maxLength: 45, storeType: "nvarchar"),
                        zona = c.String(nullable: false, maxLength: 30, storeType: "nvarchar"),
                        horario = c.String(nullable: false, maxLength: 20, storeType: "nvarchar"),
                        hab = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.idProveedor);
            
            CreateTable(
                "dbo.Salida",
                c => new
                    {
                        idSalida = c.Int(nullable: false, identity: true),
                        fecha = c.DateTime(nullable: false, precision: 0),
                        cantidad = c.Int(nullable: false),
                        Material_idMaterial = c.Int(),
                        Personal_idPersonal = c.Int(),
                    })
                .PrimaryKey(t => t.idSalida)
                .ForeignKey("dbo.Material", t => t.Material_idMaterial)
                .ForeignKey("dbo.Personal", t => t.Personal_idPersonal)
                .Index(t => t.Material_idMaterial)
                .Index(t => t.Personal_idPersonal);
            
            CreateTable(
                "dbo.Personal",
                c => new
                    {
                        idPersonal = c.Int(nullable: false, identity: true),
                        nombre = c.String(nullable: false, maxLength: 60, storeType: "nvarchar"),
                        dni = c.Int(nullable: false),
                        fichaCensal = c.Int(nullable: false),
                        hab = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.idPersonal);
            
            CreateTable(
                "dbo.TipoMaterial",
                c => new
                    {
                        idTipoMaterial = c.Int(nullable: false, identity: true),
                        nombre = c.String(nullable: false, maxLength: 20, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => t.idTipoMaterial);
            
            CreateTable(
                "dbo.Unidad",
                c => new
                    {
                        idUnidad = c.Int(nullable: false, identity: true),
                        nombre = c.String(nullable: false, maxLength: 15, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => t.idUnidad);
            
            CreateTable(
                "dbo.TipoEntrada",
                c => new
                    {
                        idTipoEntrada = c.Int(nullable: false, identity: true),
                        nombre = c.String(nullable: false, maxLength: 35, storeType: "nvarchar"),
                        idSector = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.idTipoEntrada);
            
            CreateTable(
                "dbo.ItemOP",
                c => new
                    {
                        idItemOP = c.Int(nullable: false, identity: true),
                        cantidad = c.Int(nullable: false),
                        idMaterial = c.Int(nullable: false),
                        idOrdenPedido = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.idItemOP)
                .ForeignKey("dbo.Material", t => t.idMaterial, cascadeDelete: true)
                .ForeignKey("dbo.OrdenPedido", t => t.idOrdenPedido, cascadeDelete: true)
                .Index(t => t.idMaterial)
                .Index(t => t.idOrdenPedido);
            
            CreateTable(
                "dbo.OrdenPedido",
                c => new
                    {
                        idOrdenPedido = c.Int(nullable: false, identity: true),
                        numOp = c.Int(nullable: false),
                        numOt = c.Int(nullable: false),
                        destino = c.String(nullable: false, maxLength: 150, storeType: "nvarchar"),
                        hab = c.Boolean(nullable: false),
                        fecha = c.DateTime(nullable: false, precision: 0),
                    })
                .PrimaryKey(t => t.idOrdenPedido);
            
            CreateTable(
                "dbo.ItemOT",
                c => new
                    {
                        idItemOT = c.Int(nullable: false, identity: true),
                        cantidad = c.Int(nullable: false),
                        idMaterial = c.Int(nullable: false),
                        idOrdenTrabajo = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.idItemOT)
                .ForeignKey("dbo.Material", t => t.idMaterial, cascadeDelete: true)
                .ForeignKey("dbo.OrdenTrabajo", t => t.idOrdenTrabajo, cascadeDelete: true)
                .Index(t => t.idMaterial)
                .Index(t => t.idOrdenTrabajo);
            
            CreateTable(
                "dbo.OrdenTrabajo",
                c => new
                    {
                        idOrdenTrabajo = c.Int(nullable: false, identity: true),
                        numero = c.Int(nullable: false),
                        nombre = c.String(nullable: false, maxLength: 70, storeType: "nvarchar"),
                        idTurno = c.Int(nullable: false),
                        fecha = c.DateTime(nullable: false, precision: 0),
                        idJefeSeccion = c.Int(nullable: false),
                        idResponsable = c.Int(nullable: false),
                        hab = c.Boolean(nullable: false),
                        jefeSeccion_idPersonal = c.Int(),
                        responsable_idPersonal = c.Int(),
                    })
                .PrimaryKey(t => t.idOrdenTrabajo)
                .ForeignKey("dbo.Personal", t => t.jefeSeccion_idPersonal)
                .ForeignKey("dbo.Personal", t => t.responsable_idPersonal)
                .ForeignKey("dbo.Turno", t => t.idTurno, cascadeDelete: true)
                .Index(t => t.idTurno)
                .Index(t => t.jefeSeccion_idPersonal)
                .Index(t => t.responsable_idPersonal);
            
            CreateTable(
                "dbo.Turno",
                c => new
                    {
                        idTurno = c.Int(nullable: false, identity: true),
                        nombre = c.String(nullable: false, maxLength: 7, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => t.idTurno);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ItemOT", "idOrdenTrabajo", "dbo.OrdenTrabajo");
            DropForeignKey("dbo.OrdenTrabajo", "idTurno", "dbo.Turno");
            DropForeignKey("dbo.OrdenTrabajo", "responsable_idPersonal", "dbo.Personal");
            DropForeignKey("dbo.OrdenTrabajo", "jefeSeccion_idPersonal", "dbo.Personal");
            DropForeignKey("dbo.ItemOT", "idMaterial", "dbo.Material");
            DropForeignKey("dbo.ItemOP", "idOrdenPedido", "dbo.OrdenPedido");
            DropForeignKey("dbo.ItemOP", "idMaterial", "dbo.Material");
            DropForeignKey("dbo.Entrada", "idTipoEntrada", "dbo.TipoEntrada");
            DropForeignKey("dbo.Material", "idUnidad", "dbo.Unidad");
            DropForeignKey("dbo.Material", "idTipoMaterial", "dbo.TipoMaterial");
            DropForeignKey("dbo.Salida", "Personal_idPersonal", "dbo.Personal");
            DropForeignKey("dbo.Salida", "Material_idMaterial", "dbo.Material");
            DropForeignKey("dbo.Material", "idProveedor", "dbo.Proveedor");
            DropForeignKey("dbo.Entrada", "idMaterial", "dbo.Material");
            DropIndex("dbo.OrdenTrabajo", new[] { "responsable_idPersonal" });
            DropIndex("dbo.OrdenTrabajo", new[] { "jefeSeccion_idPersonal" });
            DropIndex("dbo.OrdenTrabajo", new[] { "idTurno" });
            DropIndex("dbo.ItemOT", new[] { "idOrdenTrabajo" });
            DropIndex("dbo.ItemOT", new[] { "idMaterial" });
            DropIndex("dbo.ItemOP", new[] { "idOrdenPedido" });
            DropIndex("dbo.ItemOP", new[] { "idMaterial" });
            DropIndex("dbo.Salida", new[] { "Personal_idPersonal" });
            DropIndex("dbo.Salida", new[] { "Material_idMaterial" });
            DropIndex("dbo.Material", new[] { "idTipoMaterial" });
            DropIndex("dbo.Material", new[] { "idProveedor" });
            DropIndex("dbo.Material", new[] { "idUnidad" });
            DropIndex("dbo.Entrada", new[] { "idTipoEntrada" });
            DropIndex("dbo.Entrada", new[] { "idMaterial" });
            DropTable("dbo.Turno");
            DropTable("dbo.OrdenTrabajo");
            DropTable("dbo.ItemOT");
            DropTable("dbo.OrdenPedido");
            DropTable("dbo.ItemOP");
            DropTable("dbo.TipoEntrada");
            DropTable("dbo.Unidad");
            DropTable("dbo.TipoMaterial");
            DropTable("dbo.Personal");
            DropTable("dbo.Salida");
            DropTable("dbo.Proveedor");
            DropTable("dbo.Material");
            DropTable("dbo.Entrada");
        }
    }
}
