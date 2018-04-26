namespace gestionmateriales.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migracionInicial : DbMigration
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
                        codigoMaterial = c.String(nullable: false, maxLength: 15, unicode: false, storeType: "nvarchar"),
                        codigoDocumento = c.String(nullable: false, maxLength: 15, unicode: false, storeType: "nvarchar"),
                        idMaterial = c.Int(nullable: false),
                        idTipoEntrada = c.Int(nullable: false),
                        CREATED_BY = c.String(maxLength: 50, unicode: false, storeType: "nvarchar"),
                        CREATION_DATE = c.DateTime(nullable: false, precision: 0),
                        CREATION_IP = c.String(maxLength: 20, unicode: false, storeType: "nvarchar"),
                        LAST_UPDATED_BY = c.String(maxLength: 50, unicode: false, storeType: "nvarchar"),
                        LAST_UPDATED_DATE = c.DateTime(nullable: false, precision: 0),
                        LAST_UPDATED_IP = c.String(maxLength: 20, unicode: false, storeType: "nvarchar"),
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
                        codigo = c.String(nullable: false, maxLength: 15, unicode: false, storeType: "nvarchar"),
                        nombre = c.String(nullable: false, maxLength: 75, unicode: false, storeType: "nvarchar"),
                        stockActual = c.Int(nullable: false),
                        stockMinimo = c.Int(nullable: false),
                        idUnidad = c.Int(nullable: false),
                        idProveedor = c.Int(nullable: false),
                        idTipoMaterial = c.Int(nullable: false),
                        estado = c.String(nullable: false, maxLength: 12, unicode: false, storeType: "nvarchar"),
                        detalle = c.String(maxLength: 100, unicode: false, storeType: "nvarchar"),
                        hab = c.Boolean(nullable: false),
                        CREATED_BY = c.String(maxLength: 50, unicode: false, storeType: "nvarchar"),
                        CREATION_DATE = c.DateTime(nullable: false, precision: 0),
                        CREATION_IP = c.String(maxLength: 20, unicode: false, storeType: "nvarchar"),
                        LAST_UPDATED_BY = c.String(maxLength: 50, unicode: false, storeType: "nvarchar"),
                        LAST_UPDATED_DATE = c.DateTime(nullable: false, precision: 0),
                        LAST_UPDATED_IP = c.String(maxLength: 20, unicode: false, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => t.idMaterial)
                .ForeignKey("dbo.Proveedor", t => t.idProveedor, cascadeDelete: true)
                .ForeignKey("dbo.TipoMaterial", t => t.idTipoMaterial, cascadeDelete: true)
                .ForeignKey("dbo.Unidad", t => t.idUnidad, cascadeDelete: true)
                .Index(t => t.idProveedor)
                .Index(t => t.idTipoMaterial)
                .Index(t => t.idUnidad);
            
            CreateTable(
                "dbo.Proveedor",
                c => new
                    {
                        idProveedor = c.Int(nullable: false, identity: true),
                        nombre = c.String(nullable: false, maxLength: 45, unicode: false, storeType: "nvarchar"),
                        direccion = c.String(nullable: false, maxLength: 100, unicode: false, storeType: "nvarchar"),
                        cuit = c.String(nullable: false, maxLength: 20, unicode: false, storeType: "nvarchar"),
                        telefono = c.String(nullable: false, maxLength: 20, unicode: false, storeType: "nvarchar"),
                        email = c.String(nullable: false, maxLength: 50, unicode: false, storeType: "nvarchar"),
                        razonSocial = c.String(nullable: false, maxLength: 15, unicode: false, storeType: "nvarchar"),
                        nombreContacto = c.String(maxLength: 45, unicode: false, storeType: "nvarchar"),
                        zona = c.String(nullable: false, maxLength: 30, unicode: false, storeType: "nvarchar"),
                        horario = c.String(nullable: false, maxLength: 20, unicode: false, storeType: "nvarchar"),
                        hab = c.Boolean(nullable: false),
                        CREATED_BY = c.String(maxLength: 50, unicode: false, storeType: "nvarchar"),
                        CREATION_DATE = c.DateTime(nullable: false, precision: 0),
                        CREATION_IP = c.String(maxLength: 20, unicode: false, storeType: "nvarchar"),
                        LAST_UPDATED_BY = c.String(maxLength: 50, unicode: false, storeType: "nvarchar"),
                        LAST_UPDATED_DATE = c.DateTime(nullable: false, precision: 0),
                        LAST_UPDATED_IP = c.String(maxLength: 20, unicode: false, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => t.idProveedor);
            
            CreateTable(
                "dbo.Salida",
                c => new
                    {
                        idSalida = c.Int(nullable: false, identity: true),
                        fecha = c.DateTime(nullable: false, precision: 0),
                        cantidad = c.Int(nullable: false),
                        codigoMaterial = c.String(nullable: false, maxLength: 15, unicode: false, storeType: "nvarchar"),
                        codigoDocumento = c.String(nullable: false, maxLength: 15, unicode: false, storeType: "nvarchar"),
                        idMaterial = c.Int(nullable: false),
                        idTipoSalida = c.Int(nullable: false),
                        CREATED_BY = c.String(maxLength: 50, unicode: false, storeType: "nvarchar"),
                        CREATION_DATE = c.DateTime(nullable: false, precision: 0),
                        CREATION_IP = c.String(maxLength: 20, unicode: false, storeType: "nvarchar"),
                        LAST_UPDATED_BY = c.String(maxLength: 50, unicode: false, storeType: "nvarchar"),
                        LAST_UPDATED_DATE = c.DateTime(nullable: false, precision: 0),
                        LAST_UPDATED_IP = c.String(maxLength: 20, unicode: false, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => t.idSalida)
                .ForeignKey("dbo.Material", t => t.idMaterial, cascadeDelete: true)
                .ForeignKey("dbo.TipoSalida", t => t.idTipoSalida, cascadeDelete: true)
                .Index(t => t.idMaterial)
                .Index(t => t.idTipoSalida);
            
            CreateTable(
                "dbo.TipoSalida",
                c => new
                    {
                        idTipoSalida = c.Int(nullable: false, identity: true),
                        nombre = c.String(nullable: false, maxLength: 35, unicode: false, storeType: "nvarchar"),
                        idSector = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.idTipoSalida);
            
            CreateTable(
                "dbo.TipoMaterial",
                c => new
                    {
                        idTipoMaterial = c.Int(nullable: false, identity: true),
                        nombre = c.String(nullable: false, maxLength: 20, unicode: false, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => t.idTipoMaterial);
            
            CreateTable(
                "dbo.Unidad",
                c => new
                    {
                        idUnidad = c.Int(nullable: false, identity: true),
                        nombre = c.String(nullable: false, maxLength: 15, unicode: false, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => t.idUnidad);
            
            CreateTable(
                "dbo.TipoEntrada",
                c => new
                    {
                        idTipoEntrada = c.Int(nullable: false, identity: true),
                        nombre = c.String(nullable: false, maxLength: 35, unicode: false, storeType: "nvarchar"),
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
                        numOta = c.Int(nullable: false),
                        destino = c.String(nullable: false, maxLength: 150, unicode: false, storeType: "nvarchar"),
                        hab = c.Boolean(nullable: false),
                        fecha = c.DateTime(nullable: false, precision: 0),
                        CREATED_BY = c.DateTime(nullable: false, precision: 0),
                        CREATION_DATE = c.String(maxLength: 20, unicode: false, storeType: "nvarchar"),
                        CREATION_IP = c.String(maxLength: 20, unicode: false, storeType: "nvarchar"),
                        LAST_UPDATED_BY = c.String(maxLength: 50, unicode: false, storeType: "nvarchar"),
                        LAST_UPDATED_DATE = c.DateTime(nullable: false, precision: 0),
                        LAST_UPDATED_IP = c.String(maxLength: 20, unicode: false, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => t.idOrdenPedido);
            
            CreateTable(
                "dbo.ItemOT",
                c => new
                    {
                        idItemOTA = c.Int(nullable: false, identity: true),
                        cantidad = c.Int(nullable: false),
                        idMaterial = c.Int(nullable: false),
                        idOrdenTrabajoAplicacion = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.idItemOTA)
                .ForeignKey("dbo.Material", t => t.idMaterial, cascadeDelete: true)
                .ForeignKey("dbo.OrdenTrabajoAplicacion", t => t.idOrdenTrabajoAplicacion, cascadeDelete: true)
                .Index(t => t.idMaterial)
                .Index(t => t.idOrdenTrabajoAplicacion);
            
            CreateTable(
                "dbo.OrdenTrabajoAplicacion",
                c => new
                    {
                        idOrdenTrabajoAplicacion = c.Int(nullable: false, identity: true),
                        numero = c.Int(nullable: false),
                        nombre = c.String(nullable: false, maxLength: 70, unicode: false, storeType: "nvarchar"),
                        idTurno = c.Int(nullable: false),
                        fecha = c.DateTime(nullable: false, precision: 0),
                        idJefeSeccion = c.Int(nullable: false),
                        idResponsable = c.Int(nullable: false),
                        hab = c.Boolean(nullable: false),
                        CREATED_BY = c.String(maxLength: 50, unicode: false, storeType: "nvarchar"),
                        CREATION_DATE = c.DateTime(nullable: false, precision: 0),
                        CREATION_IP = c.String(maxLength: 20, unicode: false, storeType: "nvarchar"),
                        LAST_UPDATED_BY = c.String(maxLength: 50, unicode: false, storeType: "nvarchar"),
                        LAST_UPDATED_DATE = c.DateTime(nullable: false, precision: 0),
                        LAST_UPDATED_IP = c.String(maxLength: 20, unicode: false, storeType: "nvarchar"),
                        jefeSeccion_idPersonal = c.Int(),
                        responsable_idPersonal = c.Int(),
                    })
                .PrimaryKey(t => t.idOrdenTrabajoAplicacion)
                .ForeignKey("dbo.Personal", t => t.jefeSeccion_idPersonal)
                .ForeignKey("dbo.Personal", t => t.responsable_idPersonal)
                .ForeignKey("dbo.Turno", t => t.idTurno, cascadeDelete: true)
                .Index(t => t.jefeSeccion_idPersonal)
                .Index(t => t.responsable_idPersonal)
                .Index(t => t.idTurno);
            
            CreateTable(
                "dbo.Personal",
                c => new
                    {
                        idPersonal = c.Int(nullable: false, identity: true),
                        nombre = c.String(nullable: false, maxLength: 60, unicode: false, storeType: "nvarchar"),
                        dni = c.Int(nullable: false),
                        fichaCensal = c.Int(nullable: false),
                        hab = c.Boolean(nullable: false),
                        CREATED_BY = c.String(maxLength: 50, unicode: false, storeType: "nvarchar"),
                        CREATION_DATE = c.DateTime(nullable: false, precision: 0),
                        CREATION_IP = c.String(maxLength: 20, unicode: false, storeType: "nvarchar"),
                        LAST_UPDATED_BY = c.String(maxLength: 50, unicode: false, storeType: "nvarchar"),
                        LAST_UPDATED_DATE = c.DateTime(nullable: false, precision: 0),
                        LAST_UPDATED_IP = c.String(maxLength: 20, unicode: false, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => t.idPersonal);
            
            CreateTable(
                "dbo.Turno",
                c => new
                    {
                        idTurno = c.Int(nullable: false, identity: true),
                        nombre = c.String(nullable: false, maxLength: 7, unicode: false, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => t.idTurno);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ItemOT", "idOrdenTrabajoAplicacion", "dbo.OrdenTrabajoAplicacion");
            DropForeignKey("dbo.OrdenTrabajoAplicacion", "idTurno", "dbo.Turno");
            DropForeignKey("dbo.OrdenTrabajoAplicacion", "responsable_idPersonal", "dbo.Personal");
            DropForeignKey("dbo.OrdenTrabajoAplicacion", "jefeSeccion_idPersonal", "dbo.Personal");
            DropForeignKey("dbo.ItemOT", "idMaterial", "dbo.Material");
            DropForeignKey("dbo.ItemOP", "idOrdenPedido", "dbo.OrdenPedido");
            DropForeignKey("dbo.ItemOP", "idMaterial", "dbo.Material");
            DropForeignKey("dbo.Entrada", "idTipoEntrada", "dbo.TipoEntrada");
            DropForeignKey("dbo.Material", "idUnidad", "dbo.Unidad");
            DropForeignKey("dbo.Material", "idTipoMaterial", "dbo.TipoMaterial");
            DropForeignKey("dbo.Salida", "idTipoSalida", "dbo.TipoSalida");
            DropForeignKey("dbo.Salida", "idMaterial", "dbo.Material");
            DropForeignKey("dbo.Material", "idProveedor", "dbo.Proveedor");
            DropForeignKey("dbo.Entrada", "idMaterial", "dbo.Material");
            DropIndex("dbo.ItemOT", new[] { "idOrdenTrabajoAplicacion" });
            DropIndex("dbo.OrdenTrabajoAplicacion", new[] { "idTurno" });
            DropIndex("dbo.OrdenTrabajoAplicacion", new[] { "responsable_idPersonal" });
            DropIndex("dbo.OrdenTrabajoAplicacion", new[] { "jefeSeccion_idPersonal" });
            DropIndex("dbo.ItemOT", new[] { "idMaterial" });
            DropIndex("dbo.ItemOP", new[] { "idOrdenPedido" });
            DropIndex("dbo.ItemOP", new[] { "idMaterial" });
            DropIndex("dbo.Entrada", new[] { "idTipoEntrada" });
            DropIndex("dbo.Material", new[] { "idUnidad" });
            DropIndex("dbo.Material", new[] { "idTipoMaterial" });
            DropIndex("dbo.Salida", new[] { "idTipoSalida" });
            DropIndex("dbo.Salida", new[] { "idMaterial" });
            DropIndex("dbo.Material", new[] { "idProveedor" });
            DropIndex("dbo.Entrada", new[] { "idMaterial" });
            DropTable("dbo.Turno");
            DropTable("dbo.Personal");
            DropTable("dbo.OrdenTrabajoAplicacion");
            DropTable("dbo.ItemOT");
            DropTable("dbo.OrdenPedido");
            DropTable("dbo.ItemOP");
            DropTable("dbo.TipoEntrada");
            DropTable("dbo.Unidad");
            DropTable("dbo.TipoMaterial");
            DropTable("dbo.TipoSalida");
            DropTable("dbo.Salida");
            DropTable("dbo.Proveedor");
            DropTable("dbo.Material");
            DropTable("dbo.Entrada");
        }
    }
}
